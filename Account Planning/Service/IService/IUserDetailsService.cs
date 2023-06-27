using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    public interface IUserDetailsService
    {
        public Task<Result<List<UserDTO>>> GetUser(string emailId);
    }
}
