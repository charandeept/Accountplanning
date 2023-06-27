using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{
    public interface IImportExportDMRepository
    {
        public Task<DataTable> GetExcelTemplate();
        public Task<DataTable> GetExcel();
        public Task<List<ImportUsersMessageDTO>> ImportUsers(IFormFile file);
        public Task<List<UsersTableDTO>> displayUsersTable();
        public Task<UsersTableDTO> AddOrEditUser(UsersTableDTO user);
        public Task<List<UserRoleDTO>> GetUserRole();
        public Task<List<UsersTableDTO>> FilterUsers(ImportUsers_FilterAndSort ImportUsers_FilterAndSort);
    }
}
