import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerInfoHttpUtilitiyService } from './customer-info-http-utilitiy.service';
import { Observable, Subject } from 'rxjs';
import { CSATDetails, CustomerVendors } from 'src/app/customer-info/customer-info-interface';
import { CustomerInfo } from './url.constatnts';
import { TileStyler } from '@angular/material/grid-list/tile-styler';
import { CustomerInfoComponent} from '../../customer-info/customer-info.component'
@Injectable({
    providedIn: 'root',
    // providers: [CustomerInfoComponent]
})
export class DataForOverviewService {
    getUrl = "assets/data.json";
    customerRequestedId:any;
    customerId=0
    postCustomerId:number=0;

    public postId=new Subject();
    
    constructor(
        private httpUtility: CustomerInfoHttpUtilitiyService,
        private http: HttpClient) {
    }

    getcustomerRequestedId(){
        return this.customerRequestedId;
    }

    updatecustomerRequestedId(customerId:number){
        this.customerRequestedId=customerId;
        // this.customerInfo.getApiData()
        console.log(this.customerRequestedId)
    }
    getEngagementHealthQuestionnaire():Observable<any>{
        return this.httpUtility.get(CustomerInfo.get.engagementHealthQuestionnaire)
    }

    getFinancialHealthQuestionnaire(): Observable<any> {
        return this.httpUtility.get(CustomerInfo.get.financialHealthQuestionnaire )
    }

    getVendorsData():Observable<any> {
        return this.httpUtility.get(CustomerInfo.get.vendorsData+this.customerRequestedId);
    }

    getBussinessOverviewData() :Observable<any> {

        return this.httpUtility.get(CustomerInfo.get.bussinessOverviewData+this.customerRequestedId)
    }
    
    getTeamInfoData() :Observable<any> {
        return this.httpUtility.get(CustomerInfo.get.teamInfoData+this.customerRequestedId)
    }

    getCsatData() :Observable<any> {
        return this.httpUtility.get(CustomerInfo.get.csatData+this.customerRequestedId)
    }

    getFinancialHealthData():Observable<any> {
        return this.httpUtility.get(CustomerInfo.get.financialHealthData+this.customerRequestedId)
    }

    getEnagmentHealthData() :Observable<any> {
        return this.httpUtility.get(CustomerInfo.get.engagmentHealthData+this.customerRequestedId)
    }
    getCustomerMood() :Observable<any>{
        return this.httpUtility.get(CustomerInfo.get.customerMoodData+this.customerRequestedId)
    }
    getDropDown(): Observable<any> {
        return this.http.get(this.getUrl);
    }
    getDeliveryModel(): Observable<any> {
        return this.httpUtility.get(CustomerInfo.get.deliveryModelDropDown)
    }
    getServiceLine(): Observable<any> {
        return this.httpUtility.get(CustomerInfo.get.ServiceLineDropDown)
    }
    getIndustryDropDown():Observable<any>{
        return this.httpUtility.get(CustomerInfo.get.industryDropDown)
    }
    getDeliveryManagerDropDown():Observable<any>{
        return this.httpUtility.get(CustomerInfo.get.deliveryManagerDropDown)
    }
    getTimeZoneDropDown():Observable<any>{
        return this.httpUtility.get(CustomerInfo.get.timeZoneDropDown)
    }
    getVendorService():Observable<any>{
        return this.httpUtility.get(CustomerInfo.get.vendorServiceDropDOwn)
    }
    getClientPartner():Observable<any>{
        return this.httpUtility.get(CustomerInfo.get.clientPartnerDropDown)
    }
    postBussinessOverview(bussinessOverviewData:any){
        this.customerId=bussinessOverviewData.customerId
        
        return this.httpUtility.post(CustomerInfo.post.UpdateCustomerBusinessInformation+this.customerId,bussinessOverviewData)
    }
    gettingPostId(id:any){
        this.postCustomerId=id
    }
    postTeamInfoData(teamInfoData:any){  
        return this.httpUtility.post(CustomerInfo.post.UpdateCustomerInfo+this.postCustomerId,teamInfoData)
    }
    postVendorData(vendorObject:CustomerVendors){
        
        return this.httpUtility.post(CustomerInfo.post.UpdateCustomerVendorDetails+this.postCustomerId,vendorObject)
    }
    postCsatDetails(csatData:CSATDetails){
        return this.httpUtility.post(CustomerInfo.post.UpdateCSATDetails+this.postCustomerId,csatData)
    }
    postCustomerMoodData(customerMood:any){
        return this.httpUtility.post(CustomerInfo.post.UpdateCustomerMood+this.postCustomerId,customerMood)
    }
    postFinancialHealth(financialHealthData:any){
        return this.httpUtility.post(CustomerInfo.post.UpdateCustomerFinancialHealth+this.postCustomerId,financialHealthData)
    }
    postEngagmentHealth(engagmentHealth:any){
        return this.httpUtility.post(CustomerInfo.post.UpdateCustomerEngagmentHealth+this.postCustomerId,engagmentHealth)
    }
} 