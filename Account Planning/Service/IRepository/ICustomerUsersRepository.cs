using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{
    public interface ICustomerUsersRepository
    {
        public Task<List<CustomerUserDTO>> GetUsersByCustomerId(int customerId);
        public Task<int> AddUser(OrgHierarchyDTO user);
        public Task<int> EditUser(OrgHierarchyDTO user);
    }

}
