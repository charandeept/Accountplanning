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
    public class CustomerUsersController : BaseController
    {
        private readonly ICustomerUsersService _customerUsersService;

        public CustomerUsersController(ICustomerUsersService customerUsersService)
        {
            _customerUsersService = customerUsersService;
        }


        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetUsersByCustomerId(int customerId)
        {
            var response = await _customerUsersService.GetUsersByCustomerId(customerId);

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }
    }
}

