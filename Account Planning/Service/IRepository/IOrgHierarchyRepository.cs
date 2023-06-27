namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{
    using Com.ACSCorp.AccountPlanning.Service.Models;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrgHierarchyRepository
    {
        public Task<List<OrgHierarchyDTO>> GetById(int Id);
        public Task<List<OrgHierarchyDTO>> GetDetails(int customerId);
        public Task<OrgHierarchyDTO> AddUser(int CustomerUserId, OrgHierarchyDTO user);
        public Task<OrgHierarchyDTO> EditUser(int CustomerUserId, OrgHierarchyDTO user);
        public Task<List<OrgHierarchyDTO>> EditHierarchy_FilterAndSort(OrgHierarchyFilterGridDTO filter);
        public Task<bool> DeleteHierarchy(int id);
    }
}
