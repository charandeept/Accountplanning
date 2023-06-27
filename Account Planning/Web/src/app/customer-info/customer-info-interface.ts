export class CustmerBusinessInformation {
    [x: string]: any;
    "customerId": number;
    "customerName": string;
    "website": string;
    'industryId': Number;
    "industryName": string;
    "companySize": number;
    "headQuaters": string;
    "speciality": string;
    "servicesOffered": string;
    "techStack": string;
}
export class CustomerTeamInfo {
    "clientPartnerName": string;
    "clientPartner": string;
    "deliveryManagerId": Number;
    "deliveryManager": string;
    "deliveryModel": string;
    "timeZoneId": Number;
    "timezone": string;
    "onshoreResources": number;
    "offshoreResources": number;
    "nearShore": number;
}
export class CSATDetails {
    // "customerId": number;
    "csatNumber": number;
    "comments":string;
}

export class VendorList {
    "vendorName": string;
    "serviceType": string;
}

export class CustomerVendors {
    "vendorList": VendorList[];
}

export class HealthIndicators {
    "customerId": number;
    "questionId": number;
    "optionA": number;
    "optionB": number;
    "optionC": number;
    "optionD": number;
}

export class EngagmentHealth{
    'engagmentHealthList':HealthIndicators[];
}
export class FinancialHealth{
    'financialHealthList':HealthIndicators[];
}

export class CustomerMoodDetails {
    "customerMood": number;
}

export class CustomerFinancialHealth {
    "financialHealth": HealthIndicators;
}

export class CustomerEngagementHealth {
    "engagementHealth": HealthIndicators
}

export class UserData {
    "bussinessInformation": CustmerBusinessInformation;
    "teamInfo": CustomerTeamInfo;
    "csatDetails": CSATDetails;
    "vendorsData": VendorList[];
    "customermood": CustomerMoodDetails;
    "financialHealth": CustomerFinancialHealth;
    "engagmentHealth": CustomerEngagementHealth;
}