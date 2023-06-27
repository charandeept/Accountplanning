using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{

    public interface IUserDetailsRepository
    {
        public Task<List<UserDTO>> GetUser(string emailId);
    }
}
