using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{
    public interface IEngagementRepository
    {
        public Task<List<EngagementDTO>> GetEngagementLevel();
    }
}
