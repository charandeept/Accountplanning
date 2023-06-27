namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    using Com.ACSCorp.AccountPlanning.Service.IRepository;
    using Com.ACSCorp.AccountPlanning.Service.IService;
    using Com.ACSCorp.AccountPlanning.Service.Models;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class OrgHierarchyService : IOrgHierarchyService
    {
        private readonly IOrgHierarchyRepository _orghierarchyRepository;

        public OrgHierarchyService(IOrgHierarchyRepository orghierarchyRepository)
        {
            _orghierarchyRepository = orghierarchyRepository;
        }


        public async Task<Result<List<OrgHierarchyDTO>>> GetById(int Id)
        {
            try
            {
                var result = await _orghierarchyRepository.GetById(Id);
                return Result.Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Result<List<OrgHierarchyDTO>>> GetDetails(int customerId)
        {
            try
            {
                var result = await _orghierarchyRepository.GetDetails(customerId);
                return Result.Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Result<OrgHierarchyDTO>> EditUser(int CustomerUserId, OrgHierarchyDTO user)
        {
            try
            {
                var result = await _orghierarchyRepository.EditUser(CustomerUserId, user);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Result<OrgHierarchyDTO>> AddUser(int CustomerUserId, OrgHierarchyDTO user)
        {
            try
            {
                var result = await _orghierarchyRepository.AddUser(CustomerUserId, user);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<OrgHierarchyDTO>("Failed to add user");
            }
        }
        public async Task<Result<List<OrgHierarchyDTO>>> EditHierarchy_FilterAndSort(OrgHierarchyFilterGridDTO filters)
        {
            try
            {
                var result = await _orghierarchyRepository.EditHierarchy_FilterAndSort(filters);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Result<bool>> DeleteHierarchy(int id)
        {
            try
            {
                var result = await _orghierarchyRepository.DeleteHierarchy(id);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

