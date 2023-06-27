using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    public interface ICustomerUsersService
    {
        public Task<Result<List<CustomerUserDTO>>> GetUsersByCustomerId(int customerId);
        public Task<Result<int>> AddUser(OrgHierarchyDTO user);
        public Task<Result<int>> EditUser(OrgHierarchyDTO user);
    }
}
