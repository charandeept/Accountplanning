using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    public interface IImportExportDMService
    {
        public Task<DataTable> GetExcelTemplate();
        public Task<DataTable> GetExcel();
        public Task<Result<List<ImportUsersMessageDTO>>> ImportUsers(IFormFile file);
        public Task<Result<List<UsersTableDTO>>> displayUsersTable();
        public Task<Result<UsersTableDTO>> AddOrEditUser(UsersTableDTO user);
        public Task<Result<List<UserRoleDTO>>> GetUserRole();
        public Task<Result<List<UsersTableDTO>>> FilterUsers(ImportUsers_FilterAndSort ImportUsers_FilterAndSort);
    }
}
