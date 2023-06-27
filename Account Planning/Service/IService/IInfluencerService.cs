using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    public interface IInfluencerService
    {
        public Task<Result<List<InfluencerDTO>>> GetAll();
    }

}
