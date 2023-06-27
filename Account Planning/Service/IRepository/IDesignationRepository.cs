namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDesignationRepository
    {
        public Task<List<DesignationDTO>> GetAll();
    }
}
