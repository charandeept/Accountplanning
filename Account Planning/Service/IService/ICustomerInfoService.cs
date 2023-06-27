using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    public interface ICustomerInfoService
    {
        public Task<Result<List<TimeZoneBM>>> GetTimeZone();
        public Task<Result<List<ServiceLineBM>>> GetServiceLine();
        public Task<Result<List<ClientPartnerBM>>> GetClientPartner();
        public Task<Result<List<IndustryBM>>> GetIndustry();
        public Task<Result<List<CustomerServiceBM>>> GetCustomerService();
        public Task<Result<List<DeliveryModelBM>>> GetDeliveryModel();
        public Task<Result<List<HeadQuartersBM>>> GetHeadQuarters();
        public Task<Result<List<DeliveryManagerBM>>> GetDeliveryManager();

        public Task<Result<List<FinancialHealthQuestionnaireBM>>> GetFinancialHealthQuestionnaire();
        public Task<Result<List<EngagementHealthQuestionnaireBM>>> GetEngagementHealthQuestionnaire();


        public Task<Result<CustomerBusinessInfoBM>> GetCustomerBusinessInformation(int CustomerId);

        public Task<Result<CSATDetailsBM>> GetCSATDetails(int CustomerId);

        public Task<Result<List<CustomerVendorServiceBM>>> GetCustomerVendors(int customerId);

        public Task<Result<CustomerEngagementHealthBM>> GetCustomerEngagementHealth(int customerId);

        public Task<Result<List<CustomerVendorBM>>> UpdateCustomerVendorDetails(int CustomerId, List<VendorBM> vendorDetailsBM);

        //public Task<Result<CustomerEngagementHealthBM>> updateCustomerEngagementHealthDTO(int CustomerId, CustomerEngagementHealthBM customerEngagementHealthBM);

        public Task<Result<CustomerMoodDetailsBM>> UpdateCustomerMood(int CustomerId, CustomerMoodDetailsBM customerMoodBM);

        public Task<Result<ClientDetailsBM>> GetCustomerInfo(int CustomerId);

        public Task<Result<CustomerFinancialHealthBM>> GetCustomerFinancialHealth(int CustomerId);

        public Task<Result<CustomerMoodDetailsBM>> GetCustomerMoodDetails(int CustomerId);
        //public Task<Result<CustomerFinancialHealthBM>> UpdateCustomerFinancialHealthDTO(int CustomerId, CustomerFinancialHealthBM customerFinancialHealthBM);
        public Task<Result<CustomerTeamInfoBM>> UpdateCustomerTeamInfoDTO(int CustomerId, CustomerTeamInfoBM customerTeamInfoBM);
        public Task<Result<CustomerBusinessInfoBM>> UpdateCustomerBusinessInformationDTO(int CustomerId  , CustomerBusinessInfoBM customerBusinessInfoBM);
    
        public Task<Result<CSATDetailsBM>> UpdateCSATDetailsDTO(int CustomerId , CSATDetailsBM csatDetailsBM);

        public Task<Result<CustomerEngagementHealthBM>> AddOrUpdateEngagementHealthQuestionnaires(int CustomerId, List<EngagementHealthHealthIndicatorBM> engagementHealthHealthIndicatorBMs);

        public Task<Result<CustomerFinancialHealthBM>> AddOrUpdateFinancialHealthQuestionnaires(int CustomerId, List<FinancialHealthHealthIndicatorBM> financialHealthHealthIndicatorBMs);


    }
}