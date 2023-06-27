using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using Com.ACSCorp.AccountPlanning.Service.Common.Filters;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Any })]
    public class CustomerInfoController : BaseController
    {

        private readonly ICustomerInfoService _customerInfoService;

        public CustomerInfoController(ICustomerInfoService customerInfoService)
        {
            _customerInfoService = customerInfoService;
        }
        /// <summary>
        /// To get all the TimeZones
        /// </summary>
        /// <returns>List of TimeZonesDTO</returns>
        
        [HttpGet("GetTimeZone")]
        public async Task<IActionResult> GetTimeZone()
        {
            var response = await _customerInfoService.GetTimeZone();

            if (response == null)
            {
                return NotFound("No TimeZone found");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            

            return Ok(response.Value);
        }

        [HttpGet("GetServiceLine")]
        public async Task<IActionResult> GetServiceLine()
        {
            var response = await _customerInfoService.GetServiceLine();

            if (response == null)
            {
                return NotFound("No ServiceLine found");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response.Value);
        }

        /// <summary>
        /// To get all the ClientPartners
        /// </summary>
        /// <returns>List of ClientPartners</returns>

        [HttpGet("GetClientPartner")]
        public async Task<IActionResult> GetClientPartner()
        {
            var response = await _customerInfoService.GetClientPartner();

            if (response == null)
            {
                return NotFound("No ClientPartner found");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }            

            return Ok(response.Value);
        }


        /// <summary>
        /// To get all the IndustryDetails
        /// </summary>
        /// <returns>List of IndustryDetailsDTO</returns>

        [HttpGet("GetIndustry")]
        public async Task<IActionResult> GetIndustry()
        {
            var response = await _customerInfoService.GetIndustry();

            if (response == null)
            {
                return NotFound("No Industry found");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }            

            return Ok(response.Value);
        }

        /// <summary>
        /// To get all the CustomerService
        /// </summary>
        /// <returns>List of CustomerServiceDTO</returns>
        [HttpGet("GetCustomerServices")]
        public async Task<IActionResult> GetCustomerServiceDTO()
        {
            var response = await _customerInfoService.GetCustomerService();

            if (response == null)
            {
                return NotFound("No Organisation Services found");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }            

            return Ok(response.Value);
        }

        /// <summary>
        /// To get all the DeliveryModels
        /// </summary>
        /// <returns>List of DeliveryModelsDTO</returns>
        [HttpGet("GetDeliveryModel")]
        public async Task<IActionResult> GetDeliveryModel()
        {
            var response = await _customerInfoService.GetDeliveryModel();

            if (response == null)
            {
                return NotFound("No Delivery Model found");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            

            return Ok(response.Value);
        }

        /// <summary>
        /// To get all the HeadQuarters
        /// </summary>
        /// <returns>List of HeadQuartersDTO</returns>

        [HttpGet("GetHeadQuarters")]
        public async Task<IActionResult> GetHeadQuarters()
        {
            var response = await _customerInfoService.GetHeadQuarters();

            if (response == null)
            {
                return NotFound("No HeadQuarters found");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }          

            return Ok(response.Value);
        }

        /// <summary>
        /// To get all the DeliveryManager
        /// </summary>
        /// <returns>List of DeliveryManagerDTO</returns>

        [HttpGet("GetDeliveryManager")]
        public async Task<IActionResult> GetDeliveryManager()
        {
            var response = await _customerInfoService.GetDeliveryManager();

            if (response == null)
            {
                return NotFound("No Delivery Manager found");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }           

            return Ok(response.Value);
        }

        /// <summary>
        /// Gets FinancialHealthQuestionnaires
        /// </summary>
        /// <param name="CustomerId">CustomerId</param>
        /// <returns>List<FinalcialHealthQuestionnaireBM></returns>
        [HttpGet("GetFinancialHealthQuestionnaire")]
        public async Task<IActionResult> GetFinancialHealthQuestionnaire()
        {
            
            var response = await _customerInfoService.GetFinancialHealthQuestionnaire();

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




        [HttpGet("GetEngagementHealthQuestionnaire")]
        public async Task<IActionResult> GetEngagementHealthQuestionnaire()
        {
            

            var response = await _customerInfoService.GetEngagementHealthQuestionnaire();

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




        /// <summary>
        /// To get Customer Business Information by using CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns>Returns Customer Business Overview</returns>

        [HttpGet("GetCustomerBusinessInformation/{CustomerId}")]
        public async Task<IActionResult> GetCustomerBusinessInformation(int CustomerId)
        {
            if(CustomerId <= 0)
            {
                return NotFound("Enter Valid CustomerId");
            }

            var response = await _customerInfoService.GetCustomerBusinessInformation(CustomerId);

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

        /// <summary>
        /// To get CSAT Details by using CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>


        [HttpGet("GetCSATDetails/{CustomerId}")]
        public async Task<IActionResult> GetCSATDetails(int CustomerId)
        {
            if (CustomerId <= 0)
            {
                return NotFound("Enter Valid CustomerId");
            }
            var response = await _customerInfoService.GetCSATDetails(CustomerId);

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


        /// <summary>
        /// this menthod is used to get customer vendor details
        /// of specific customer using unique customer id
        /// </summary>
        /// <param name="customerId">unique ID of customer</param>
        /// <returns>returns customer vendor details</returns>
        [HttpGet("GetCustomerVendors/{customerId:min(1)}")]
        public async Task<IActionResult> GetCustomerVendors(int customerId)
        {
            if (customerId <= 0)
            {
                return NotFound("Enter Valid Customer Id");
            }

            var response = await _customerInfoService.GetCustomerVendors(customerId);

            if (response == null)
            {
                return NotFound("Enter Valid Customer Id");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }            

            return Ok(response.Value);
        }

        /// <summary>
        /// this method is used to get get customer engagement health
        /// of specific customer using unique CustomerId
        /// </summary>
        /// <param name="customerId">unique ID of customer</param>
        /// <returns>returns Customer Engagement Health</returns>
        [HttpGet("GetCustomerEngagementHealth/{customerId}")]
        public async Task<IActionResult> GetCustomerEngagementHealth(int customerId)
        {
            if (customerId <= 0)
            {
                return NotFound("Enter Valid Customer Id");
            }

            var response = await _customerInfoService.GetCustomerEngagementHealth(customerId);

            if (response == null)
            {
                return NotFound("Enter Valid Customer Id");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }           

            return Ok(response.Value);
        }

        /// <summary>
        /// This method is used to update the CustomerVendorDetails
        /// of specific customer
        /// </summary>
        /// <param name="CustomerId">unique ID of customer</param>
        /// <param name="vendorDetails">vendor details will name and service of vendor</param>
        /// <returns>returns the updated customerVendor details</returns>
        [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Leader })] //Leader only
        [HttpPost("AddOrUpdateCustomerBusinessInformation/{CustomerId}")]
        public async Task<IActionResult> AddOrUpdateCustomerBusinessInformation([FromRoute] int CustomerId,[FromBody] CustomerBusinessInfoBM customerBusinessInfoBM )
        {
            if(CustomerId <0)
            {
                return NotFound("Enter Valid CustomerId");
            }

            var response= await _customerInfoService.UpdateCustomerBusinessInformationDTO(CustomerId , customerBusinessInfoBM);
                        
            if (!response.IsSucceeded)
            { 
                return BadRequest(response.GetErrorString());
            }
            
            return Ok(response.Value);

        }


        [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Leader })] // Leader only
        [HttpPost("AddOrUpdateCSATDetails/{CustomerId}")]
        public async Task<IActionResult> AddOrUpdateCSATDetails([FromRoute] int CustomerId, [FromBody] CSATDetailsBM csatDetailsBM)
        {
            if (CustomerId <= 0)
            {
                return NotFound("Enter Valid CustomerId");
            }
            var response = await _customerInfoService.UpdateCSATDetailsDTO(CustomerId, csatDetailsBM);

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }



            if (response == null)
            {
                return NotFound("Enter Valid CustomerId");
            }

            if (!response.IsSucceeded)
            {
                return NotFound("Enter Valid Customer Id");
            }

             return Ok(response.Value);

        }

        [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Leader })] //Leader only
        [HttpPost("AddOrUpdateCustomerVendorDetails/{CustomerId}")]
        public async Task<IActionResult> AddOrUpdateCustomerVendorDetails([FromRoute] int CustomerId, [FromBody] VendorListBM vendorDetailsBM)
        {
            if (CustomerId <= 0)
            {
                return NotFound("Enter Valid Customer Id");
            }

            var response = await _customerInfoService.UpdateCustomerVendorDetails(CustomerId, vendorDetailsBM.VendorList);

            if (response == null)
            {
                return NotFound("Enter Valid Customer Id");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }

            return Ok(response.Value);
        }

        /// <summary>
        /// This method is used to update the UpdateCustomerEngagementHealth
        /// of specific customer
        /// </summary>
        /// <param name="CustomerId">unique ID of customer</param>
        /// <param name="customerEngagementHealthDTO">Takes JsonPatchDocument type input</param>
        /// <returns>returns the updated CustomerEngagementHealth details</returns>
        //[HttpPost("AddOrUpdateCustomerEngagementHealth/{CustomerId}")]
        //public async Task<IActionResult> AddOrUpdateCustomerEngagementHealth([FromRoute] int CustomerId, [FromBody] CustomerEngagementHealthBM customerEngagementHealthBM)
        //{
        //    if (CustomerId <= 0)
        //    {
        //        return NotFound("Enter Valid Customer Id");
        //    }

        //    var response = await _customerInfoService.updateCustomerEngagementHealthDTO(CustomerId, customerEngagementHealthBM);

        //    if (response == null)
        //    {
        //        return NotFound("Enter Valid Customer Id");
        //    }

        //    if (!response.IsSucceeded)
        //    {
        //        return BadRequest(response.GetErrorString());
        //    }

        //    return Ok(response.Value);


        //}

        /// <summary>
        /// This method is used to update the UpdateCustomerMood
        /// of specific customer
        /// </summary>
        /// <param name="CustomerId">unique ID of customer</param>
        /// <param name="customerMoodDTO">Takes JsonPatchDocument type input</param>
        /// <returns>returns the updated CustomerMood details</returns>
        [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Leader })] //Leader only
        [HttpPost("AddOrUpdateCustomerMood/{CustomerId}")]
        public async Task<IActionResult> AddOrUpdateCustomerMood([FromRoute] int CustomerId, [FromBody] CustomerMoodDetailsBM customerMoodBM)
        {
            if (CustomerId <= 0)
            {
                return NotFound("Enter Valid Customer Id");
            }

            var response = await _customerInfoService.UpdateCustomerMood(CustomerId, customerMoodBM);

            if (response == null)
            {
                return NotFound("Enter Valid Customer Id");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }                       

            return Ok(response.Value);
        }



        /// <summary>
        /// This Method is used to get Customer TeamInfo of specific customer using CustomerID
        /// </summary>
        /// <param name="Customerid">Unique id of Customer</param>
        /// <returns> Returns Customer Team Info</returns>
        [HttpGet("GetCustomerTeamInfo/{CustomerId}")]
        //[Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Any })]
        public async Task<IActionResult> GetCustomerTeamInfo(int CustomerId)
        {

            if (CustomerId <= 0)
            {
                return NotFound("Enter Valid Customer Id");
            }
            var response = await _customerInfoService.GetCustomerInfo(CustomerId);

            if (response == null)
            {
                return NotFound("Enter Valid Customer Id");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }          
            
            return Ok(response.Value);
        }


        /// <summary>
        /// This Method is used to get Customer Financial Health of Specific Customer Using CustomerId
        /// </summary>
        /// <param name="Customerid">Unique ID of Customer</param>
        /// <returns>Returns Custmer Financial Health</returns>
        [HttpGet("GetCustomerFinancialHealth/{CustomerId}")]
        public async Task<IActionResult> GetCustomerFinancialHealth(int CustomerId)
        {
            if (CustomerId <= 0)
            {
                return NotFound("Enter Valid Customer Id");
            }

            var response = await _customerInfoService.GetCustomerFinancialHealth(CustomerId);

            if (response == null)
            {
                return NotFound("Enter Valid Customer Id");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            
            return Ok(response.Value);
        }




        /// <summary>
        /// This Method is used to get Customer Mood Details of Specific Customer Using CustomerId
        /// </summary>
        /// <param name="CustomerId">Unique ID of Customer</param>
        /// <returns>Returns Custmer Mood Details</returns>
        [HttpGet("GetCustomerMoodDetails/{CustomerId}")]
        public async Task<IActionResult> GetCustomerMoodDetails(int CustomerId)
        {
            if (CustomerId <= 0)
            {
                return NotFound("Enter Valid Customer Id");
            }
            var response = await _customerInfoService.GetCustomerMoodDetails(CustomerId);

            if (response == null)
            {
                return NotFound("Enter Valid Customer Id");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }

            
            return Ok(response.Value);
        }


        //[HttpPost("AddOrUpadateCustomerFinancialHealth/{CustomerId}")]
        //public async Task<IActionResult> AddOrUpdateCustomerFinancialHealth([FromRoute]int CustomerId,[FromBody] CustomerFinancialHealthBM customerFinancialHealthBM)
        //{
        //    if (CustomerId <= 0)
        //    {
        //        return NotFound("Enter Valid Customer Id");
        //    }

        //    var response = await _customerInfoService.UpdateCustomerFinancialHealthDTO(CustomerId, customerFinancialHealthBM);

        //    if (response == null)
        //    {
        //        return NotFound("Enter Valid Customer Id");
        //    }

        //    if (!response.IsSucceeded)
        //    {
        //        return BadRequest(response.GetErrorString());
        //    }

        //    return Ok(response.Value);
        //}


        [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Leader })] //Leader only
        [HttpPost("AddOrUpadateCustomerTeamInfo/{CustomerId}")]
        public async Task<IActionResult> AddOrUpdateCustomerTeamInfo([FromRoute] int CustomerId, [FromBody] CustomerTeamInfoBM customerTeamInfoBM)
        {
            if (CustomerId <= 0)
            {
                return NotFound("Enter Valid Customer Id");
            }

            var response = await _customerInfoService.UpdateCustomerTeamInfoDTO(CustomerId, customerTeamInfoBM);

            if (response == null)
            {
                return NotFound("Enter Valid Customer Id");
            }
            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
                        
            return Ok(response.Value);
        }

        [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Leader })] //Leader only
        [HttpPost("AddOrUpdateEngagementHealthQuestionnaires/{CustomerId}")]
        public async Task<IActionResult> AddOrUpdateEngagementHealthQuestionnaires([FromRoute]int CustomerId,[FromBody] List<EngagementHealthHealthIndicatorBM> engagementHealthHealthIndicatorBMs)
        {
            if (CustomerId <= 0)
            {
                return NotFound("Enter Valid Customer Id");
            }

            var response = await _customerInfoService.AddOrUpdateEngagementHealthQuestionnaires(CustomerId, engagementHealthHealthIndicatorBMs);

            if (response == null)
            {
                return NotFound("Enter Valid Customer Id");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }

            return Ok(response.Value);
        }

        [Authorize(allowedRoles: new EmployeeRole[] { EmployeeRole.Leader })] //Leader only
        [HttpPost("AddOrUpdateFinancialHealthQuestionnaires/{CustomerId}")]
        public async Task<IActionResult> AddOrUpdateFinancialHealthQuestionnaires([FromRoute] int CustomerId, [FromBody] List<FinancialHealthHealthIndicatorBM> financialHealthHealthIndicatorBMs)
        {
            if (CustomerId <= 0)
            {
                return NotFound("Enter Valid Customer Id");
            }

            var response = await _customerInfoService.AddOrUpdateFinancialHealthQuestionnaires(CustomerId, financialHealthHealthIndicatorBMs);

            if (response == null)
            {
                return NotFound("Enter Valid Customer Id");
            }

            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }

            return Ok(response.Value);
        }

    }
      
}


