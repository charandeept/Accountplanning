using AutoMapper;
using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    public class CustomerInfoService : ICustomerInfoService
    {
        private readonly ICustomerInfoRepository _customerInfoRepository;
        private readonly IMapper _mapper;


        public CustomerInfoService(ICustomerInfoRepository customerInfoRepository, IMapper mapper)
        {
            _customerInfoRepository = customerInfoRepository;
            _mapper = mapper;

        }

        /// <summary>
        /// To get all the TimeZones
        /// </summary>
        /// <returns>List of TimeZonesDTO</returns>

        public async Task<Result<List<TimeZoneBM>>> GetTimeZone()
        {
            try
            {

                var result = await _customerInfoRepository.GetTimeZone();

                if(result == null)
                {
                    return null;
                }
                
                return Result.Ok(TimeZoneMapper.GetTimeZoneBMs(result));

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<List<ServiceLineBM>>> GetServiceLine()
        {
            try
            {
                var result = await _customerInfoRepository.GetServicesLine();
                if (result == null)
                {
                    return null;
                }
                return Result.Ok(ServiceLineMapper.GetServiceLineBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the List of clientPartners
        /// </summary>
        /// <returns>List of ClientPartners</returns>
        public async Task<Result<List<ClientPartnerBM>>> GetClientPartner()
        {
            try
            {
                var result = await _customerInfoRepository.GetClientPartner();

                if (result == null)
                {
                    return null;
                }

                return Result.Ok(ClientPartnerMapper.GetClientPartnerBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// To get all the IndustryDetails
        /// </summary>
        /// <returns>List of IndustryDetailsDTO</returns>
        public async Task<Result<List<IndustryBM>>> GetIndustry()
        {
            try
            {
                var result = await _customerInfoRepository.GetIndustry();

                if(result == null)
                {
                    return null;
                }

                return Result.Ok(IndustryMapper.GetIndustryBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// To get all the CustomerServices
        /// </summary>
        /// <returns>List of CustomerServiceDTOs</returns>
        public async Task<Result<List<CustomerServiceBM>>> GetCustomerService()
        {
            try
            {
                var result = await _customerInfoRepository.GetCustomerService();

                if(result == null)
                {
                    return null;
                }

                return Result.Ok(CustomerServiceMapper.GetCustomerServiceBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// To get all the DeliveryModels
        /// </summary>
        /// <returns>List of DeliveryModelsDTO</returns>
        public async Task<Result<List<DeliveryModelBM>>> GetDeliveryModel()
        {
            try
            {
                var result = await _customerInfoRepository.GetDeliveryModel();

                if( result == null)
                {
                    return null;
                }

                return Result.Ok(DeliveryModelMapper.GetDeliveryModelBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// To get all the HeadQuarters
        /// </summary>
        /// <returns>List of HeadQuartersDTO</returns>
        public async Task<Result<List<HeadQuartersBM>>> GetHeadQuarters()
        {
            try
            {
                var result = await _customerInfoRepository.GetHeadQuarters();

                if( result == null)
                {
                    return null;
                }

                return Result.Ok(HeadQuartersMapper.GetHeadQuartersBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// To get all the DeliveryManager
        /// </summary>
        /// <returns>List of DeliveryManagerDTO</returns>
        public async Task<Result<List<DeliveryManagerBM>>> GetDeliveryManager()
        {
            try
            {
                var result = await _customerInfoRepository.GetDeliveryManager();

                if(result == null)
                {
                    return null;
                }

                return Result.Ok(DeliveryManagerMapper.GetDeliveryManagerBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<List<FinancialHealthQuestionnaireBM>>> GetFinancialHealthQuestionnaire()
        {
            try
            {
                var result = await _customerInfoRepository.GetFinancialHealthQuestionnaire();

                if( result == null)
                {
                    return null;
                }

                return Result.Ok(FinancialHealthQuestionnaireMapper.GetFinancialHealthQuestionnaireBMs(result));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<Result<List<EngagementHealthQuestionnaireBM>>> GetEngagementHealthQuestionnaire()
        {
            try
            {
                var result = await _customerInfoRepository.GetEngagementHealthQuestionnaire();

                if(result == null)
                {
                    return null;
                }

                return Result.Ok(EngagementHealthQuestionnaireMapper.GetEngagementHealthQuestionnaireBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// To Get Customer Business Information by using Customer Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public async Task<Result<CustomerBusinessInfoBM>> GetCustomerBusinessInformation(int CustomerId)
        {
            try
            {
                var result = await _customerInfoRepository.GetCustomerBusinessInformation(CustomerId);

                if (result == null)
                {
                    return null;
                }

                return Result.Ok(CustomerBusinessInfoMapper.GetCustomerBusinessInfoBM(result));
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// To get CSAT Details by using CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public async Task<Result<CSATDetailsBM>> GetCSATDetails(int CustomerId)
        {
            try
            {
                var result = await _customerInfoRepository.GetCSATDetails(CustomerId);   
                
                if( result == null)
                {
                    return null;
                }
                
                return Result.Ok(CSATDetailsMapper.GetCSATDetailsBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// this menthod is used to get customer vendor details
        /// of specific customer using unique customer id
        /// </summary>
        /// <param name="customerId">unique ID of customer</param>
        /// <returns>returns customer vendor details</returns>
        public async Task<Result<List<CustomerVendorServiceBM>>> GetCustomerVendors(int customerId)
        {
            try
            {
                var result = await _customerInfoRepository.GetCustomerVendorDetails(customerId);
                
                if(result == null)
                {
                    return null;
                }

                return Result.Ok(CustomerVendorServiceMapper.GetCustomerVendorServiceBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// this method is used to get get customer engagement health
        /// of specific customer using unique CustomerId
        /// </summary>
        /// <param name="customerId">unique ID of customer</param>
        /// <returns>returns Customer Engagement Health </returns>
        public async Task<Result<CustomerEngagementHealthBM>> GetCustomerEngagementHealth(int customerId)
        {
            try
            {
                var result = await _customerInfoRepository.GetCustomerEngagementHealth(customerId);

                if(result == null)
                {
                    return null;
                }
                
                return Result.Ok(CustomerEngagementHealthMapper.GetCustomerEngagementHealthBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }     

        /// This method is used to update the CustomerVendorDetails
        /// of specific customer
        /// </summary>
        /// <param name="CustomerId">unique ID of customer</param>
        /// <param name="vendorDetails">vendor details will name and service of vendor</param>
        /// <returns>returns the updated customerVendor details</returns>
         public async Task<Result<List<CustomerVendorBM>>> UpdateCustomerVendorDetails(int CustomerId, List<VendorBM> vendorDetailsBM)
        {
            try
            {
                List<VendorDTO> vendorDetailsDTOList = new List<VendorDTO>();

                foreach(VendorBM vendor in vendorDetailsBM)
                {
                    var vendorDetailsDTO = VendorMapper.GetVendorDTO(vendor);
                    vendorDetailsDTOList.Add(vendorDetailsDTO);
                }
                

                var result = await _customerInfoRepository.UpdateCustomerVendorDetails(CustomerId, vendorDetailsDTOList);

                if (result == null)
                {
                    return null;
                }

                return Result.Ok(CustomerVendorMapper.GetCustomerVendorBMList(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// This method is used to update the UpdateCustomerEngagementHealth
        /// of specific customer
        /// </summary>
        /// <param name="CustomerId">unique ID of customer</param>
        /// <param name="customerEngagementHealthDTO">Takes  type input</param>
        /// <returns>returns the updated CustomerEngagementHealth details</returns>
        //public async Task<Result<CustomerEngagementHealthBM>> updateCustomerEngagementHealthDTO(int CustomerId, CustomerEngagementHealthBM customerEngagementHealthBM)
        //{

        //    try
        //    {
        //        var x = customerEngagementHealthBM.data;


        //        foreach (var item in x)
        //        {
        //            customerEngagementHealthBM.EngagementHealth = customerEngagementHealthBM.EngagementHealth + item.Points;
        //        }


        //        var customerEngagementHealthDTO = CustomerEngagementHealthMapper.GetCustomerEngagementHealthDTO(customerEngagementHealthBM);

        //        var result = await _customerInfoRepository.UpdateCustomerEngagementHealth(CustomerId, customerEngagementHealthDTO);

        //        if (result == null)
        //        {
        //            return null;
        //        }

        //        return Result.Ok(CustomerEngagementHealthMapper.GetCustomerEngagementHealthBM(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Fail<CustomerEngagementHealthBM>(ex.Message);
        //    }

        //}

        /// <summary>
        /// This method is used to update the UpdateCustomerMood
        /// of specific customer
        /// </summary>
        /// <param name="CustomerId">unique ID of customer</param>
        /// <param name="customerMoodDTO">Takes  type input</param>
        /// <returns>returns the updated CustomerMood details</returns>
        public async Task<Result<CustomerMoodDetailsBM>> UpdateCustomerMood(int CustomerId, CustomerMoodDetailsBM customerMoodBM)
        {
            try
            {
                var customerMoodDTO = CustomerMoodDetailsMapper.GetCustomerMoodDetailsDTO(customerMoodBM);

                var result = await _customerInfoRepository.UpdateCustomerMood(CustomerId, customerMoodDTO);

                if (result == null)
                {
                    return null;
                }

                return Result.Ok(CustomerMoodDetailsMapper.GetCustomerMoodDetailsBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// This Method is used to get Customer Team Info of specific customer using unique CustomerId
        /// </summary>
        /// <param name="Customerid"></param>
        /// <returns>returns Customer Team Info</returns>
        public async Task<Result<ClientDetailsBM>> GetCustomerInfo(int customerId)
        {
            try
            {
                var result = await _customerInfoRepository.GetCustomerInfo(customerId);

                if (result == null)
                {
                    return null;
                }

                return Result.Ok(ClientDetailsMapper.GetClientDetailsBM(result));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This Method is used to get Customer Financial Health of specific customer using unique CustomerId
        /// </summary>
        /// <param name="Customerid"></param>
        /// <returns>It Returns Customer FinancialHealth</returns>
        public async Task<Result<CustomerFinancialHealthBM>> GetCustomerFinancialHealth(int customerId)
        {
            try
            {
                var result = await _customerInfoRepository.GetCustomerFinancialHealth(customerId);

                if (result == null)
                {
                    return null;
                }

                return Result.Ok(CustomerFinancialHealthMapper.GetCustomerFinancialHealthBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This Method is used to get Customer Mood Details Using Unique CustomerId
        /// </summary>
        /// <param name="Customerid"></param>
        /// <returns>Returns Customer Mood Details</returns>
        public async Task<Result<CustomerMoodDetailsBM>> GetCustomerMoodDetails(int customerId)
        {
            try
            {
                var result = await _customerInfoRepository.GetCustomerMoodDetails(customerId);

                if (result == null)
                {
                    return null;
                }

                return Result.Ok(CustomerMoodDetailsMapper.GetCustomerMoodDetailsBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<Result<CustomerFinancialHealthBM>> UpdateCustomerFinancialHealthDTO(int CustomerId, CustomerFinancialHealthBM customerFinancialHealthBM)
        //{
        //    try
        //    {
        //        var customerFinancialHealthDTO = CustomerFinancialHealthMapper.GetCustomerFinancialHealthDTO(customerFinancialHealthBM);

        //        var result = await _customerInfoRepository.UpdateCustomerFinancialHealth(CustomerId, customerFinancialHealthDTO);
                
        //        if (result == null)
        //        {
        //            return null;
        //        }

        //        return Result.Ok(CustomerFinancialHealthMapper.GetCustomerFinancialHealthBM(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Fail<CustomerFinancialHealthBM>(ex.Message);
        //    }
        //}

        public async Task<Result<CustomerTeamInfoBM>> UpdateCustomerTeamInfoDTO(int CustomerId, CustomerTeamInfoBM customerTeamInfoBM)
        {
            try
            {
                var customerTeamInfoDTO = CustomerTeamInfoMapper.GetCustomerTeamInfoDTO(customerTeamInfoBM);

                var result = await _customerInfoRepository.UpdateCustomerTeamInfo(CustomerId, customerTeamInfoDTO);

                if (result == null)
                {
                    return null;
                }

                return Result.Ok(CustomerTeamInfoMapper.GetCustomerTeamInfoBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// To Update the Customer Business Information by using customer Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public async Task<Result<CustomerBusinessInfoBM>> UpdateCustomerBusinessInformationDTO(int CustomerId, CustomerBusinessInfoBM customerBusinessInfoBM)
        {
            try
            {
                var customerBusinessInfoDTO = CustomerBusinessInfoMapper.GetCustomerBusinessInfoDTO(customerBusinessInfoBM);

                var result = await _customerInfoRepository.UpdateCustomerBusinessInformation(CustomerId, customerBusinessInfoDTO);

                return Result.Ok(CustomerBusinessInfoMapper.GetCustomerBusinessInfoBM(result));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Result<CSATDetailsBM>> UpdateCSATDetailsDTO(int CustomerId, CSATDetailsBM csatDetailsBM)
        {
            try
            {
                var csatDetailsDTO = CSATDetailsMapper.GetCSATDetailsDTO(csatDetailsBM);

                var result = await _customerInfoRepository.UpdateCSATDetails(CustomerId, csatDetailsDTO);

                if (result == null)
                {
                    return null;
                }
                return Result.Ok(CSATDetailsMapper.GetCSATDetailsBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Result<CustomerEngagementHealthBM>> AddOrUpdateEngagementHealthQuestionnaires(int CustomerId, List<EngagementHealthHealthIndicatorBM> engagementHealthHealthIndicatorBMs)
        {
            try
            {
                List<QuestionnaireDTO> questionsList = new List<QuestionnaireDTO>();
                var engagementHealthHealthIndicatorDTO = EngagementHealthHealthIndicatorMapper.GetEngagementHealthHealthIndicatorDTOs(engagementHealthHealthIndicatorBMs);

                var engagementHealthValue = 0;

                foreach (var engagementHealth in engagementHealthHealthIndicatorDTO)
                {
                    QuestionnaireDTO question = new QuestionnaireDTO();                    
                    var totalPoints =  engagementHealth.OptionA + engagementHealth.OptionB + engagementHealth.OptionC + engagementHealth.OptionD;
                    engagementHealthValue = engagementHealthValue + totalPoints;
                    question.QuestionId = engagementHealth.questionId;
                    question.SelectedPoints = totalPoints;
                    questionsList.Add(question);
                }

                var result =  await _customerInfoRepository.UpdateCustomerEngagementHealth(CustomerId, engagementHealthValue,questionsList);

                //var result = await _customerInfoRepository.AddOrUpdateEngagementHealthQuestionnaires(CustomerId, engagementHealthHealthIndicatorDTO);

                if (result == null)
                {
                    return null;
                }

                return Result.Ok(CustomerEngagementHealthMapper.GetCustomerEngagementHealthBM(result));


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<CustomerFinancialHealthBM>> AddOrUpdateFinancialHealthQuestionnaires(int CustomerId, List<FinancialHealthHealthIndicatorBM> financialHealthHealthIndicatorBMs)
        {
            try
            {
                List<QuestionnaireDTO> questionsList = new List<QuestionnaireDTO>();
                var financialHealthHealthIndicatorDTO = FinancialHealthHealthIndicatorMapper.GetFinancialHealthHealthIndicatorDTOs(financialHealthHealthIndicatorBMs);

                var financialHealthValue = 0;

                foreach (var financialHealth in financialHealthHealthIndicatorDTO)
                {
                    QuestionnaireDTO question = new QuestionnaireDTO();

                    var totalPoints = financialHealth.OptionA + financialHealth.OptionB + financialHealth.OptionC + financialHealth.OptionD;
                    financialHealthValue = financialHealthValue + totalPoints;
                    question.QuestionId = financialHealth.questionId;
                    question.SelectedPoints = totalPoints;
                    questionsList.Add(question);
                }

                var result = await _customerInfoRepository.UpdateCustomerFinancialHealth(CustomerId, financialHealthValue, questionsList);

                if (result == null)
                {
                    return null;
                }

                return Result.Ok(CustomerFinancialHealthMapper.GetCustomerFinancialHealthBM(result));


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}

