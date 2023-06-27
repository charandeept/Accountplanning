namespace Com.ACSCorp.AccountPlanning.Service.API.Controllers
{
    using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
    using Com.ACSCorp.AccountPlanning.Service.Common.Filters;
    using Com.ACSCorp.AccountPlanning.Service.IService;
    using Com.ACSCorp.AccountPlanning.Service.Models;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Any })]
    public class OrgHierarchyController : ControllerBase
    {
        private readonly IOrgHierarchyService _orghierarchyService;
        private readonly ICustomerUsersService _customerUsersService;

        public OrgHierarchyController(IOrgHierarchyService orghierarchyService, ICustomerUsersService customerUsersService)
        {
            _orghierarchyService = orghierarchyService;
            _customerUsersService = customerUsersService;
        }


        [HttpGet("Employee/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var response = await _orghierarchyService.GetById(Id);

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }


        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetDetails(int customerId)
        {
            var Response = await _orghierarchyService.GetDetails(customerId);
            if (!Response.IsSucceeded)
            {
                return BadRequest(Response.GetErrorString());
            }
            return Ok(Response.Value);
        }


        [HttpPut]
        public async Task<IActionResult> SaveUser(OrgHierarchyDTO user)
        {
            Result<int> response1;
            Result<OrgHierarchyDTO> response2;

            if (user.Id == 0)
            {
                response1 = await _customerUsersService.AddUser(user);
                response2 = await _orghierarchyService.AddUser(response1.Value, user);
            }
            else
            {
                response1 = await _customerUsersService.EditUser(user);
                response2 = await _orghierarchyService.EditUser(response1.Value, user);
            }

            if (response1.IsSucceeded && response2.IsSucceeded)
            {
                return Ok(response2.Value);
            }
            return BadRequest(response2.GetErrorString());
        }
        [HttpPost("FilterGrid")]
        public async Task<IActionResult> EditHierarchy_FilterAndSort(OrgHierarchyFilterGridDTO filters)
        {
            var result = await _orghierarchyService.EditHierarchy_FilterAndSort(filters);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.GetErrorString());
            }
            return Ok(result.Value);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHierarchy(int id)
        {
            var result = await _orghierarchyService.DeleteHierarchy(id);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.GetErrorString());
            }
            return Ok(result.Value);
        }
    }
}
