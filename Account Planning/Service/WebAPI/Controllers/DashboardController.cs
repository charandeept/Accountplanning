using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using Com.ACSCorp.AccountPlanning.Service.Common.Filters;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Leader })] //Leader only
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        /// <summary>
        /// this method is used to get dashboard data of all the customers
        /// </summary>
        /// <param name></param>
        /// <returns>returns the engagement health data, financial helath data, metrics data of all customers</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _dashboardService.DashboardData();

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }

            return Ok(response.Value);
        }


        /// <summary>
        /// this method is used to get the customer name searched by the user
        /// </summary>
        /// <param name="customername"></param>
        /// <returns>returns the customer names matching with the serached customer name</returns>
        [HttpGet("SearchCustomer")]
        public async Task<IActionResult> GetCustomer(string customername)
        {
            var response = await _dashboardService.SearchCustomer(customername);
            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }


        /// <summary>
        /// this method is used to get the Customer Services List
        /// </summary>
        /// <param name="cardId">unique ID of card</param>
        /// <returns>returns Customer Services List</returns>
        [HttpGet("GetServiceList")]
        public async Task<IActionResult> GetByMetric(int cardId)
        {
            var response = await _dashboardService.GetDetails(cardId);
            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }


        /// <summary>
        /// this method is used to get the customer list 
        /// </summary>
        /// <param name="employeeId">unique ID of employee</param>
        /// <returns>returns Customer List</returns>
        [HttpGet("GetCustomerList/userId")]
        public async Task<IActionResult> GetCustomerList([FromQuery] Customer customer)
        {
            var response = await _dashboardService.GetCustomerList(customer);
            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }


        /// <summary>
        /// this method is used to add and edit the metric cards 
        /// </summary>
        /// <param name="CardId">unique ID of card</param>
        /// <param name="UserId">unique ID of user</param>
        /// <param name="MetricId">unique ID of Metrictype</param>
        /// <param name="OperatorId">unique ID of Operatortype</param>
        /// <param name="Value">value of each metric</param>
        /// <returns></returns>
        [HttpPost("Post")]
        public async Task<IActionResult> Post(MetricsDTO metrics)
        {
            var result = await _dashboardService.CreateMetrics(metrics);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.GetErrorString());
            }
            //return Ok(result.Value);
            return CreatedAtAction(nameof(Post), result.Value);
        }

        /// <summary>
        /// this method is used to delete the metric card
        /// </summary>
        /// <param name="cardId">unique ID of Card</param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _dashboardService.RemoveMetrics(id);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.GetErrorString());
            }
            return Ok(result.Value);
        }

        /// <summary>
        /// this method is used to filter the customers by customername
        /// </summary>
        /// <param name="param1">datatable</param>
        /// <returns>filtered customer list</returns>
        [HttpPost("FilterGrid")]
        public async Task<IActionResult> CustomerFilter(List<FilterGridDTO> filters)
        {
            var result = await _dashboardService.CustomerFilter(filters);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.GetErrorString());
            }
            return Ok(result.Value);
        }
    }
}


