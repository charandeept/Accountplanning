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
    public class InnovaUserController : ControllerBase
    {
        private readonly IInnovaUserService _innovauserService;

        public InnovaUserController(IInnovaUserService innovauserService)
        {
            _innovauserService = innovauserService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> InnovaUserList()
        {
            var response = await _innovauserService.GetAll();

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }

            return Ok(response.Value);
        }

    }
}
