namespace Com.ACSCorp.AccountPlanning.Service.Common.Contants
{
    public static class Constants
    {
        public const string GetTimeZone = "[dbo].[usp_GetTimeZonesList]";

        public const string GetServiceLines = "[dbo].[sp_Get_All_ServiceLines]";

        public const string GetClientPartner = "[dbo].[usp_GetClientPartnerList]";

        public const string GetIndustryDetails = "usp_GetIndustryDetails";

        public const string GetCustomerService = "usp_GetServicesList";

        public const string GetDeliveryModel = "[dbo].[usp_GetDeliveryModels]";

        public const string GetHeadQuarters = "";

        public const string GetDeliveryManager = "usp_GetManagersList";

        public const string GetFinancialHealthQuestionnaire = "[dbo].[usp_GetFinancialQuestionnaire]";
        
        public const string GetEngagementHealthQuestionnaire = "[dbo].[usp_GetEnagagementQuestionnaire]";

        public const string GetCustomerBusinessInformation = "[dbo].[usp_GetBusinessOverviewDetails]";

        public const string GetCSATDetails = "dbo.[usp_GetCSATDetails]";

        public const string GetCustomerVendorDetails = "[dbo].[usp_GetVendorDetails]";

        public const string GetCustomerEngagementHealth = "[dbo].[usp_GetEngagementHealthDetails]";

        public const string GetCustomerInfo = "[dbo].[usp_GetClientDetails]";

        public const string GetCustomerFinancialHealth = "[dbo].[usp_GetFHDetails]";

        public const string GetCustomerMoodDetails = "[dbo].[usp_GetCMDetails]";

        public const string UpdateCustomerInfo = "[dbo].[usp_UpdateClientDetails]";

        public const string GetHeatmap = "dbo.usp_Get_HeatMap";

        public const string SearchCustomer = "[dbo].[usp_CustomerSearch]";

        public const string GetCustomerList = "[dbo].[usp_GetCustomerListAccessFinal]";

        public const string GetAccountDetails = "[dbo].[SP_ServicesList]";

        public const string CreateMetrics = "[dbo].[usp__InsertMetricsData]";

        public const string RemoveMetrics = "[dbo].[sp__RemoveMetricsData]";

        public static string Filter = "[dbo].[usp_Filter_By_CustomerName]";

        public const string DownloadExcelDMS = "[dbo].[usp_Get_All_DM]";

        public const string GetOpportunities = "[dbo].[usp_GetOpportunities]";

        public const string GetCatalogueAwareness = "";

        public const string GetCategoryDetails = "[dbo].[usp_GetCategoryDetails]";

        public const string GetUser = "[dbo].[usp_GetUser]";

        public const string GetPainPoints = "[dbo].[usp_GetPainPoint]";

        public const string GetEnablerdetails = "[dbo].[usp_GetEnablersDetails]";
    }
}
