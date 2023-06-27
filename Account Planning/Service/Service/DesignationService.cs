namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    using Com.ACSCorp.AccountPlanning.Service.IRepository;
    using Com.ACSCorp.AccountPlanning.Service.IService;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class DesignationService: IDesignationService
    {
        private readonly IDesignationRepository _designationRepository;

        public DesignationService(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;


        }
        public async Task<Result<List<DesignationDTO>>> GetAll()
        {
            try
            {
                var result = await _designationRepository.GetAll();
                return Result.Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

    }
}
