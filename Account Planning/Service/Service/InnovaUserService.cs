namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    using Com.ACSCorp.AccountPlanning.Service.IRepository;
    using Com.ACSCorp.AccountPlanning.Service.IService;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class InnovaUserService: IInnovaUserService
    {
        private readonly IInnovaUserRepository _innovauserRepository;
        public InnovaUserService(IInnovaUserRepository innovauserRepository)
        {
            _innovauserRepository = innovauserRepository;

        }
        public async Task<Result<List<InnovaUserDTO>>> GetAll()
        {
            try
            {
                var result = await _innovauserRepository.GetAll();
                return Result.Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
