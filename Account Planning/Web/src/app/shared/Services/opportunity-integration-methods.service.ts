import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { opportunitiesList } from 'src/app/opportunities/opportunities_interface';
import { CustomerInfoHttpUtilitiyService } from './customer-info-http-utilitiy.service';
import { Opportunites } from './url.constatnts';

@Injectable({
  providedIn: 'root'
})
export class OpportunityIntegrationMethodsService {

  customerRequestedId:any;


  constructor(private httpUtility: CustomerInfoHttpUtilitiyService,
    private http: HttpClient) { }

  getOpportunitiesList(): Observable<any> {
    this.customerRequestedId = localStorage.getItem("accountid")
    return this.httpUtility.get(Opportunites.get.opportunitiesList+this.customerRequestedId)
  }
  
 getCategoryDetails(): Observable<any> {
    return this.httpUtility.get(Opportunites.get.categoryDetails)
  }
  postOpportunitiesList(opportunityData:opportunitiesList,id:number){
    return this.httpUtility.post(Opportunites.post.opportunitiesList+id,opportunityData)
  }
}
