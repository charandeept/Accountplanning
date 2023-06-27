using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using Com.ACSCorp.AccountPlanning.Service.Common.Contants;
using Microsoft.EntityFrameworkCore;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using Com.ACSCorp.AccountPlanning.Service.Repository.Mapper;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.CommonQuery;
using AutoMapper;
using System.Collections.Generic;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System.Linq;
using System;


namespace Com.ACSCorp.AccountPlanning.Service.Repository
{
    public class CustomerInfoRepository : BaseRepository<CustomerVendor>, ICustomerInfoRepository
    {
        private readonly AccountPlanningContext _AccountPlanningContext;
        private readonly IMapper _mapper;

        public IConfiguration Configuration { get; }
 
        public CustomerInfoRepository(AccountPlanningContext AccountPlanningContext, IConfiguration configuration, IMapper mapper) : base(AccountPlanningContext)
        {
            _AccountPlanningContext = AccountPlanningContext;
            Configuration = configuration;
            _mapper = mapper;
        }

        /// <summary>
        /// To get all the TimeZones
        /// </summary>
        /// <returns>List of TimeZonesDTO</returns>

        public async Task<List<TimeZoneDTO>> GetTimeZone()
        {
            DataTable TimeZoneTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            TimeZoneTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetTimeZone, ConnectionString);
                        
            return TimeZoneMapper.GetTimeZoneDTOs(TimeZoneTable);
        }

        public async Task<List<ServiceLineDTO>> GetServicesLine()
        {
            DataTable ServiceLineTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            ServiceLineTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetServiceLines, ConnectionString);

