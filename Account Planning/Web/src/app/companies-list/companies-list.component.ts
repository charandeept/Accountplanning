import {  Component, OnInit, ViewChild,AfterViewInit} from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

import { catchError, map, of, Subscription } from 'rxjs';
import { MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { EditModalComponent } from '../customer-info/edit-modal/edit-modal.component';
import { UpperCasePipe } from '@angular/common';
import { DashboardService } from '../shared/Services/dashboard.service';
import { CustomerInfoComponent } from '../customer-info/customer-info.component';
import { UserData } from '../customer-info/customer-info-interface';
import { TileStyler } from '@angular/material/grid-list/tile-styler';
import { DataForOverviewService } from '../shared/Services/data-for-overview.service';
import { AuthService } from '../@core';
import { role } from '../shared/enums/role.enum';
import { NavBarService } from '../shared/components/nav-bar/nav-bar.service';
import { NavMenuModel } from '../shared/components/nav-bar/models/nav-menu.model';
import { NavBarComponent } from '../shared/components/nav-bar/nav-bar.component';



@Component({
  selector: 'app-companies-list',
  templateUrl: './companies-list.component.html',
  styleUrls: ['./companies-list.component.scss'],
  providers: [UpperCasePipe,CustomerInfoComponent,NavBarComponent]
})
export class CompaniesListComponent implements OnInit,AfterViewInit {
  public dataSource: any;
  public userData:any;
  @ViewChild(MatSort)
  public sort: MatSort = new MatSort;
  @ViewChild(MatPaginator)

  public paginator!: MatPaginator;
  public displayedColumns: string[] = ['customerName', 'createdOn', 'modifiedBy', 'modifiedOn', 'action'];
  public dataSource$: any;
  public pageTotal!: number;
  public pageSizeValues:number[]=[5,10,15,20];
  public params: any;
  public loadingComponent: boolean = true;
  public filterOperators: string[] = ["Is exactly","Contains","Does not contain","Starts with","Ends with"]
  public filter: any;
  public isVisible:boolean = false;
  public filters: any;
  public columnName: any;
  public operator: any
  public dummy: any;
  public UserId: any;
  public popup:boolean = true;
  public subscription:any = Subscription;
  public user:any;
  public isDM:any;
  public UserEmail:any;
  public load:boolean = false;

  UserRoleId: any;
  constructor(private _service: DashboardService, public matdialog: MatDialog,
    private toUpperCase: UpperCasePipe,private customerInfoComponent:CustomerInfoComponent,private data:DataForOverviewService,
    private _authService:AuthService, private navservice:NavBarService, private navBarComponent: NavBarComponent
  ) {
    this.filters = [{filter : {}}]
    this.filter = {

        "userId": 1,
        "columnName": "",
        "operator": "",
        "value": ""
    };
    this.isDM = role.isL1;
    this.params = {
    }
  }
  ngAfterViewInit(): void {

  }
  pageChange($event: any) {
    this.params = {
      ...this.params,
      pageNumber: $event.pageIndex + 1,
      rowsOfPage: $event.pageSize,
    }
    this.getListofCustomer()
  }
  applySort($event: any) {
    if ($event.active == "customerName") {
      $event.active = 'CBI.name'
    }
    else if ($event.active == "createdOn") {
      $event.active = 'CBI.createdOn'
    }

    else if ($event.active == "modifiedOn") {
      $event.active = 'CBI.ModifiedOn'
    }
    else {
      $event.active = 'CBI.UpdatedBy'
    }

    this.params = {
      ...this.params,
      sortingColumn: $event.active,
      sortType: this.toUpperCase.transform($event.direction)
    }
    this.getListofCustomer()
  }

  ngOnInit() {
    this.user = this._authService.getUserInfo();
    this.subscription = this._service.getUserData().subscribe(msg => this.userData = msg)
    this.getUserId()

  }
  ngOnDestroy(){

    this.subscription.unsubscribe(); // onDestroy cancels the subscribe request
  }
  getUserId(){
    this.UserId = this.user[0].userId;
    this.UserEmail = this.user[0].userEmail;
    this.UserRoleId = this.user[0].userRoleId
    this.params = {
      ...this.params,
      userId : this.UserId,
      userRoleId: this.UserRoleId,
      UserEmail: this.UserEmail,
    }
    this.filter = {
      ...this.filter,
      'userId': this.UserId
    }

    this.getListofCustomer();
    this.showButton();
    // this.getGrid();
  }

  openPopup(element:any){
    this.load = true
    this.data.updatecustomerRequestedId(element.customerId)
    this.customerInfoComponent.getApiData();
    localStorage.setItem('accountid',element.customerId)
    setTimeout(() => {
    this.subscription = this._service.getUserData().subscribe(msg => this.userData = msg)
    const dialogConfig = new MatDialogConfig();
      dialogConfig.maxWidth = '80vw',
      dialogConfig.maxHeight = '90vh',
      dialogConfig.height = '100%',
      dialogConfig.width = "100%"
      dialogConfig.data = {
      modalData: this.userData,
      name: "editModal",
      actionButtonText: "Save & Update",
      modalType: "Edit"
    }
    const dialogRef = this.matdialog.open(EditModalComponent, dialogConfig)
    this.load = false
  }, 3000);
  }

  getListofCustomer() {

    this.dataSource$ = this._service.getCustomersList(this.params).pipe(
      map((data: any) => {
        this.data.updatecustomerRequestedId(data[0].customerId)
        localStorage.setItem('accountid',data[0].customerId);
        localStorage.setItem('accountName',data[0].customerName);
        // this.navservice.getNavMenu(data[0].customerId).subscribe((menu: NavMenuModel) => {
        // })
        console.log(data)
        return data;
      }),
      catchError(() => {
        this.pageTotal = 0;
        return of(null);
      })
    );
  }
  getAccountId(element : any){
    this.data.updatecustomerRequestedId(element.customerId)
    localStorage.setItem('accountid',element.customerId);
    localStorage.setItem('accountName',element.customerName);
  }

  addOpenPopup() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = "edit-modal",
      dialogConfig.maxWidth = '80vw',
      dialogConfig.maxHeight = '90vh',
      dialogConfig.height = '100%',
      dialogConfig.width = "100%"
      dialogConfig.data = {
      name: "addModal",
      actionButtonText: "Create",
      modalType: "Add"
    }
    const dialogRef = this.matdialog.open(EditModalComponent, dialogConfig)

  }

  getColumnName($event:any){
    this.columnName = $event.target.id
  }

  gridFilter($event: any){
    this.filter = {
      ...this.filter,
      "columnName": 'customerName',
      "operator": 'contains',
      "value": $event.target.value
    }
    this.filters = [
      this.filter
    ]
    console.log(this.filters)
    this.get();
  }
  onFormSubmit(filters:any):void{
    console.log(filters.value)

    if(filters.value.operator == "Contains"){
      this.operator = "contains"
    }

    else if(filters.value.operator == "Is exactly"){
      this.operator = "exactly"
    }
    else if(filters.value.operator == "Does not contain"){
      this.operator = "does not contain"
    }

    else if(filters.value.operator == "Starts with"){
      this.operator = "startswith"

    }
    else{
      this.operator = "endswith"

    }
    this.filter = {
      ...this.filter,
      "columnName": this.columnName,
      "operator": this.operator,
      "value": filters.value.value
    }
    this.filters = [
      this.filter
    ]

    this.get();
  }
  clearform(){
    this.filter = {
      ...this.filter,
      "columnName": '',
      "operator": '',
      "value": ''
    }
    this.filters = [
      this.filter
    ]

    this.get();
  }

  get(){
    this.dummy = this._service.getGrid(this.filters).subscribe((data) => {
      this.dataSource$ = data["filter"]
      console.log(this.dataSource$)
    })

   }
   showButton(){
   
    if(this.user[0].userRoleId != this.isDM){
      this.isVisible = true;
    }
    else{
      this.isVisible = false;
    }
  
  }
}
