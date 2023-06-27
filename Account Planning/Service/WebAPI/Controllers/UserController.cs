using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Interface;
using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model;
using Com.ACSCorp.AccountPlanning.Service.Common.Filters;
using Com.ACSCorp.AccountPlanning.Service.Common.Enums;

namespace Com.ACSCorp.AccountPlanning.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Any })]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet("GetCurrentUser")]
        public CurrentUser GetCurrentUser()
        {
            return _identityService.GetCurrentUser();
        } 


    }
}
