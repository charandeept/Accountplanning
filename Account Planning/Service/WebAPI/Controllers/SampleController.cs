using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.API.Controllers
{
    public class SampleController : BaseController
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _sampleService.GetById(0);

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }

            return Ok(response.Value);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _sampleService.GetById(id);

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }

            return Ok(response.Value);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post(SampleDTO sample)
        {
            var result = await _sampleService.AddSample(sample);

            if (!result.IsSucceeded)
            {
                return BadRequest(result.GetErrorString());
            }

            return Ok(result.Value);
        }

        [HttpPut("Put")]
        public async Task<IActionResult> Put(SampleDTO sample)
        {
            var result = await _sampleService.UpdateSample(sample);

            if (!result.IsSucceeded)
            {
                return BadRequest(result.GetErrorString());
            }

            return Ok(result.Value);
        }
    }
}