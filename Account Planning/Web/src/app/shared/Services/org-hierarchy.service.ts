import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HierarachyUrl,designationUrl,kdmUrl,reportTourl,engagementlevelUrl,InnovausersUrl,editeddataUrl, FilteredHierarchyDataUrl, _deleteHeirarchyUrl } from './url.constatnts';


@Injectable({ providedIn: 'root' })
export class OrgHierarchyService {
 selectedCustomerId=localStorage.getItem('accountid');
 constructor( private http:HttpClient ) {}
  getViewHierarchyelement(){
    this.selectedCustomerId=localStorage.getItem('accountid');
    return this.http.get(HierarachyUrl +this.selectedCustomerId);
  }
  getDesignation(){
    return this.http.get(designationUrl);
  }
  getKDM(){
    return this.http.get(kdmUrl);
  }
  getreportTo(){
    this.selectedCustomerId=localStorage.getItem('accountid');
    return this.http.get(reportTourl +this.selectedCustomerId);
  }
  getengagementLevel(){
    return this.http.get(engagementlevelUrl);
  }
  getInnovaUsers(){
    return this.http.get(InnovausersUrl)
  }
  seteditedData(data:any){
    return this.http.put(editeddataUrl,data)
  }
  getFilteredHierarchyData(filteredConditions:any){
    return this.http.post(FilteredHierarchyDataUrl,filteredConditions)
  }
  deleteHierarchy(id:any){
    return this.http.delete(_deleteHeirarchyUrl+id)
  }
  

   }
