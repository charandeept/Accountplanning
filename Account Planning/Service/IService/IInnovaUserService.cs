namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInnovaUserService
    {
        public Task<Result<List<InnovaUserDTO>>> GetAll();
    }
}
