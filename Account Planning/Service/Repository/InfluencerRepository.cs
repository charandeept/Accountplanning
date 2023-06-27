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
    public class InfluencerRepository : IInfluencerRepository
    {
        protected readonly AccountPlanningContext _dbContext;
        private readonly IMapper _mapper;
        public IConfiguration Configuration { get; }

        public InfluencerRepository(AccountPlanningContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            Configuration = configuration;
        }


        public async Task<List<InfluencerDTO>> GetAll()
        {


            List<InfluencerDTO> lists = new List<InfluencerDTO>();
            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                
                string query = "[dbo].[usp_Get_All_Influencerkdm]";
                SqlDataAdapter da = new SqlDataAdapter(query, (SqlConnection)connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var list = _mapper.Map<InfluencerDTO>(row);
                    lists.Add(list);

                }
            }
            return lists;
        }


    }

}
