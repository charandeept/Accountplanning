using ClosedXML.Excel;
using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using Com.ACSCorp.AccountPlanning.Service.Common.Filters;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Any })]
    public class ImportExportDMController : ControllerBase
    {
        private readonly IImportExportDMService _importExportDMService;
        public ImportExportDMController(IImportExportDMService importExportDMService)
        {
            _importExportDMService = importExportDMService;
        }


        [HttpGet("DownloadTemplate")]
        public async Task<IActionResult> DownloadTemplate()
        {
            var response = await _importExportDMService.GetExcelTemplate();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(response);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DMTEMPLATE.xlsx");
                }
            }
        }


        [HttpGet("ExportDM")]
        public async Task<IActionResult> GetDownloadExcel()
        {
            var response = await _importExportDMService.GetExcel();
            if (response.Rows.Count <= 0)
            {
                return NotFound("The DataTable is Empty");
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(response);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DmsList.xlsx");
                }
            }
        }

        [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Leader })]
        [HttpPost("ImportUsers")] 
        public async Task<IActionResult> ImportUsers(IFormFile file) 
        { 
            var response = await _importExportDMService.ImportUsers(file); 
            if (response.IsSucceeded) 
            { 
                if (response.Value.Count == 1 && response.Value[0].Status == null) 
                { 
                    return BadRequest(response.Value); 
                } 
                return Ok(response.Value); 
            } 
            return BadRequest(response.GetErrorString()); 
        }


        [HttpGet("UsersTable")] 
        public async Task<IActionResult> displayUsersTable() 
        { 
            var Response = await _importExportDMService.displayUsersTable(); 
            if (!Response.IsSucceeded) 
            { 
                return BadRequest(Response.GetErrorString()); 
            } 
            return Ok(Response.Value); 
        }
        

        [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Any })]
        [HttpPut("AddOrEditUser")]
        public async Task<IActionResult> AddOrEditUser(UsersTableDTO user)
        {
            var Response = await _importExportDMService.AddOrEditUser(user);
            if (!Response.IsSucceeded)
            {
                return BadRequest(Response.GetErrorString());
            }
            return Ok(Response.Value);
        }

        [HttpGet("GetUserRole")]
        public async Task<IActionResult> GetUserRole()
        {
            var Response = await _importExportDMService.GetUserRole();
            if (!Response.IsSucceeded)
            {
                return BadRequest(Response.GetErrorString());
            }
            return Ok(Response.Value);
        }


        [HttpPost("Filter")]
        public async Task<IActionResult> FilterUsers([FromBody] ImportUsers_FilterAndSort ImportUsers_FilterAndSort)
        {
            var Response = await _importExportDMService.FilterUsers(ImportUsers_FilterAndSort);
            if (!Response.IsSucceeded)
            {
                return BadRequest(Response.GetErrorString());
            }
            return Ok(Response.Value);
        }
    }
}
