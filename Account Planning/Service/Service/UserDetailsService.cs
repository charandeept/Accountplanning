using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly IUserDetailsRepository _getUserRepository;
        public UserDetailsService(IUserDetailsRepository getUserRepository)
        {
            _getUserRepository = getUserRepository;
        }
        public async Task<Result<List<UserDTO>>> GetUser(string emailId)
        {
            try
            {
                var result = await _getUserRepository.GetUser(emailId);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
