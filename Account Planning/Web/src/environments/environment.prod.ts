export const environment = {
  production: true,
  siteBaseUrl: "",
  apiBaseUrl: "http://172.16.0.92:8081/api/",
  ssoUrl: "https://acs-sso-accelerator.azurewebsites.net/account/login/1062?returnUrl=http://172.16.0.91:4201/sso-callback",
  LogoutEndPoint: "https://acs-sso-accelerator.azurewebsites.net/account/logout/1062?returnUrl=http://172.16.0.91:4201/",
  customerInfo: {
    get: {
      vendorsData: "CustomerInfo/GetCustomerVendors/",
      bussinessOverviewData: "CustomerInfo/GetCustomerBusinessInformation/",
      teamInfoData: "CustomerInfo/GetCustomerTeamInfo/",
      csatData: "CustomerInfo/GetCSATDetails/",
      financialHealthData: "CustomerInfo/GetCustomerFinancialHealth/",
      engagmentHealthData: "CustomerInfo/GetCustomerEngagementHealth/",
      customerMoodData: "CustomerInfo/GetCustomerMoodDetails/",
      industryDropDown: "CustomerInfo/GetIndustry",
      deliveryModelDropDown: "CustomerInfo/GetDeliveryModel/",
      deliveryManagerDropDown: "CustomerInfo/GetDeliveryManager/",
      vendorServiceDropDOwn: "CustomerInfo/GetCustomerServices/",
      timeZoneDropDown:"CustomerInfo/GetTimeZone",
      clientPartnerDropDown:"CustomerInfo/GetClientPartner",
      UserDetails: "UserDetails?emailId="
    },
    post:{
      UpdateCustomerBusinessInformation:"CustomerInfo/AddOrUpdateCustomerBusinessInformation/",
      UpdateCustomerInfo:"CustomerInfo/AddOrUpadateCustomerInfo/",
      UpdateCustomerVendorDetails:"CustomerInfo/AddOrUpdateCustomerVendorDetails/",
      UpdateCSATDetails:"CustomerInfo/AddOrUpdateCSATDetails/",
      UpdateCustomerMood:"CustomerInfo/AddOrUpdateCustomerMood/",
      UpadateCustomerFinancialHealth:"CustomerInfo/AddOrUpadateCustomerFinancialHealth/",
      UpdateCustomerEngagementHealth:"CustomerInfo/AddOrUpdateCustomerEngagementHealth/",
    }
  }
};