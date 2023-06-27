
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{
    public interface IEnablerRepository
    {
        public Task<EnablerDTO> GetEnablers();
        public Task<AddEnablersDTO> CreateEnablers(int Id, AddEnablersDTO addEnablersDTO);
        public Task<EnablerTypeDTO> SaveEnablerType(int Id, EnablerTypeDTO enablers);
        public Task<bool> RemoveEnablerType(int id);
        public Task<bool> RemoveEnabler(int id);


    }
}
