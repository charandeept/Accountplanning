using AutoMapper;
using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Repository
{
    public class CustomerUsersRepository : ICustomerUsersRepository
    {
        private readonly AccountPlanningContext _context;
        private readonly IMapper _mapper;
        public IConfiguration _configuration { get; }


        public CustomerUsersRepository(AccountPlanningContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }


        public async Task<List<CustomerUserDTO>> GetUsersByCustomerId(int customerId)
        {
            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = "@CustomerId",
                Value = customerId
            };

            List<CustomerUserDTO> users = new List<CustomerUserDTO>();
            string ConnectionString = _configuration.GetConnectionString("AccountPlanning");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "[dbo].[usp_Get_CustomerUsers_By_CustomerId]";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add(parameter);

                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    var user = _mapper.Map<CustomerUserDTO>(row);
                    users.Add(user);
                }
            }
            users.Add(new CustomerUserDTO() { Id = 0, Name = "N/A" });
            return users;
        }


        public async Task<int> AddUser(OrgHierarchyDTO user)
        {
            var record = _mapper.Map<CustomerUser>(user);

            _context.CustomerUser.Add(record);
            await _context.SaveChangesAsync();
            return record.Id;
        }


        public async Task<int> EditUser(OrgHierarchyDTO user)
        {
            var record = _mapper.Map<CustomerUser>(user);
            record.Id = 0;
            var recordInOrg = _context.OrgHierarchy.First(o => o.Id == user.Id).UserId;
            if (recordInOrg == null)
            {
                _context.CustomerUser.Add(record);
            }
            else
            {
                record.Id = (int)recordInOrg;
                _context.CustomerUser.Update(record);
            }
            await _context.SaveChangesAsync();
            return record.Id;
        }
    }

}
