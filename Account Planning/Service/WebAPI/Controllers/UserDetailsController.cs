using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using Com.ACSCorp.AccountPlanning.Service.Common.Filters;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Any })]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsService _getUserService;
        public UserDetailsController(IUserDetailsService getUserService)
        {
            _getUserService = getUserService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUser(string emailId)
        {
            var response = await _getUserService.GetUser(emailId);
            if (response == null)
            {
                return BadRequest("The result is null");
            }
            return Ok(response.Value);
        }
    }
}
