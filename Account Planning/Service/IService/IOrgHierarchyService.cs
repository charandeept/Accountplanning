namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    using Com.ACSCorp.AccountPlanning.Service.Models;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrgHierarchyService
    {
        public Task<Result<List<OrgHierarchyDTO>>> GetById(int Id);
        public Task<Result<List<OrgHierarchyDTO>>> GetDetails(int customerId);
        public Task<Result<OrgHierarchyDTO>> AddUser(int CustomerUserId, OrgHierarchyDTO user);
        public Task<Result<OrgHierarchyDTO>> EditUser(int CustomerUserId, OrgHierarchyDTO user);
        public Task<Result<List<OrgHierarchyDTO>>> EditHierarchy_FilterAndSort(OrgHierarchyFilterGridDTO filters);
        public Task<Result<bool>> DeleteHierarchy(int id);
    }
}
