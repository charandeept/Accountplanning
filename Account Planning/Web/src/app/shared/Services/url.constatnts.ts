import { environment } from "src/environments/environment";


    export const baseUrl=environment.apiBaseUrl;
    export const designationUrl=`${baseUrl}Designation/GetAll`;
    export const kdmUrl=`${baseUrl}Influencer/GetAll`;
    export const reportTourl=`${baseUrl}CustomerUsers/`;
    export const HierarachyUrl=`${baseUrl}OrgHierarchy/`;
    export const editeddataUrl=`${baseUrl}OrgHierarchy`;
    export const FilteredHierarchyDataUrl=`${baseUrl}OrgHierarchy/FilterGrid`;
    export const engagementlevelUrl=`${baseUrl}Engagement/GetEngagementLevel`;
    export const InnovausersUrl=`${baseUrl}InnovaUser/GetAll`;
    export const _dashboardUrl=`${baseUrl}Dashboard`;

    export const _deleteCardUrl=`${baseUrl}Dashboard/Delete?id=`;
    export const _postCardUrl=`${baseUrl}Dashboard/`;
    export const _accountsUrl=`${baseUrl}Dashboard/GetServiceList?cardId=`;
    export const _customerListUrl=`${baseUrl}Dashboard/GetCustomerList/userId`;
    export const _filterUrl = `${baseUrl}Dashboard/FilterGrid`;
    export const _searchUrl = `${baseUrl}Dashboard/SearchCustomer`;
    export const _downloadTemplateurl=`${baseUrl}ImportExportDM/DownloadTemplate`;
    export const _downloadExistingUsersurl=`${baseUrl}ImportExportDM/ExportDM`;
    export const _importUrl=`${baseUrl}ImportExportDM/ImportUsers`;
    export const _UsersUrl=`${baseUrl}ImportExportDM/UsersTable`;
    export const _RolesUrl=`${baseUrl}ImportExportDM/GetUserRole`;
    export const _UpdateUserRoleUrl=`${baseUrl}ImportExportDM/AddOrEditUser`;
    export const _importFilterUrl=`${baseUrl}ImportExportDM/Filter`
    export const _enablersUrl=`${baseUrl}Enablers/GetEnablers`;
    export const _postenablerUrl=`${baseUrl}Enablers/AddorEditEnabler/`;
    export const _postenablercardUrl=`${baseUrl}Enablers/AddorEditEnablercard/`;
    export const _deleteenablerUrl=`${baseUrl}Enablers/DeleteEnabler/`;
    export const _deleteenablercardUrl = `${baseUrl}Enablers/DeleteEnablerCard/`;
    export const _deleteHeirarchyUrl = `${baseUrl}OrgHierarchy/`;
    
    export const _UserDetailsUrl = "UserDetails?emailId="

    export const CustomerInfo = {
        get: {
          vendorsData: "CustomerInfo/GetCustomerVendors/",
          bussinessOverviewData: "CustomerInfo/GetCustomerBusinessInformation/",
          teamInfoData: "CustomerInfo/GetCustomerTeamInfo/",
          csatData: "CustomerInfo/GetCSATDetails/",
          financialHealthData: "CustomerInfo/GetCustomerFinancialHealth/",
          engagmentHealthData: "CustomerInfo/GetCustomerEngagementHealth/",
          customerMoodData: "CustomerInfo/GetCustomerMoodDetails/",
          industryDropDown: "CustomerInfo/GetIndustry",
          deliveryModelDropDown: "CustomerInfo/GetDeliveryModel",
          ServiceLineDropDown: "CustomerInfo/GetServiceLine",
          deliveryManagerDropDown: "CustomerInfo/GetDeliveryManager/",
          vendorServiceDropDOwn: "CustomerInfo/GetCustomerServices/",
          timeZoneDropDown:"CustomerInfo/GetTimeZone",
          clientPartnerDropDown:"CustomerInfo/GetClientPartner",
          engagementHealthQuestionnaire:"CustomerInfo/GetEngagementHealthQuestionnaire",
          financialHealthQuestionnaire:"CustomerInfo/GetFinancialHealthQuestionnaire",
          UserDetails: "UserDetails?emailId="
        },
        post:{
          UpdateCustomerBusinessInformation : "CustomerInfo/AddOrUpdateCustomerBusinessInformation/",
          UpdateCustomerInfo:"CustomerInfo/AddOrUpadateCustomerTeamInfo/",
          UpdateCustomerVendorDetails:"CustomerInfo/AddOrUpdateCustomerVendorDetails/",
          UpdateCSATDetails:"CustomerInfo/AddOrUpdateCSATDetails/",
          UpdateCustomerMood:"CustomerInfo/AddOrUpdateCustomerMood/",
          UpdateCustomerFinancialHealth:"CustomerInfo/AddOrUpdateFinancialHealthQuestionnaires/",
          UpdateCustomerEngagmentHealth:"CustomerInfo/AddOrUpdateEngagementHealthQuestionnaires/"
        }
      }
    export const Opportunites={
      get:{
        opportunitiesList: "Opportunities/GetOpportunities/",
        categoryDetails:"Opportunities/GetCategoryDetails"
      },
      post:{
        opportunitiesList:"Opportunities/AddOrUpadateOpportunities/"
      }
    }