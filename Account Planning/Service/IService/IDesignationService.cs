namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDesignationService
    {
        public Task<Result<List<DesignationDTO>>> GetAll();
    }
}
