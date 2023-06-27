using Com.ACSCorp.AccountPlanning.Service.Common.Contants;
using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.CommonQuery;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
using Com.ACSCorp.AccountPlanning.Service.Repository.Mapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using Microsoft.EntityFrameworkCore;

namespace Com.ACSCorp.AccountPlanning.Service.Repository
{

    public class OpportunitiesRepository : BaseRepository<ROLES>, IOpportunitiesRepository
    {
        private readonly AccountPlanningContext _AccountPlanningContext;

        public IConfiguration Configuration { get; }


        public OpportunitiesRepository(AccountPlanningContext AccountPlanningContext, IConfiguration configuration) : base(AccountPlanningContext)
        {
            _AccountPlanningContext = AccountPlanningContext;
            Configuration = configuration;

        }

        


        public async Task<List<OpportunitiesDTO>> GetOpportunities(int CustomerId)
        {
            DataTable OpportunitiesTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@customerId", CustomerId)
            };

            OpportunitiesTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetOpportunities, ConnectionString, sqlParameters);
         

            return OpportunitiesMapper.GetOpportunitiesDTOs(OpportunitiesTable);

        }

       

        public async Task<CatalogueAwarenessDTO> GetCatalogueAwareness(int CustomerId)
        {
            DataTable CatlalogueAwarenessTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@customerId ",CustomerId)

            };

            CatlalogueAwarenessTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetCatalogueAwareness, ConnectionString, sqlParameters);

            return CatalogueAwarenessMapper.GetCatalogueAwarenessDTO(CatlalogueAwarenessTable);

        }


        public async Task<RoadMapDetailsDTO> UpdateRoadMapDetails(int CustomerId, RoadMapDetailsDTO roadMapDetailsDTO)
        {
            var RoadMapTable = RoadMapDetailsMapper.GetRoadMapDetails(roadMapDetailsDTO);

            var roadMapDetails = await _AccountPlanningContext.RoadMap.FirstOrDefaultAsync(x => x.Id == CustomerId);

            if (roadMapDetails != null)
            {

                
                roadMapDetails.CustomerId = RoadMapTable.CustomerId;
                roadMapDetails.Description = RoadMapTable.Description;
                roadMapDetails.Image=RoadMapTable.Image;

                await _AccountPlanningContext.SaveChangesAsync();
                return RoadMapDetailsMapper.GetRoadMapDetailsDTO(await _AccountPlanningContext.RoadMap.FirstOrDefaultAsync(x => x.Id == CustomerId));
            }
            else
            {
                return null;
            }
        }

        public async Task<List<CategoryDetailsDTO>> GetCategoryDetails()
        {

            DataTable CategoryDetailsTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            CategoryDetailsTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetCategoryDetails, ConnectionString);

            return CategoryDetailsMapper.GetCategoryDetailsDTOs(CategoryDetailsTable);
        }



        public async Task<PainPointsDetailsDTO> UpdatePainPointsDetails(int CustomerId, PainPointsDetailsDTO painPointsDetailsDTO)
        {
            var OpportunitiesTable = PainPointsDetailsMapper.GetPainPointsDetails(painPointsDetailsDTO);

            var painPointsDetails = await _AccountPlanningContext.Opportunities.FirstOrDefaultAsync(x => x.Id == CustomerId);

            if (painPointsDetails != null)
            {
                painPointsDetails.PainPoints = OpportunitiesTable.PainPoints;
               

                await _AccountPlanningContext.SaveChangesAsync();
                return PainPointsDetailsMapper.GetPainPointsDetailsDTO(await _AccountPlanningContext.Opportunities.FirstOrDefaultAsync(x => x.Id == CustomerId));
            }
            else
            {
                return null;
            }
        }



        public async Task<OpportunitiesDTO> UpdateOpportunities(int RoleId, OpportunitiesDTO opportunitiesDTO)
        {
            var OpportunitiesTable = OpportunitiesMapper.GetOpportunities(opportunitiesDTO);

            var opportunities = await _AccountPlanningContext.ROLES.FirstOrDefaultAsync(x => x.RoleId == RoleId);

            if (opportunities != null)
            {
                opportunities.RoleDescription = OpportunitiesTable.RoleDescription;
                opportunities.CustomerId = OpportunitiesTable.CustomerId;
                opportunities.RoleTitle = OpportunitiesTable.RoleTitle;
                opportunities.CategoryId = OpportunitiesTable.CategoryId;
                //opportunities.Category = OpportunitiesTable.Category;
                opportunities.NoOfRoles = OpportunitiesTable.NoOfRoles;
                opportunities.Skills = OpportunitiesTable.Skills;
                opportunities.PostedDate = OpportunitiesTable.PostedDate;
                opportunities.Location = OpportunitiesTable.Location;
                opportunities.IsBookMarked = OpportunitiesTable.IsBookMarked;
                opportunities.MinExperience = OpportunitiesTable.MinExperience;
                opportunities.MaxExperience = OpportunitiesTable.MaxExperience;
                opportunities.OpportunitiesId = OpportunitiesTable.OpportunitiesId;



                _AccountPlanningContext.ROLES.Update(opportunities);
                await _AccountPlanningContext.SaveChangesAsync();
                return OpportunitiesMapper.GetOpportunitiesDTOFromRoles(opportunities);
            }
            else
            {
                await _AccountPlanningContext.ROLES.AddAsync(OpportunitiesTable);
                await _AccountPlanningContext.SaveChangesAsync();

                return OpportunitiesMapper.GetOpportunitiesDTOFromRoles(OpportunitiesTable);
            }
        }

        public async Task<PainPointsDTO> GetPainPointDetails(int CustomerId)
        {
            DataTable PainPointsTable = new DataTable();
            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@customerId", CustomerId)
            };
            PainPointsTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetPainPoints, ConnectionString, sqlParameters);
            return PainPointsMapper.GetPainPointsDTO(PainPointsTable);
        }
    }
}
