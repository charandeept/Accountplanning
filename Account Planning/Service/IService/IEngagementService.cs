using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    public interface IEngagementService
    {
        public Task<Result<List<EngagementDTO>>> GetEngagementLevel();
    }
}
