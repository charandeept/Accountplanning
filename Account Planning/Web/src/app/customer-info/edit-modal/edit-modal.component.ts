import { Component, Inject, OnInit, Output, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { TileStyler } from '@angular/material/grid-list/tile-styler';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/@core';
import { CompaniesListComponent } from 'src/app/companies-list/companies-list.component';
import { DataForOverviewService } from 'src/app/shared/Services/data-for-overview.service';
import { EditSharingDataService } from 'src/app/shared/Services/edit-sharing-data.service';
import { CSATDetails, CustmerBusinessInformation, CustomerEngagementHealth, CustomerFinancialHealth, CustomerMoodDetails, CustomerTeamInfo, CustomerVendors, EngagmentHealth, FinancialHealth, HealthIndicators, UserData, VendorList } from '../customer-info-interface';
import { CustomerInfoComponent } from '../customer-info.component';
import { CloseAlertComponent } from './close-alert/close-alert.component';



@Component({
  selector: 'app-edit-modal',
  templateUrl: './edit-modal.component.html',
  styleUrls: ['./edit-modal.component.scss'],
  providers: [CustomerInfoComponent]
})
export class EditModalComponent implements OnInit {
  bussinessContent: boolean = true;
  csatContent: boolean = false;
  vendorsContent: boolean = false;
  customerMoodContent: boolean = false;
  engagmentHealthContent: boolean = false;
  financialHealthContent: boolean = false;
  loader: boolean = false;
  

  /** Variables for stroing posting Data */
  csatPostingData!: CSATDetails;
  customerMoodPostingData !: CustomerMoodDetails;
  vendorData !: VendorList[];
  financialHealthPostingData !: HealthIndicators[];
  enagmentHealthPostingData !: HealthIndicators[];
  bussinessPostingData !: any;
  bussinessOverviewData !: any;
  teamInfoData !: any;
  count: number = 1;
  isDisable: boolean = true;
  displayButton: String = "Save & Next";
  isAdd:any;
  /** Date declaration */
  modifiedDate = new Date();
  industryOption: Array<any> = [];

  /**Add customer Id default */
  customerId: number = 0;
  postCustomerId: any
  customerName: any;

  activeLoader:boolean=false;
  user:any;

  constructor(
    public dialogRef: MatDialogRef<EditModalComponent>,
    @Inject(MAT_DIALOG_DATA) public userData: any
    , public postServiceTrigger: EditSharingDataService,
    public apiCalls: DataForOverviewService,
    private customerInfoComponent: CustomerInfoComponent,
    private route:Router,
    private _authService:AuthService,
    public _dialog: MatDialog
  ) {

  }

  ngOnInit() {
    // 
    // this.load = this.customerInfoComponent.load
    this.user = this._authService.getUserInfo();
    console.log(this.user[0].userId)
    if(this.userData.modalType == "Edit"){
      this.isAdd == false
      this.isDisable == false
    }
    else{
      this.isAdd = true
      this.isDisable == true
    }
    this.bussinessContent = true;

  }
  /**
 * Is used to select the tab in the modal
 * @param activeTab ="Acticvate Tab"
 */
  tabSwitch(){
    this.bussinessContent = false;
    this.csatContent = false;
    this.vendorsContent = false;
    this.customerMoodContent = false;
    this.engagmentHealthContent = false;
    this.financialHealthContent = false;
    this.count += 1
    if(this.count == 2){
      this.vendorsContent = true
    }
    else if (this.count == 3){
      this.csatContent = true;
    }
    else if (this.count == 4){
      this.customerMoodContent = true;
    }
    else if (this.count == 5){
      this.financialHealthContent = true;
    }
    else if (this.count == 6){
      this.engagmentHealthContent = true;
      this.displayButton = this.userData.actionButtonText
    }
    else{
      this.count = 1
      this.postRequest()
    }
  }
  tab(activeTab: any) {
    this.bussinessContent = false;
    this.csatContent = false;
    this.vendorsContent = false;
    this.customerMoodContent = false;
    this.engagmentHealthContent = false;
    this.financialHealthContent = false;
    if (activeTab == 'bussiness') {
      this.displayButton = "Save & Next"
      this.count = 1
      this.bussinessContent = true;
    }
    else if (activeTab == 'CSAT') {
      this.displayButton = "Save & Next"
      this.count = 3
      this.csatContent = true;
    }
    else if (activeTab == 'vendors') {
      this.displayButton = "Save & Next"
      this.count = 2
      this.vendorsContent = true;
    }
    else if (activeTab == 'customerMood') {
      this.displayButton = "Save & Next"
      this.count = 4
      this.customerMoodContent = true;
    }
    else if (activeTab == 'financialHealth') {
      this.displayButton = "Save & Next"
      this.count = 5
      this.financialHealthContent = true;
    }
    else if (activeTab == 'engagementHealth') {
      this.count = 6
      this.displayButton = this.userData.actionButtonText
      this.engagmentHealthContent = true;
    }
  }
  buttonStatus(event:any){
    this.isDisable = event
    
  }

  /*** POsting the Data into links  */
  postRequest() {
    this.postServiceTrigger.passingRequest();
    
    
    if (this.bussinessPostingData && this.csatPostingData && this.vendorData  && this.customerMoodPostingData) {
      this.activeLoader=true;
      this.customerInfoComponent.activateLoader();
      this.apiCalls.postBussinessOverview(this.bussinessOverviewData).subscribe(response => {
        this.postCustomerId = response
        this.postCustomerId = this.postCustomerId.customerId
        this.apiCalls.gettingPostId(this.postCustomerId);
      })

      setTimeout(() => {
        this.apiCalls.postTeamInfoData(this.teamInfoData).subscribe(response => {
          console.log(response)
        })

        var customerVendors = new CustomerVendors();
        customerVendors.vendorList = this.vendorData;

        this.apiCalls.postVendorData(customerVendors).subscribe(response => {
          console.log(response)
        })

        this.apiCalls.postCsatDetails(this.csatPostingData).subscribe(response => {
          console.log(response)
        })
        this.apiCalls.postCustomerMoodData(this.customerMoodPostingData).subscribe(response => {
          console.log(response)
        })

        var customerFinancialHealth = new FinancialHealth();
        customerFinancialHealth.financialHealthList = this.financialHealthPostingData;

        this.apiCalls.postFinancialHealth(customerFinancialHealth.financialHealthList).subscribe(response => {
          console.log(response)
        })

        var customerEngagementHealth = new EngagmentHealth();
        customerEngagementHealth.engagmentHealthList = this.enagmentHealthPostingData;

        this.apiCalls.postEngagmentHealth(customerEngagementHealth.engagmentHealthList).subscribe(response => {
          console.log(response)
        })
        this.dialogRef.close();
        // const currentUrl = this.route.url;
        // this.route.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        //   this.route.navigate([currentUrl]);
        // });
        this.reloadCurrentRoute();
      }, 3000);

    }
  }
  reloadCurrentRoute() {
    const currentUrl = this.route.url;
      this.route.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.route.navigate([currentUrl]);
      });
  }


  bussinessPostData(data: any) {
    this.bussinessPostingData = data;
    if (this.userData.modalType === "Edit") {
      this.customerId = this.userData.modalData.bussinessInformation.customerId
    }
    if (data) {
      this.bussinessOverviewData = {
        "customerId": this.customerId,
        "customerName": data.customerName,
        "website": data.website,
        "industryId": data.industry,
        "industryName": this.getIndustry(data.industry),
        "companySize": data.companySize,
        "headQuarters": data.headquarters,
        "speciality": data.speciality,
        "servicesOffered": data.servicesOffered,
        "techStack": data.techStack,
        "timeZoneId": data.timeZone,
        "createdBy": 1,
        "modifiedBy": this.user[0].userId,
        "modifiedOn": this.modifiedDate.toISOString(),
        "projectEndDate": data.projectEndDate,
      }
      console.log(this.user[0].userId)
      this.teamInfoData = {
        "clientPartnerName": data.clientPartnerName,
        "deliveryManager": data.deliveryManager,
        "deliveryModel": data.deliveryModel,
        "onshoreResources": data.onshoreResources,
        "offshoreResources": data.offshoreResources,
        "nearShore": data.nearShore      }
    }
    else {
      this.tab('bussiness')
    }
  }

  vendorDataPostedData(data: Array<VendorList>) {

    this.vendorData = data;
  }

  csatPostedData(data: CSATDetails) {
    
      this.csatPostingData = data;
  }
  customerMood(data: CustomerMoodDetails) {
    this.customerMoodPostingData = data;
  }
  financialHealthPostedData(data: Array<HealthIndicators>) {
    this.financialHealthPostingData = data;

  }
  enagmentHealthPostedData(data: Array<HealthIndicators>) {
    this.enagmentHealthPostingData = data;
  }


  getIndustry(id: number) {

    this.apiCalls.getIndustryDropDown().subscribe((industryDropDown: any) => {
      industryDropDown.forEach((ele: any) => {
        if (ele.id === id) {
          return ele.industry;
        }
      })
    })
  }

  alert(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "20%"
    dialogConfig.data = {
      name: "removeEnabler"
    }
    const dialogRef = this._dialog.open(CloseAlertComponent, dialogConfig)
    dialogRef.afterClosed().subscribe(result => {
      console.log('Dialog was closed.');
      // Additional logic after the dialog is closed
    });
  }

}
