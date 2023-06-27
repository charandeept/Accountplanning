//#region angular imports

import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { FormControl ,FormGroup} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService, EmployeeModel } from 'src/app/@core';
import { GlobalEventManagerService } from 'src/app/@core/services/event-manager/global-event-manager.service';
import { DashboardService } from '../../Services/dashboard.service';
import { environment } from "src/environments/environment";
//#endregion angular imports

@Component({
  selector: 'app-header',
  templateUrl: './app-header.html',
  styleUrls: ['./app-header.scss']
})
export class AppHeaderComponent implements OnInit {

  //#region model properties
  public searchCustomer = new FormControl();
  public canShowNavBar: boolean = false;
  public showMenuIcon: boolean = false;
  public user: EmployeeModel = new EmployeeModel;
  public userName = "employeeName";
  showNavBar: boolean = true;
  isDisplay = false;
  title = 'accountPlanning';
  @Output() navbar = new EventEmitter(true);
  public params: any;
  dataSource$: any;
  public sel: any;
  public selection: any;
  public customerid:any;
  public cus:any;
  //#endregion model properties
  loginForm = new FormGroup({

    user:new FormControl(''),
  
    })
  //#region constructor

  constructor(private eventManager: GlobalEventManagerService, private authService: AuthService, private _service: DashboardService,
    private router: Router
    ) {
    this.params = {
      customername: ''
    }
    //  this.eventManager.subscribeEventHandler(Constant.eventCode.menuIconToggle, this.canShowMenuIcon.bind(this));
  }

  //#endregion constructor

  //#region component events

  ngOnInit() {
    this.user = this.authService.getUserInfo();
    console.log(this.user);
    this.getNames();
  }

  log($event: any) {
    this.params = {
      customername: $event.target.value
    }
    this.getNames()
  }
  displayFn(item:any){
    return item && item.customername ? item.customername : ''
  }
  getID(name:string){
    return this.dataSource$.find((customerList: { customername: any; }) => customerList.customername == name).customerid;
  }
  opt($event:any) {
    this.customerid = $event.option.value.customerid
    this.router.navigate(['/account-info',this.customerid])
  }

  getNames() {
    if (this.params.customername != "") {
      this._service.getCustomerName(this.params).subscribe((data: any) => {
        this.dataSource$ = data.customerList;
      })
    }
    else {
      this.dataSource$ = [];
    }
  }

  //#endregion component events

  //#region service calls
  //#endregion service calls

  //#region public functions/events assoaciated with UI elements

  toggleDisplay() {
    this.isDisplay = !this.isDisplay;
  }


  public logout() {
    //this.authService.onLogoutHandler();
    localStorage.clear()
    window.open(environment.LogoutEndPoint, "_self")
  }

  //#endregion public functions/events assoaciated with UI elements

  //#region private functions

  toggleNavBar() {
    this.navbar.emit(this.showNavBar = !this.showNavBar);
  }

  //#endregion private functions

}
