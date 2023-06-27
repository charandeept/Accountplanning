namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEnablerService
    {
        public Task<Result<EnablerDTO>> GetEnablers();
        public Task<Result<EnablersBM>> CreateEnablers(int Id, EnablersBM enablersBM);
        public Task<Result<EnablerTypeBM>> SaveEnablerType(int Id, EnablerTypeBM enablers);
        public Task<Result<bool>> RemoveEnablerType(int id);
        public Task<Result<bool>> RemoveEnabler(int id);


    }
}
