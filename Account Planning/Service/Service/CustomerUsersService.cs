using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    public class CustomerUsersService : ICustomerUsersService
    {
        private readonly ICustomerUsersRepository _customerUsersRepository;

        public CustomerUsersService(ICustomerUsersRepository customerUsersRepository)
        {
            _customerUsersRepository = customerUsersRepository;
        }


        public async Task<Result<List<CustomerUserDTO>>> GetUsersByCustomerId(int customerId)
        {

            try
            {
                var result = await _customerUsersRepository.GetUsersByCustomerId(customerId);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Result<int>> EditUser(OrgHierarchyDTO user)
        {
            try
            {
                var result = await _customerUsersRepository.EditUser(user);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Result<int>> AddUser(OrgHierarchyDTO user)
        {
            try
            {
                var result = await _customerUsersRepository.AddUser(user);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
