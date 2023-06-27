using AutoMapper;
using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Repository
{
    public class EngagementRepository:IEngagementRepository
    {
        protected readonly AccountPlanningContext _dbContext;
        private readonly IMapper _mapper;
        public IConfiguration Configuration { get; }

        public EngagementRepository(AccountPlanningContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            Configuration = configuration;
        }
        public async Task<List<EngagementDTO>> GetEngagementLevel()
        {


            List<EngagementDTO> lists = new List<EngagementDTO>();
            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                string query = "[dbo].[usp_Get_All_Engagementlevel]";
                SqlDataAdapter da = new SqlDataAdapter(query, (SqlConnection)connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var list = _mapper.Map<EngagementDTO>(row);
                    lists.Add(list);

                }
            }
            return lists;
        }

    }
}
