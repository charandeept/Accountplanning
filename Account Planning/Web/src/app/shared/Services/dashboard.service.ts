import { HttpClient, HttpParams } from '@angular/common/http';

import { Injectable } from '@angular/core';

import { Observable, Subject } from 'rxjs';
import { UserData } from 'src/app/customer-info/customer-info-interface';

import { AccountDetails, customerlist, customerName, DashboardDTO, EnablerCard, Enablers, Filter, MetricsDTO } from 'src/app/dashboard/services/dashboard';

import { _dashboardUrl, _deleteCardUrl, _postCardUrl, _customerListUrl, _accountsUrl, _filterUrl , _searchUrl, _downloadTemplateurl, _downloadExistingUsersurl, _importUrl, _UsersUrl,_enablersUrl, _postenablerUrl, _postenablercardUrl, _deleteenablerUrl, _deleteenablercardUrl, _RolesUrl, _UpdateUserRoleUrl, _importFilterUrl} from './url.constatnts';



@Injectable({

  providedIn: 'root'

})

export class DashboardService {

  accountsData: AccountDetails[] = []

  dashBoardData: DashboardDTO[] = []

  cardId: number = 0

  postID:number = 0

  cardData: any

  deleteCardId: number = 0

  editCardId: any

  apiData:any;

  filter:any;
  search:any;


  constructor( private http:HttpClient ) { }

  private Userdata = new Subject<UserData>()

  public getUserData(): Observable<UserData>{

    return this.Userdata.asObservable();
  }

  public updateUserData(message:UserData): void {
    this.Userdata.next(message)
  }

  getAllDashboard(): Observable<DashboardDTO> {

    return this.http.get<DashboardDTO>(_dashboardUrl);

  }

  deleteCardData(cardid: any): Observable<DashboardDTO> {

    return this.http.delete<DashboardDTO>(_deleteCardUrl + cardid)

  }

  getAccounts(): Observable<AccountDetails[]> {

    return this.http.get<AccountDetails[]>(_accountsUrl + this.cardId);

  }

  editCardData(editcard:MetricsDTO): Observable<MetricsDTO>  {

    return this.http.post<MetricsDTO>(_postCardUrl+"Post",editcard);

  }

  createCard(cardData: MetricsDTO) {

    return this.http.post<MetricsDTO>(_postCardUrl +"Post", cardData)

  }

  getCustomersList(

    filters: {

      employeeID: number;

      pageNumber: number;

      rowsOfPage: number,

      sortingColumn: string,

      sortType: string

    }): Observable<customerlist> {

    let params = new HttpParams({ fromObject: filters });

    return this.http.get<customerlist>(

      _customerListUrl,

      { params }

    )

  }

  getGrid(filter:Filter): Observable<Filter>  {

    return this.http.post<Filter>(_filterUrl,filter);

  }
  getCustomerName(filters: {
    customername: string;
  }): Observable<customerName> {
    let params = new HttpParams({ fromObject: filters });
    return this.http.get<customerName>(
      _searchUrl,
      { params }
    )}
     getdownloadTemplate(){

      return this.http.get(_downloadTemplateurl,{responseType:'blob'});
    }
    downloadExistingUsers(){
      return this.http.get(_downloadExistingUsersurl,{responseType:'blob'});
    }
    upload(file:any):Observable<any>{
      const formdata =new FormData;
      formdata.append("file",file, file.xlsx);
      return this.http.post(_importUrl, formdata)
    }
    importFilter(data:any){
      return this.http.post(_importFilterUrl,data)
    }
    getUsers(){
      return this.http.get(_UsersUrl);
    }

    getRoles() {
      return this.http.get(_RolesUrl);
    }
    UpdateUser(data: any){
      return this.http.put(_UpdateUserRoleUrl,data);
    }
    getenablers(){
      return this.http.get(_enablersUrl);
    }

    getPostID(postID:any){
      this.postID = postID
    }
    
    postenabler(enabler:Enablers): Observable<Enablers>{
      return this.http.post<Enablers>(_postenablerUrl+this.postID, enabler)
    }

    postenablercard(enablercard:EnablerCard): Observable<EnablerCard>{
      return this.http.post<EnablerCard>(_postenablercardUrl+this.postID , enablercard)
    }

    deleteenabler(cardId:any): Observable<Enablers>{
      return this.http.delete<Enablers>(_deleteenablerUrl+cardId)
    }
    deleteenablercard(cardId:any): Observable<EnablerCard>{
      return this.http.delete<EnablerCard>(_deleteenablercardUrl+cardId)
    }
}
