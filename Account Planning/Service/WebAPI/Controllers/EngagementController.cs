using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using Com.ACSCorp.AccountPlanning.Service.Common.Filters;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Any })]
    public class EngagementController : ControllerBase
    {
        private readonly IEngagementService _engagementService;

        public EngagementController(IEngagementService engagementService)
        {
            _engagementService = engagementService;
        }

        [HttpGet("GetEngagementLevel")]
        public async Task<IActionResult> EngagementLevelDD()
        {
            var Response = await _engagementService.GetEngagementLevel();
            if (!Response.IsSucceeded)
            {
                return BadRequest(Response.GetErrorString());
            }
            return Ok(Response.Value);
        }

    }
}

