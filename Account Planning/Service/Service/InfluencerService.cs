using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    public class InfluencerService : IInfluencerService
    {
        private readonly IInfluencerRepository _InfluencerRepository;

        public InfluencerService(IInfluencerRepository influencerRepository)
        {
            _InfluencerRepository = influencerRepository;
        }

        public async Task<Result<List<InfluencerDTO>>> GetAll()
        {

            var result = await _InfluencerRepository.GetAll();

            return Result.Ok(result);

        }
    }

}
