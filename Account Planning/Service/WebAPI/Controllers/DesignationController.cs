namespace Com.ACSCorp.AccountPlanning.Service.API.Controllers
{
    using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
    using Com.ACSCorp.AccountPlanning.Service.Common.Filters;
    using Com.ACSCorp.AccountPlanning.Service.IService;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Any })]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _designationService;

        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> DesignationList()
        {
            var response = await _designationService.GetAll();

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }

            return Ok(response.Value);
        }

    }
}
