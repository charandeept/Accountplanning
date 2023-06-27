using AutoMapper;
using ClosedXML.Excel;
using Com.ACSCorp.AccountPlanning.Service.Common.Contants;
using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Repository
{
    public class ImportExportDMRepository:IImportExportDMRepository
    {
        private readonly AccountPlanningContext _accountPlanningContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ImportExportDMRepository(AccountPlanningContext accountPlanningContext, IConfiguration configuration, IMapper mapper)
        {
            _accountPlanningContext = accountPlanningContext;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<DataTable> GetExcelTemplate()
        {

            DataTable dataTable = new DataTable("DMList");
            dataTable.Columns.AddRange(new DataColumn[6] {
                                        new DataColumn("Innova Id"),
                                        new DataColumn("User Name"),
                                        new DataColumn("User Email"),
                                        new DataColumn("Designation"),
                                        new DataColumn("Role"),
                                        new DataColumn("IsActive")
                                         });

            return await Task.FromResult(dataTable);
        }

        public async Task<DataTable> GetExcel()
        {
            List<DownloadExcelDTO> accountDetailsLists = new List<DownloadExcelDTO>();
            using (var dbConnection = _accountPlanningContext.Database.GetDbConnection())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Constants.DownloadExcelDMS, (SqlConnection)dbConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        DownloadExcelDTO accountDetailsList = new DownloadExcelDTO()
                        {
                            InnovaId = (int)row["InnovaId"],
                            UserName = row["UserName"].ToString(),
                            UserEmail = row["UserEmail"].ToString(),
                            Designation = row["Designation"].ToString(),
                            Role = row["UserRole"].ToString(),
                            IsActive = row["IsActive"].ToString()
                        };
                        accountDetailsLists.Add(accountDetailsList);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                DataTable dataTableExcel = new DataTable("DmsList");
                dataTableExcel.Columns.AddRange(new DataColumn[6] {
                                        new DataColumn("Innova Id"),
                                        new DataColumn("User Name"),
                                        new DataColumn("User Email"),
                                        new DataColumn("Designation"),
                                        new DataColumn("Role"),
                                        new DataColumn("IsActive")

                                         });
                foreach (var accountDetails in accountDetailsLists)
                {
                    if (accountDetails.Role != "GuestUser")
                    {
                        DataRow dataRow = dataTableExcel.NewRow();
                        dataRow["Innova Id"] = accountDetails.InnovaId;
                        dataRow["User Name"] = accountDetails.UserName;
                        dataRow["User Email"] = accountDetails.UserEmail;
                        dataRow["Designation"] = accountDetails.Designation;
                        if (accountDetails.Role == "Delivery Manager")
                        {
                            dataRow["Role"] = "L1";
                        }
                        else if (accountDetails.Role == "Leader")
                        {
                            dataRow["Role"] = "L2";
                        }
                        dataRow["IsActive"] = accountDetails.IsActive == "True" ? "Y" : "N";

                        dataTableExcel.Rows.Add(dataRow);
                    }
                }
                return await Task.FromResult(dataTableExcel);
            }
        }


        public async Task<List<ImportUsersMessageDTO>> ImportUsers(IFormFile file)
        {
            var allmessages = new List<ImportUsersMessageDTO>();
            if (file == null)
            {
                var error = new ImportUsersMessageDTO()
                {
                    Message = "No file uploaded."
                };
                allmessages.Add(error);
                return allmessages;
            }
            using var stream = new MemoryStream();
            file.CopyTo(stream);
            XLWorkbook wbook = null;
            try
            {
                wbook = new XLWorkbook(stream);
            }
            catch
            {
                var error = new ImportUsersMessageDTO()
                {
                    Message = "The uploaded file cannot be read. Please upload an excel file."
                };
                allmessages.Add(error);
                return allmessages;
            }
            
            //reading sheet data
            var ws1 = wbook.Worksheets.FirstOrDefault();
            if (!ws1.IsEmpty())
            {
                var firstRow = ws1.FirstRowUsed().RowNumber();
                List<string> fileColumns = new List<string>();
                List<string> templateColumns = new List<string>();
                var properties = typeof(DownloadExcelDTO).GetProperties();
                var count = 0; foreach (IXLCell cell in ws1.FirstRowUsed().CellsUsed())
                {
                    fileColumns.Add(cell.Value.ToString().Replace(" ", ""));
                }
                foreach (var prop in properties)
                {
                    templateColumns.Add(prop.Name.ToString());
                }
                if (templateColumns.Count == fileColumns.Count)
                {
                    for (var i = 0; i < templateColumns.Count; i++)
                    {
                        if (fileColumns[i] == templateColumns[i])
                            count++;
                    }
                }
                if (count != templateColumns.Count)
                {
                    var error = new ImportUsersMessageDTO()
                    {
                        Message = "The uploaded file does not follow the template. Please download the template and add users' data."
                    };
                    allmessages.Add(error);
                    return allmessages;
                } 
                
                //reading individual rows
                foreach (var row in ws1.RowsUsed().Skip(1))
                {
                    var obj = new DownloadExcelDTO();
                    StringBuilder message = new StringBuilder("");
                    string catchprop = null;
                    
                    //mapping cell values to corresponding properties of DTO
                    var colIndex = ws1.FirstColumnUsed().ColumnNumber();
                    foreach (var prop in properties)
                    {
                        var val = row.Cell(colIndex).Value;
                        var type = prop.PropertyType;
                        try
                        {
                            if (val.ToString() == "")
                            {
                                if (type == typeof(int))
                                    val = 0;
                                else
                                    val = null;
                            }
                            prop.SetValue(obj, Convert.ChangeType(val, type));
                        }
                        catch
                        {
                            if (type == typeof(int))
                                message.Append($"{ws1.Cell(firstRow, colIndex).Value} must have numbers only. ");
                            else
                                message.Append($"{ws1.Cell(firstRow, colIndex).Value} is not in correct format. ");
                            val = null;
                            catchprop = ws1.Cell(firstRow, colIndex).Value.ToString();
                            colIndex++;
                            continue;
                        }
                        colIndex++;
                    }

                    //validations for data
                    Users user = null;
                    var validator = new UserDTOValidator();
                    var validationResult = validator.Validate(obj);
                    if (validationResult.IsValid)
                    {
                        user = _mapper.Map<Users>(obj);
                    }
                    else
                    {
                        foreach (var failure in validationResult.Errors)
                        {
                            if (catchprop != null)
                            {
                                failure.ErrorMessage = failure.ErrorMessage.Contains(catchprop) ? "" : failure.ErrorMessage;
                            }
                            message.Append(failure.ErrorMessage);
                        }
                    }
                    
                    //add or update
                    var ImportUserMessage = new ImportUsersMessageDTO()
                    {
                        EmailAddress = obj.UserEmail
                    };
                    if (message.ToString() != "")
                    {
                        ImportUserMessage.Message = message.ToString();
                        ImportUserMessage.Status = "Failure";
                        allmessages.Add(ImportUserMessage);
                        continue;
                    }
                    else
                    {
                        user.ModifiedDate = DateTime.Now;
                        if (_accountPlanningContext.Users.Select(u => u.UserEmail).Contains(obj.UserEmail))
                        {
                            var a = _accountPlanningContext.Users.First(x => x.UserEmail == obj.UserEmail);
                            _accountPlanningContext.Entry(a).State = EntityState.Detached;
                            user.Id = a.Id;
                            _accountPlanningContext.Users.Update(user);
                            message.Append("User updated.");
                        }
                        else
                        {
                            _accountPlanningContext.Users.Add(user);
                            message.Append("User added.");
                        }
                        await _accountPlanningContext.SaveChangesAsync();
                        ImportUserMessage.Message = message.ToString();
                        ImportUserMessage.Status = "Success";
                    }
                    allmessages.Add(ImportUserMessage);
                }
                if (ws1.RowsUsed().Skip(1).Count() == 0)
                {
                    var error = new ImportUsersMessageDTO()
                    {
                        Message = "The uploaded file has no data to import."
                    };
                    allmessages.Add(error);
                }
            }
            else
            {
                var error = new ImportUsersMessageDTO()
                {
                    Message = "The uploaded file is empty."
                };
                allmessages.Add(error);
            }
            return allmessages;
        }


        public async Task<List<UsersTableDTO>> displayUsersTable()
        {
            List<UsersTableDTO> lists = new List<UsersTableDTO>();
            using (var con = _accountPlanningContext.Database.GetDbConnection())
            {
                string query = "[dbo].[usp_Get_All_Users]";
                SqlDataAdapter da = new SqlDataAdapter(query, (SqlConnection)con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var list = _mapper.Map<UsersTableDTO>(row);                    
                    await Task.Run(()=>lists.Add(list));
                }
            }
            return lists;
        }
        public async Task<UsersTableDTO> AddOrEditUser(UsersTableDTO user)
        {
            var r = _accountPlanningContext.Users.FirstOrDefault(o => o.Id == user.Id);
            var record = _mapper.Map<Users>(user);
            record.ModifiedDate = DateTime.Now;
            if (r == null)
            {
                _accountPlanningContext.Users.Add(record);
            }
            else
            {
                _accountPlanningContext.Entry(r).State = EntityState.Detached;
                _accountPlanningContext.Users.Update(record);
            }
            await _accountPlanningContext.SaveChangesAsync();
            return _mapper.Map<UsersTableDTO>(record);
        }
        public async Task<List<UserRoleDTO>> GetUserRole()
        {

            List<UserRoleDTO> lists = new List<UserRoleDTO>();
            using (var con = _accountPlanningContext.Database.GetDbConnection())
            {

                string query = "[dbo].[Get_All_UserRole]";
                SqlDataAdapter da = new SqlDataAdapter(query, (SqlConnection)con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var list = _mapper.Map<UserRoleDTO>(row);
                    await Task.Run(() => lists.Add(list));
                }
            }
            return lists;
        }


        public async Task<List<UsersTableDTO>> FilterUsers(ImportUsers_FilterAndSort importUsers_FilterAndSort)
        {
            List<UsersTableDTO> lists = new List<UsersTableDTO>();            
            using (var con = _accountPlanningContext.Database.GetDbConnection())
            {
                string query = "DECLARE @Param UT_FilterParametersUsers \n ";
                if (importUsers_FilterAndSort.Filter!=null)
                {
                    if(importUsers_FilterAndSort.Filter.Count != 0)
                    {
                        query += "INSERT INTO @Param VALUES";
                        foreach (var f in importUsers_FilterAndSort.Filter)
                        {
                            query += $" ('{f.ColumnName}', '{f.Operator}', '{f.Value}'),";
                        }
                        query = query.Remove(query.Length - 1, 1);
                    }                    
                }

                query += $"\n EXEC [dbo].[usp_Import_Users_Filter_Page] @Param, " +
                $"'{importUsers_FilterAndSort.SearchText}', " +
                $"'{(importUsers_FilterAndSort.OrderColumn ?? "Id")}', " +
                $"'{(importUsers_FilterAndSort.OrderType ?? "Asc")}'";

                SqlDataAdapter da = new SqlDataAdapter(query, (SqlConnection)con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var list = _mapper.Map<UsersTableDTO>(row);
                    await Task.Run(() => lists.Add(list));
                }
            }
            return lists;
        }
    }
}

