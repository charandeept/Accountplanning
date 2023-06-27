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
    public class InfluencerController : ControllerBase
    {
        private readonly IInfluencerService _influencerService;
        public InfluencerController(IInfluencerService influencerService)
        {
            _influencerService = influencerService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> InfluencerList()
        {
            var Response = await _influencerService.GetAll();
            if (!Response.IsSucceeded)
            {
                return BadRequest(Response.GetErrorString());
            }
            return Ok(Response.Value);
        }
    }
}