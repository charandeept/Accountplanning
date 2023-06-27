using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    public class ImportExportDMService : IImportExportDMService
    {
        private readonly IImportExportDMRepository _importExportDMRepository;
        public ImportExportDMService(IImportExportDMRepository importExportDMRepository)
        {
            _importExportDMRepository = importExportDMRepository;
        }


        public async Task<DataTable> GetExcelTemplate()
        {

            var result = await _importExportDMRepository.GetExcelTemplate();
            return (result);
        }


        public async Task<DataTable> GetExcel()
        {
            var result = await _importExportDMRepository.GetExcel();
            return (result);
        }


        public async Task<Result<List<ImportUsersMessageDTO>>> ImportUsers(IFormFile file)
        {
            try
            {
                var result = await _importExportDMRepository.ImportUsers(file);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

        public async Task<Result<List<UsersTableDTO>>> displayUsersTable()
        {
            try
            {
                var result = await _importExportDMRepository.displayUsersTable();
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<UsersTableDTO>> AddOrEditUser(UsersTableDTO user)
        {
            try
            {
                var result = await _importExportDMRepository.AddOrEditUser(user);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Result<List<UserRoleDTO>>> GetUserRole()
        {
            try
            {
                var result = await _importExportDMRepository.GetUserRole();

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Result<List<UsersTableDTO>>> FilterUsers(ImportUsers_FilterAndSort ImportUsers_FilterAndSort)
        {
            try
            {
                var result = await _importExportDMRepository.FilterUsers(ImportUsers_FilterAndSort); 
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<List<UsersTableDTO>>(ex.Message);
            }
        }
    }
}
