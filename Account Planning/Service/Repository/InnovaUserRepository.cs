namespace Com.ACSCorp.AccountPlanning.Service.Repository
{
    using AutoMapper;
    using Com.ACSCorp.AccountPlanning.Service.IRepository;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    public class InnovaUserRepository: IInnovaUserRepository
    {
        private readonly AccountPlanningContext _context;
        private readonly IMapper _mapper;
        public InnovaUserRepository(AccountPlanningContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<List<InnovaUserDTO>> GetAll()
        {
            List<InnovaUserDTO> lists = new List<InnovaUserDTO>();
            using (var con = _context.Database.GetDbConnection())
            {
                string query = "[dbo].[usp_Get_All_Innovausers]";
                SqlDataAdapter da = new SqlDataAdapter(query, (SqlConnection)con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var list = _mapper.Map<InnovaUserDTO>(row);
                    lists.Add(list);
                }
            }
            return lists;
        }


    }
}
