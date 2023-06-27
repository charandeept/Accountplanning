using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using Com.ACSCorp.AccountPlanning.Service.Common.Filters;

namespace Com.ACSCorp.AccountPlanning.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Any })]
    public class OpportunitiesController : BaseController
    {

        private readonly IOpportunitiesService _opportunitiesService;
        public OpportunitiesController(IOpportunitiesService opportunitiesService)
        {
            _opportunitiesService = opportunitiesService;
        }

        [HttpGet("GetOpportunities/{CustomerId}")]
        public async Task<IActionResult> GetOpportunities(int CustomerId)
        {
            if (CustomerId <= 0)
            {
                return NotFound("Enter Valid CustomerId");
            }

             var response = await _opportunitiesService.GetOpportunities(CustomerId);

            if (response == null)
            {
                return NotFound("Enter Valid CustomerId");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }

            return Ok(response.Value);
        }

        [HttpGet("GetCatalogueAwareness/{CustomerId}")]
        public async Task<IActionResult> GetCatalogueAwareness(int CustomerId)
        {
            if (CustomerId < 0)
            {
                return NotFound("Enter Valid CustomerId");
            }
            var response = await _opportunitiesService.GetCatalogueAwareness(CustomerId);

            if (response == null)
            {
                return NotFound("Enter Valid CustomerId");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }




        [HttpPost("UpdateRoadMapDetails/{CustomerId}")]
        public async Task<IActionResult> UpdateRoadMapDetails([FromRoute] int CustomerId, [FromBody] RoadMapDetailsBM roadMapDetailsBM)
        {
            if (CustomerId < 0)
            {
                return NotFound("Enter Valid CustomerId");
            }
            var response = await _opportunitiesService.UpdateRoadMapDetails(CustomerId, roadMapDetailsBM);

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }



        [HttpGet("GetCategoryDetails")]
        public async Task<IActionResult> GetCategoryDetails()
        {
            var response = await _opportunitiesService.GetCategoryDetails();

            if (response == null)
            {
                return NotFound("No Category found");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }

            return Ok(response.Value);
        }

        [HttpGet("GetPainpoints/{CustomerId}")]
        public async Task<IActionResult> GetPainpointsDetails(int CustomerId)
        {
            if (CustomerId < 0)
            {
                return NotFound("Enter Valid CustomerId");
            }
            var response = await _opportunitiesService.GetPainPoints(CustomerId);

            if (response == null)
            {
                return NotFound("Enter Valid CustomerId");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }

        [HttpPost("UpdatePainPointsDetails/{CustomerId}")]
        public async Task<IActionResult> UpdatePainPointsDetails([FromRoute] int CustomerId, [FromBody] PainPointsDetailsBM painPointsDetailsBM)
        {
            if (CustomerId < 0)
            {
                return NotFound("Enter Valid CustomerId");
            }
            var response = await _opportunitiesService.UpdatePainPointsDetails(CustomerId, painPointsDetailsBM);

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }


        [HttpPost("AddOrUpadateOpportunities/{RoleId}")]
        public async Task<IActionResult> UpdateOpportunities([FromRoute] int RoleId, [FromBody] OpportunitiesBM opportunitiesBM)
        {
            if (RoleId < 0)
            {
                return NotFound("Enter Valid RoleId");
            }
            var response = await _opportunitiesService.UpdateOpportunities(RoleId, opportunitiesBM);

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }
    }
}


