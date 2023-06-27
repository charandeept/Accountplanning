using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{
    public interface ICustomerInfoRepository : IBaseRepository
	{

		public Task<List<TimeZoneDTO>> GetTimeZone();
		public Task<List<ServiceLineDTO>> GetServicesLine();
		public Task<List<ClientPartnerDTO>> GetClientPartner();
		public Task<List<IndustryDTO>> GetIndustry();
		public Task<List<CustomerServiceDTO>> GetCustomerService();
		public Task<List<DeliveryModelDTO>> GetDeliveryModel();
		public Task<List<HeadQuartersDTO>> GetHeadQuarters();
		public Task<List<DeliveryManagerDTO>> GetDeliveryManager();

		public Task<List<FinancialHealthQuestionnaireDTO>> GetFinancialHealthQuestionnaire();
		public Task<List<EngagementHealthQuestionnaireDTO>> GetEngagementHealthQuestionnaire();

		public Task<CustomerBusinessInfoDTO> GetCustomerBusinessInformation(int CustomerId);

		public Task<CSATDetailsDTO> GetCSATDetails(int CustomerId);

		public Task<List<CustomerVendorServiceDTO>> GetCustomerVendorDetails(int customerId);

		public Task<CustomerEngagementHealthDTO> GetCustomerEngagementHealth(int customerId);

		public Task<List<CustomerVendorDTO>> UpdateCustomerVendorDetails(int customerId, List<VendorDTO> vendorDetails);

		public Task<CustomerEngagementHealthDTO> UpdateCustomerEngagementHealth(int CustomerId, int customerEngagementHealth, List<QuestionnaireDTO> questions);

		public Task<CustomerMoodDetailsDTO> UpdateCustomerMood(int CustomerId, CustomerMoodDetailsDTO customerinfoTable);

		public Task<ClientDetailsDTO> GetCustomerInfo(int CustomerId);

		public Task<CustomerFinancialHealthDTO> GetCustomerFinancialHealth(int Customerid);

		public Task<CustomerMoodDetailsDTO> GetCustomerMoodDetails(int CustomerId);
		public Task<CustomerFinancialHealthDTO> UpdateCustomerFinancialHealth(int CustomerId, int customerFinancialHealth, List<QuestionnaireDTO> questions);
		public Task<CustomerTeamInfoDTO> UpdateCustomerTeamInfo(int CustomerId, CustomerTeamInfoDTO customerTeamInfo);
		public Task<CustomerBusinessInfoDTO> UpdateCustomerBusinessInformation(int CustomerId , CustomerBusinessInfoDTO customerBusinessInfo);

		public Task<CSATDetailsDTO> UpdateCSATDetails(int CustomerId, CSATDetailsDTO csatDetails);
	//	public Task<List<EngagementHealthHealthIndicatorDTO>> AddOrUpdateEngagementHealthQuestionnaires(int CustomerId, List<EngagementHealthHealthIndicatorDTO> engagementHealthHealthIndicatorDTOs);
		//public Task<List<FinancialHealthHealthIndicatorDTO>> AddOrUpdateFinancialHealthQuestionnaires(int CustomerId, List<FinancialHealthHealthIndicatorDTO> financialHealthHealthIndicatorDTOs);


	}
}


