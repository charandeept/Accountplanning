using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    public interface IOpportunitiesService
    {

        public Task<Result<List<OpportunitiesBM>>> GetOpportunities(int CustomerId);
        public Task<Result<CatalogueAwarenessBM>> GetCatalogueAwareness(int CustomerId);
      //  public Task<Result<RoadMapDetailsBM>> UpdateRoadMapDetails(int CustomerId , RoadMapDetailsBM roadMapDetailsBM);

        public Task<Result<RoadMapDetailsBM>> UpdateRoadMapDetails(int CustomerId, RoadMapDetailsBM roadMapDetailsBM);
        public Task<Result<List<CategoryDetailsBM>>> GetCategoryDetails();


        public Task<Result<PainPointsDetailsBM>> UpdatePainPointsDetails(int CustomerId, PainPointsDetailsBM painPointsDetailsBM);

        public Task<Result<OpportunitiesBM>> UpdateOpportunities(int RoleId, OpportunitiesBM opportunitiesBM);

        public Task<Result<PainPointsBM>> GetPainPoints(int CustomerId);



    }
}
