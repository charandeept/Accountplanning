using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{
    public interface IOpportunitiesRepository 
    {

        public Task<List<OpportunitiesDTO>> GetOpportunities(int CustomerId);
        public Task<CatalogueAwarenessDTO> GetCatalogueAwareness(int CustomerId);

        public Task<RoadMapDetailsDTO> UpdateRoadMapDetails(int CustomerId, RoadMapDetailsDTO roadMapDetailsDTO);

        public Task<List<CategoryDetailsDTO>> GetCategoryDetails();

        public Task<PainPointsDetailsDTO> UpdatePainPointsDetails(int CustomerId, PainPointsDetailsDTO painPointsDetailsDTO);

        public Task<OpportunitiesDTO> UpdateOpportunities(int RoleId, OpportunitiesDTO opportunitiesDTO);


        public Task<PainPointsDTO> GetPainPointDetails(int CustomerId);




    }
}
