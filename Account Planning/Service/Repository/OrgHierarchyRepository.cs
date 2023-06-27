namespace Com.ACSCorp.AccountPlanning.Service.Repository
{
    using AutoMapper;
    using Com.ACSCorp.AccountPlanning.Service.IRepository;
    using Com.ACSCorp.AccountPlanning.Service.Models;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
    using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrgHierarchyRepository : IOrgHierarchyRepository
    {
        private readonly AccountPlanningContext _context;
        private readonly IMapper _mapper;
        public OrgHierarchyRepository(AccountPlanningContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<OrgHierarchyDTO>> GetById(int Id)
        {
            var list = await _context.OrgHierarchy
                .FromSqlRaw("execute [dbo].[usp_Get_OrgHeirDetail_By_OrgHeirarchyId] {0}", Id).ToListAsync();
            var lists = _mapper.Map<List<OrgHierarchyDTO>>(list);
            return lists;
        }


        public async Task<List<OrgHierarchyDTO>> GetDetails(int customerId)
        {
            List<OrgHierarchyDTO> lists = new List<OrgHierarchyDTO>();
            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = "@CustomerId",
                Value = customerId
            };

            using (var con = _context.Database.GetDbConnection())
            {
                string query = "[dbo].[usp_Get_OrgHeirarchyDetails_By_CustomerId]";
                SqlDataAdapter da = new SqlDataAdapter(query, (SqlConnection)con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add(parameter);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    var list = _mapper.Map<OrgHierarchyDTO>(row);
                    lists.Add(list);
                }
            }
            return lists;
        }


        public async Task<OrgHierarchyDTO> AddUser(int CustomerUserId, OrgHierarchyDTO user)
        {
            var record = _mapper.Map<OrgHierarchy>(user);
            record.UserId = CustomerUserId;
            record.UpdatedAt = DateTime.Now;
            record.ReportsToId = record.ReportsToId == 0 ? null : record.ReportsToId;
            _context.OrgHierarchy.Add(record);

            await _context.SaveChangesAsync();

            var userInRecord = _mapper.Map<OrgHierarchyDTO>(record);
            userInRecord.Name = _context.CustomerUser.First(c => c.Id == CustomerUserId).Name;
            return userInRecord;
        }


        public async Task<OrgHierarchyDTO> EditUser(int CustomerUserId, OrgHierarchyDTO user)
        {
            var r = _context.OrgHierarchy.First(o => o.Id == user.Id);
            _context.Entry(r).State = EntityState.Detached;

            var record = _mapper.Map<OrgHierarchy>(user);
            record.UserId = CustomerUserId;
            record.Id = user.Id;
            record.UpdatedAt = DateTime.Now;
            record.ReportsToId = record.ReportsToId == 0 ? null : record.ReportsToId;
            _context.OrgHierarchy.Update(record);

            await _context.SaveChangesAsync();

            var userInRecord = _mapper.Map<OrgHierarchyDTO>(record);
            userInRecord.Name = _context.CustomerUser.First(c => c.Id == CustomerUserId).Name;
            return userInRecord;
        }

       public async Task<List<OrgHierarchyDTO>> EditHierarchy_FilterAndSort(OrgHierarchyFilterGridDTO filter)
        {
            List<OrgHierarchyDTO> lists = new List<OrgHierarchyDTO>();
            
            using (var con = _context.Database.GetDbConnection())
            {
                string query1 = "DECLARE @Param UT_OrgHeirarchy_Filter_Parameters ";
                if (filter.Filterconditions.Count > 0)
                {
                    query1 += "\n INSERT INTO @Param VALUES ";
                    foreach (var f in filter.Filterconditions)
                    {
                        query1 += $"('{f.ColumnName}', '{f.Operator}', '{f.Value}'),";
                    }
                }
                query1 = query1.Remove(query1.Length - 1, 1);
                query1 += $"\nEXEC dbo.usp_OrgHeirarchy_List_Page_Filter {filter.CustomerId},@Param,'{filter.SearchText}','{filter.OrderColumn}','{filter.OrderType}'\n";
                SqlDataAdapter da = new SqlDataAdapter(query1, (SqlConnection)con);               
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var list = _mapper.Map<OrgHierarchyDTO>(row);                    
                    await Task.Run(() => lists.Add(list));
                }
            }
            return lists;
        }


        public async Task<bool> DeleteHierarchy(int id)
        {
            var personInOrgHierarchy = _context.OrgHierarchy.Find(id);
            if (personInOrgHierarchy == null)
            {
                return false;
            }

            var dependents = _context.OrgHierarchy.Where(d => d.ReportsToId == personInOrgHierarchy.UserId).ToList();
            if (dependents.Count > 0)
            {
                foreach (var dependent in dependents)
                {
                    dependent.ReportsToId = null;
                }
            }

            var personInCustomerUser = _context.CustomerUser.Find(personInOrgHierarchy.UserId);
            _context.CustomerUser.Remove(personInCustomerUser);
            _context.OrgHierarchy.Remove(personInOrgHierarchy);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
