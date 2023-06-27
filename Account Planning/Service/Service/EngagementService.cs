using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    public class EngagementService: IEngagementService
    {
        private readonly IEngagementRepository _engagementRepository;

        public EngagementService(IEngagementRepository engagementRepository)
        {
            _engagementRepository = engagementRepository;
        }
        public async Task<Result<List<EngagementDTO>>> GetEngagementLevel()
        {
            try
            {
                var result = await _engagementRepository.GetEngagementLevel();

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
