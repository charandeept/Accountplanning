using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using Com.ACSCorp.AccountPlanning.Service.Common.Filters;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
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
    public class EnablersController : ControllerBase
    {
        private readonly IEnablerService _enablerService;
        public EnablersController(IEnablerService enablerService)
        {
            _enablerService = enablerService;
        }

        [HttpGet("GetEnablers")]
        public async Task<IActionResult> GetEnablers()
        {
            var response = await _enablerService.GetEnablers();
            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }

        [HttpPost("AddorEditEnablercard/{Id}")]
        public async Task<IActionResult> CreateEnablers([FromRoute] int Id, [FromBody] EnablersBM enablersBM)
        {
            var result = await _enablerService.CreateEnablers(Id, enablersBM);
            if (result == null)
            {
                return NotFound("Enter Valid Id");
            }
            if (!result.IsSucceeded)
            {
                return BadRequest(result.GetErrorString());
            }
            return Ok(result.Value);
        }

        [HttpPost("AddorEditEnabler/{Id}")]
        public async Task<IActionResult> SaveEnablerType([FromRoute] int Id, [FromBody] EnablerTypeBM enablers)
        {
            var result = await _enablerService.SaveEnablerType(Id, enablers);
            if (result == null)
            {
                return NotFound("Enter Valid Id");
            }
            if (!result.IsSucceeded)
            {
                return BadRequest(result.GetErrorString());
            }
            return Ok(result.Value);
        }

        [HttpDelete("DeleteEnabler/{Id}")]
        public async Task<IActionResult> RemoveEnablerType([FromRoute] int Id)
        {
            if (Id < 0)
            {
                return NotFound("Enter Valid Id");
            }
            var result = await _enablerService.RemoveEnablerType(Id);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.GetErrorString());
            }
            return Ok(result.Value);
        }

        [HttpDelete("DeleteEnablerCard/{Id}")]
        public async Task<IActionResult> RemoveEnabler([FromRoute] int Id)
        {
            if (Id < 0)
            {
                return NotFound("Enter Valid Id");
            }
            var result = await _enablerService.RemoveEnabler(Id);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.GetErrorString());
            }
            return Ok(result.Value);
        }
    }
}