            return ServiceLineMapper.GetServiceLineDTOs(ServiceLineTable);
        }

        /// <summary>
        /// To Get the List of ClientPartners
        /// </summary>
        /// <returns>List of ClientPartners</returns>
        public async Task<List<ClientPartnerDTO>> GetClientPartner()
        {
            DataTable ClientPartnerTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            ClientPartnerTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetClientPartner, ConnectionString);

            return ClientPartnerMapper.GetClientPartnerDTOs(ClientPartnerTable);
        }

        /// <summary>
        /// To get all the IndustryDetails
        /// </summary>
        /// <returns>List of IndustryDTO</returns>
        public async Task<List<IndustryDTO>> GetIndustry()
        {
            DataTable IndustryDetailsTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            IndustryDetailsTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetIndustryDetails, ConnectionString);

            return IndustryMapper.GetIndustryDTOs(IndustryDetailsTable);
        }

        /// <summary>
        /// To get all the CustomerServices
        /// </summary>
        /// <returns>List of CustomerServiceDTO</returns>
        public async Task<List<CustomerServiceDTO>> GetCustomerService()
        {
            DataTable CustomerServiceTable = new DataTable();
            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            CustomerServiceTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetCustomerService, ConnectionString);

            return CustomerServiceMapper.GetCustomerServiceDTOs(CustomerServiceTable);
        }

        /// <summary>
        /// To get all the DeliveryModels
        /// </summary>
        /// <returns>List of DeliveryModelsDTO</returns>
        public async Task<List<DeliveryModelDTO>> GetDeliveryModel()
        {
            DataTable DeliveryModelTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            DeliveryModelTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetDeliveryModel, ConnectionString);

            return DeliveryModelMapper.GetDeliveryModelDTOs(DeliveryModelTable);
        }

        /// <summary>
        /// To get all the HeadQuarters
        /// </summary>
        /// <returns>List of HeadQuartersDTO</returns>
        public async Task<List<HeadQuartersDTO>> GetHeadQuarters()
        {
            DataTable HeadQuartersTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            HeadQuartersTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetHeadQuarters, ConnectionString);

            return HeadQuartersMapper.GetHeadQuartersDTOs(HeadQuartersTable);
        }

        /// <summary>
        /// To get all the DeliveryManager
        /// </summary>
        /// <returns>List of DeliveryManagerDTO/returns>
        public async Task<List<DeliveryManagerDTO>> GetDeliveryManager()
        {
            DataTable DeliveryManagerTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            DeliveryManagerTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetDeliveryManager, ConnectionString);

            return DeliveryManagerMapper.GetDeliveryManagerDTOs(DeliveryManagerTable);
        }


        public async Task<List<FinancialHealthQuestionnaireDTO>> GetFinancialHealthQuestionnaire()
        {
            DataTable financialHealthQuestionnairTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

           /* List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@CustomerId", CustomerId)
            };*/

            financialHealthQuestionnairTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetFinancialHealthQuestionnaire, ConnectionString);

            return FinancialHealthQuestionnaireMapper.GetFinancialHealthQuestionnaireDTOs(financialHealthQuestionnairTable);
        }



        public async Task<List<EngagementHealthQuestionnaireDTO>> GetEngagementHealthQuestionnaire()
        {
            DataTable EngagementHealthQuestionnairTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

           /* List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@CustomerId", CustomerId)
            };*/

            EngagementHealthQuestionnairTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetEngagementHealthQuestionnaire, ConnectionString );

            return EngagementHealthQuestionnaireMapper.GetEngagementHealthQuestionnaireDTOs(EngagementHealthQuestionnairTable);

        }





        /// <summary>
        /// To get customer business Information by using CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public async Task<CustomerBusinessInfoDTO> GetCustomerBusinessInformation(int CustomerId)
        {
            DataTable CustomerBusinessTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@customerId", CustomerId)
            };

            CustomerBusinessTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetCustomerBusinessInformation, ConnectionString, sqlParameters);
            
            return CustomerBusinessInfoMapper.GetCustomerBusinessInfoDTO(CustomerBusinessTable);
        }


        /// <summary>
        /// To get CSAT details by using CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public async Task<CSATDetailsDTO> GetCSATDetails(int CustomerId)
        {
            DataTable CSATTable = new DataTable();
            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@customerId", CustomerId)
            };

            CSATTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetCSATDetails, ConnectionString, sqlParameters);
            
            return CSATDetailsMapper.GetCSATDetailsDTO(CSATTable);
        }


        /// <summary>
        /// this menthod is used to get customer vendor details
        /// of specific customer using unique customer id
        /// </summary>
        /// <param name="customerId">unique ID of customer</param>
        /// <returns>returns customer vendor details</returns>
        public async Task<List<CustomerVendorServiceDTO>> GetCustomerVendorDetails(int CustomerId)
        {
            DataTable CustomerVendorDetailsTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@customerId", CustomerId)
            };

            CustomerVendorDetailsTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetCustomerVendorDetails, ConnectionString, sqlParameters);
           
            return CustomerVendorServiceMapper.GetCustomerVendorServiceDTOs(CustomerVendorDetailsTable);

            
        }


        /// <summary>
        /// this method is used to get get customer engagement health
        /// of specific customer using unique CustomerId
        /// </summary>
        /// <param name="customerId">unique ID of customer</param>
        /// <returns>returns Customer Engagement Health</returns>
        public async Task<CustomerEngagementHealthDTO> GetCustomerEngagementHealth(int CustomerId)
        {
            DataTable CustomerEngagementHealthTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@customerId", CustomerId)
            };

            CustomerEngagementHealthTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetCustomerEngagementHealth, ConnectionString, sqlParameters);
                 
            return CustomerEngagementHealthMapper.GetCustomerEngagementHealthDTO(CustomerEngagementHealthTable);
            
        }

        /// <summary>
        /// This method is used to update the CustomerVendorDetails
        /// of specific customer
        /// </summary>
        /// <param name="CustomerId">unique ID of customer</param>
        /// <param name="vendorDetails">vendor details will name and service of vendor</param>
        /// <returns>returns the updated customerVendor details</returns>
        public async Task<List<CustomerVendorDTO>> UpdateCustomerVendorDetails(int customerId, List<VendorDTO> vendorDetails)
        {
            List<CustomerVendorDTO> customerVendorList = new List<CustomerVendorDTO>();    
            foreach(VendorDTO vendorDTO in vendorDetails)
            {
                var vendorDetailsInput = VendorMapper.GetVendor(vendorDTO);
                var customerDetails = await _AccountPlanningContext.CustomerVendor.FirstOrDefaultAsync(cid => cid.CustomerId == customerId);

                var result = await _AccountPlanningContext.Vendor.FirstOrDefaultAsync(vendor => vendor.Name == vendorDetailsInput.Name);

                if (result == null)
                {
                    await _AccountPlanningContext.Vendor.AddAsync(vendorDetailsInput);
                    await _AccountPlanningContext.SaveChangesAsync();
                    result = await _AccountPlanningContext.Vendor.FirstOrDefaultAsync(vendor => vendor.Name == vendorDTO.vendorName);


                    await _AccountPlanningContext.CustomerVendor.AddAsync(new CustomerVendor()
                    {
                        VendorId = result.Id,
                        CustomerId = customerId
                    });

                    await _AccountPlanningContext.SaveChangesAsync();

                    customerVendorList.Add( CustomerVendorMapper.GetCustomerVendorDTO(await _AccountPlanningContext.CustomerVendor.FirstOrDefaultAsync(cv => cv.VendorId == result.Id && cv.CustomerId == customerId)));

                }
                else
                {
                    //result = await _AccountPlanningContext.Vendor.FirstOrDefaultAsync(vendor => vendor.Name == vendorDetails.Name);

                    var vendordetails = await _AccountPlanningContext.CustomerVendor.FirstOrDefaultAsync(cv => cv.CustomerId == customerId && cv.VendorId == result.Id);
                    if (vendordetails == null)
                    {
                        await _AccountPlanningContext.CustomerVendor.AddAsync(new CustomerVendor()
                        {
                            VendorId = result.Id,
                            CustomerId = customerId
                        });

                        await _AccountPlanningContext.SaveChangesAsync();
                    }

                    customerVendorList.Add( CustomerVendorMapper.GetCustomerVendorDTO(await _AccountPlanningContext.CustomerVendor.FirstOrDefaultAsync(cv => cv.VendorId == result.Id && cv.CustomerId == customerId)));

                }
            }


            return customerVendorList;

        }

        /// <summary>
        /// This method is used to update the UpdateCustomerEngagementHealth
        /// of specific customer
        /// </summary>
        /// <param name="CustomerId">unique ID of customer</param>
        /// <param name="customerInfoTable">Takes JsonPatchDocument type input</param>
        /// <returns>returns the updated customerInfoTable details</returns>

        public async Task<CustomerEngagementHealthDTO> UpdateCustomerEngagementHealth(int CustomerId, int customerEngagementHealthDTO, List<QuestionnaireDTO> questions)
        {
            //var customerEngagementHealth = CustomerEngagementHealthMapper.GetcustomerEngagementHealth(customerEngagementHealthDTO);

            var customerDetails = await _AccountPlanningContext.CustomerBusinessInfo.FindAsync(CustomerId);
            var questionsList = _AccountPlanningContext.CustomerQuestionnaire.Where(t => t.CustomerId == CustomerId);
            //var healthhistory = await _AccountPlanningContext.

            var history = new HealthHistory();
            history.CustomerId = CustomerId;
            history.HealthTypeId = (int)HealthType.EngagementHealth;
            history.HealthValue = customerEngagementHealthDTO;
            history.UpdatedDateTime = System.DateTime.Now;
            _AccountPlanningContext.HealthHistory.Add(history);

            if (questionsList.ToList().Count() == 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    var newQuestion = new CustomerQuestionnaire
                    {
                        CustomerId = CustomerId,
                        QuestionId = i,
                        CreatedBy = "SystemUser",
                        CreatedDate = DateTime.Now
                    };
                    questionsList.ToList().Add(newQuestion);
                }
                await _AccountPlanningContext.SaveChangesAsync();
                questionsList = _AccountPlanningContext.CustomerQuestionnaire.Where(t => t.CustomerId == CustomerId);
            }
           
            if (customerDetails == null)
            {
                return null;
            }           
            else
            {
                foreach(QuestionnaireDTO question in questions)
                {
                    questionsList.Where(item => item.QuestionId == question.QuestionId).FirstOrDefault().Points = question.SelectedPoints;
                }
                customerDetails.EngagementHealth = customerEngagementHealthDTO;


                await _AccountPlanningContext.SaveChangesAsync();
                

               return CustomerEngagementHealthMapper.GetCustomerEngagementHealtDTOFromCustomerTable(await _AccountPlanningContext.CustomerBusinessInfo.FirstOrDefaultAsync(cbi => cbi.Id == CustomerId));
            }
        }

        /// <summary>
        /// This method is used to update the UpdateCustomerMood
        /// of specific customer
        /// </summary>
        /// <param name="CustomerId">unique ID of customer</param>
        /// <param name="customerInfoTable">Takes JsonPatchDocument type input</param>
        /// <returns>returns the updated customerInfoTable details</returns>

        public async Task<CustomerMoodDetailsDTO> UpdateCustomerMood(int CustomerId, CustomerMoodDetailsDTO customerMoodDTO)
        {
            var customerDetails = await _AccountPlanningContext.CustomerBusinessInfo.FindAsync(CustomerId);

            if (customerDetails == null)
            {
                return null;
            }
            else
            {
                customerDetails.CustomerMood = customerMoodDTO.CustomerMood;
                await _AccountPlanningContext.SaveChangesAsync();
                return CustomerMoodDetailsMapper.GetCustomerMoodDTO(await _AccountPlanningContext.CustomerBusinessInfo.FirstOrDefaultAsync(cbi => cbi.Id == CustomerId));
            }

        }

        /// <summary>
        /// This Method is used to get Customer Team Info of specific customer using unique CustomerId
        /// </summary>
        /// <param name="Customerid"></param>
        /// <returns>returns Customer Team Info</returns>
        public async Task<ClientDetailsDTO> GetCustomerInfo(int CustomerId)
        {
            DataTable ClientDetailsTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@customerId", CustomerId)
            };

            ClientDetailsTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetCustomerInfo, ConnectionString, sqlParameters);
                      
            return CustomerTeamInfoMapper.GetCustomerTeamInfoDTO(ClientDetailsTable);
        }


        /// <summary>
        /// This Method is used to get Customer Financial Health of specific customer using unique CustomerId
        /// </summary>
        /// <param name="Customerid"></param>
        /// <returns>It Returns Customer FinancialHealth</returns>
        public async Task<CustomerFinancialHealthDTO> GetCustomerFinancialHealth(int CustomerId)
        {
            DataTable CustomerFinancialHealthTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@customerId", CustomerId)
            };

            CustomerFinancialHealthTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetCustomerFinancialHealth, ConnectionString, sqlParameters);
                       

            return CustomerFinancialHealthMapper.GetCustomerFinancialHealthDTO(CustomerFinancialHealthTable);
        }


        /// <summary>
        /// This Method is used to get Customer Mood Details Using Unique CustomerId
        /// </summary>
        /// <param name="Customerid"></param>
        /// <returns>Returns Customer Mood Details</returns>
        public async Task<CustomerMoodDetailsDTO> GetCustomerMoodDetails(int CustomerId)
        {
            DataTable CustomerMoodDetailsTable = new DataTable();

            string ConnectionString = Configuration.GetConnectionString("AccountPlanning");

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@customerId", CustomerId)
            };

            CustomerMoodDetailsTable = await StoreProcedureExecution.ExecuteStoreProcedure(Constants.GetCustomerMoodDetails, ConnectionString, sqlParameters);
                       

            return CustomerMoodDetailsMapper.GetCustomerMoodDetailsDTO(CustomerMoodDetailsTable);
        }


        public async Task<CustomerFinancialHealthDTO> UpdateCustomerFinancialHealth(int CustomerId, int customerFinancialHealthDTO, List<QuestionnaireDTO> questions)
        {
            //var customerFinancialHealth = CustomerFinancialHealthMapper.GetCustomerFinancialHealth(customerFinancialHealthDTO); // _mapper.Map<CustomerInfoTable>(customerFinancialHealthDTO);
            var customerDetails = await _AccountPlanningContext.CustomerBusinessInfo.FindAsync(CustomerId);
            IQueryable<CustomerQuestionnaire> questionsList = _AccountPlanningContext.CustomerQuestionnaire.Where(t => t.CustomerId == CustomerId);

            var history = new HealthHistory();
            history.CustomerId = CustomerId;
            history.HealthTypeId = (int)HealthType.FinancialHealth;
            history.HealthValue = customerFinancialHealthDTO;
            history.UpdatedDateTime = System.DateTime.Now;
            _AccountPlanningContext.HealthHistory.Add(history);

            if (questionsList.ToList().Count == 0)
            {
                for(int i =1; i<=10; i++)
                {
                    var newQuestion = new CustomerQuestionnaire
                    {
                        CustomerId = CustomerId,
                        QuestionId = i,
                        CreatedBy = "SystemUser",
                        CreatedDate = DateTime.Now
                    };
                    questionsList.ToList().Add(newQuestion);
                }

            }

            if (customerDetails == null)
            {
                return null;
            }
            else
            {
                foreach (QuestionnaireDTO question in questions)
                {
                    questionsList.Where(item => item.QuestionId == question.QuestionId).FirstOrDefault().Points = question.SelectedPoints;
                }
                customerDetails.FinancialHealth = customerFinancialHealthDTO;
                await _AccountPlanningContext.SaveChangesAsync();
                return CustomerFinancialHealthMapper.GetCustomerFinancialHealthDTOFromCustomerTable(await _AccountPlanningContext.CustomerBusinessInfo.FirstOrDefaultAsync(cbi => cbi.Id == CustomerId));
            }

        }
        public async Task<CustomerTeamInfoDTO> UpdateCustomerTeamInfo(int CustomerId, CustomerTeamInfoDTO customerTeamInfoDTO)
        {
            var customerTeamInfo = CustomerTeamInfoMapper.GetCustomerTeamInfo(customerTeamInfoDTO);

            var customerDetails = await _AccountPlanningContext.CustomerTeamInfo.FindAsync(CustomerId);

            if (customerDetails == null)
            {
                customerTeamInfo.Id = CustomerId;                

                await _AccountPlanningContext.AddAsync(customerTeamInfo);
                await _AccountPlanningContext.SaveChangesAsync();
                return CustomerTeamInfoMapper.GetCustomerTeamInfoDTOFromCustomerTable(await _AccountPlanningContext.CustomerTeamInfo.FirstOrDefaultAsync(cbi => cbi.Id == CustomerId));
                
            }
            else
            {
                //  customerDetails.ClientPartnerId = customerTeamInfoDTO.ClientPartner;
                customerDetails.ClientPartnerName = customerTeamInfoDTO.ClientPartnerName;
                customerDetails.DeliveryManagerId = customerTeamInfoDTO.DeliveryManager;
                customerDetails.DeliveryModel = customerTeamInfoDTO.DeliveryModel;
                //customerDetails.Timezone = customerTeamInfoDTO.Timezone;
                customerDetails.OnshoreResources = customerTeamInfoDTO.OnshoreResources;
                customerDetails.OffshoreResources = customerTeamInfoDTO.OffshoreResources;
                customerDetails.NearShoreResources = customerTeamInfoDTO.NearShore;

                await _AccountPlanningContext.SaveChangesAsync();
                return CustomerTeamInfoMapper.GetCustomerTeamInfoDTOFromCustomerTable(await _AccountPlanningContext.CustomerTeamInfo.FirstOrDefaultAsync(cbi => cbi.Id == CustomerId));
            }

        }


        /// <summary>
        /// To Update the Customer Business Information by using Customer Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        // public async Task<DataTable> UpdateCustomerBusinessInformation(int CustomerId)
        public async Task<CustomerBusinessInfoDTO> UpdateCustomerBusinessInformation(int CustomerId, CustomerBusinessInfoDTO customerBusinessInfoDTO)

        {
            var customerInfoTable = CustomerBusinessInfoMapper.GetCustomerInfoTable(customerBusinessInfoDTO);  //_mapper.Map<CustomerInfoTable>(customerBusinessInfoDTO);
            var businessDetails = await _AccountPlanningContext.CustomerBusinessInfo.FirstOrDefaultAsync(x => x.Id == CustomerId);
            if (businessDetails != null)
            {
                //customerInfoTable.ApplyTo(result);
                //businessDetails.Id = customerBusinessInfoDTO.CustomerId;
                businessDetails.Website = customerInfoTable.Website;
                businessDetails.IndustryId = customerInfoTable.IndustryId;
                businessDetails.CompanySize = customerInfoTable.CompanySize;
                businessDetails.HeadQuarters = customerInfoTable.HeadQuarters;
                businessDetails.Speciality = customerInfoTable.Speciality;
                businessDetails.ServicesOffered = customerInfoTable.ServicesOffered;
                businessDetails.TechStack = customerInfoTable.TechStack;
                businessDetails.TimeZoneId = customerInfoTable.TimeZoneId;
                businessDetails.ModifiedBy = customerInfoTable.ModifiedBy;
                businessDetails.ProjectEndDate = customerInfoTable.ProjectEndDate;
                businessDetails.ModifiedOn = customerInfoTable.ModifiedOn;
                await _AccountPlanningContext.SaveChangesAsync();
                return CustomerBusinessInfoMapper.GetCustomerBusinessDTOFromCustomerTable(await _AccountPlanningContext.CustomerBusinessInfo.FirstOrDefaultAsync(x => x.Id == CustomerId));
            }
            else
            {
                customerInfoTable.CSAT = 1;
                customerInfoTable.CSATComments = "";
                customerInfoTable.CustomerMood = 1;
                customerInfoTable.EngagementHealth = 89;
                customerInfoTable.FinancialHealth = 60;
                await _AccountPlanningContext.CustomerBusinessInfo.AddAsync(customerInfoTable);
                await _AccountPlanningContext.SaveChangesAsync();
                var x = await _AccountPlanningContext.CustomerBusinessInfo.MaxAsync(y => y.Id);
                return CustomerBusinessInfoMapper.GetCustomerBusinessDTOFromCustomerTable(await _AccountPlanningContext.CustomerBusinessInfo.FirstOrDefaultAsync(y => y.Id == x));
            }

        }

        public async Task<CSATDetailsDTO> UpdateCSATDetails(int CustomerId, CSATDetailsDTO csatDetailsDTO)
        {
            var CSATDetails = CSATDetailsMapper.GetCSATDetails(csatDetailsDTO);

            var csatDetails = await _AccountPlanningContext.CustomerBusinessInfo.FirstOrDefaultAsync(x => x.Id == CustomerId);

            if (csatDetails != null)
            {
                csatDetails.CSAT = CSATDetails.CSATNumber;
                csatDetails.CSATComments = CSATDetails.CSATComments;
               
                await _AccountPlanningContext.SaveChangesAsync();
                return CSATDetailsMapper.GetCSATDetailsDTOFromCustomerTable(await _AccountPlanningContext.CustomerBusinessInfo.FirstOrDefaultAsync(x => x.Id == CustomerId));
            }
            else
            {
                return null;
            }
        }

  /*      public async Task<List<EngagementHealthHealthIndicatorDTO>> AddOrUpdateEngagementHealthQuestionnaires(int CustomerId, List<EngagementHealthHealthIndicatorDTO> engagementHealthHealthIndicatorDTOs)
        {
            var engagementHealthHealthIndicators = EngagementHealthHealthIndicatorMapper.GetEngagementHealthHealthIndicators(engagementHealthHealthIndicatorDTOs);

            var HealthIndicator = await _AccountPlanningContext.HealthIndicator.FirstOrDefaultAsync(c => c.CustomerId == CustomerId);

            if(HealthIndicator == null)
            {
                foreach (var engagementHealthIndicator in engagementHealthHealthIndicators)
                {
                    await _AccountPlanningContext.HealthIndicator.AddAsync(engagementHealthIndicator);
                    
                }
                await _AccountPlanningContext.SaveChangesAsync();
            }
            else
            {
                foreach (var engagementHealthIndicator in engagementHealthHealthIndicators)
                {
                    HealthIndicator = await _AccountPlanningContext.HealthIndicator.FirstOrDefaultAsync(c => c.CustomerId == CustomerId && c.questionId == engagementHealthIndicator.questionId);

                    HealthIndicator.A = engagementHealthIndicator.A;
                    HealthIndicator.B = engagementHealthIndicator.B;
                    HealthIndicator.C = engagementHealthIndicator.C;
                    HealthIndicator.D = engagementHealthIndicator.D;
                }
                await _AccountPlanningContext.SaveChangesAsync();
            }

            return EngagementHealthHealthIndicatorMapper.GetEngagementHealthHealthIndicatorDTOs(engagementHealthHealthIndicators);

        }*/



        //public async Task<List<FinancialHealthHealthIndicatorDTO>> AddOrUpdateFinancialHealthQuestionnaires(int CustomerId, List<FinancialHealthHealthIndicatorDTO> financialHealthHealthIndicatorDTOs)
        //{
        //    var financialHealthHealthIndicators = FinancialHealthHealthIndicatorMapper.GetFinancialHealthHealthIndicators(financialHealthHealthIndicatorDTOs);

        //    var FinancialHealthIndicator = await _AccountPlanningContext.HealthIndicator.FirstOrDefaultAsync(c => c.CustomerId == CustomerId);

        //    if(FinancialHealthIndicator == null)
        //    {
        //        foreach (var financialHealthIndicator in financialHealthHealthIndicators)
        //        {
        //            await _AccountPlanningContext.HealthIndicator.AddAsync(financialHealthIndicator);
                    
        //        }
        //        await _AccountPlanningContext.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        foreach (var financialHealthIndicator in financialHealthHealthIndicators)
        //        {
        //            FinancialHealthIndicator = await _AccountPlanningContext.HealthIndicator.FirstOrDefaultAsync(c => c.CustomerId == CustomerId && c.questionId == financialHealthIndicator.questionId);

        //            FinancialHealthIndicator.A = financialHealthIndicator.A;
        //            FinancialHealthIndicator.B = financialHealthIndicator.B;
        //            FinancialHealthIndicator.C = financialHealthIndicator.C;
        //            FinancialHealthIndicator.D = financialHealthIndicator.D;
        //        }
        //        await _AccountPlanningContext.SaveChangesAsync();
        //    }

        //    return FinancialHealthHealthIndicatorMapper.GetFinancialHealthHealthIndicatorDTOs(financialHealthHealthIndicators);

        //}



    }
}



