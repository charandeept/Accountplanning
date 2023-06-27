import { Component, Inject, OnInit, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AuthService } from 'src/app/@core';
import { DataForOverviewService } from 'src/app/shared/Services/data-for-overview.service';
import { EditSharingDataService } from 'src/app/shared/Services/edit-sharing-data.service';
import { CustmerBusinessInformation, CustomerTeamInfo, UserData } from '../customer-info-interface';
import { EditModalComponent } from '../edit-modal/edit-modal.component';
import { CustomerDetailsService } from '../services/customer-details.service';
import { role } from 'src/app/shared/enums/role.enum';
import { findIndex } from 'rxjs';
@Component({
  selector: 'app-edit-bussiness',
  templateUrl: './edit-bussiness.component.html',
  styleUrls: ['./edit-bussiness.component.scss']
})
export class EditBussinessComponent implements OnInit {
  public json_data: any
  public data: any;
  public user:any;
  currentDate:string='';
  isDM:any
  dataConsist: Boolean = true;

  /**
   * Used for input type=[number] tag to not enter the values in the input tag 
   */
  invalidChars = [
    "-",
    "+",
    "e",
  ];

  /** the following array store the option values in the respective array  */
  industryOption: any = [];
  deliveryModelOption: any = [];
  deliveryManagerOption: any = [];
  headquatersOption: any = [];
  timeZoneOption: any = [];
  clientPartnerOption: any = [];
  serviceLines: any = [];


  /**
   * Form Group with form Control Name in bussiness form 
   */
  bussinessForm: FormGroup = new FormGroup({
    website: new FormControl('', [Validators.required, Validators.minLength(4)]),
    timeZone: new FormControl('', Validators.required),
    industry: new FormControl('', Validators.required),
    deliveryModel: new FormControl('', Validators.required),
    companySize: new FormControl('', Validators.required),
    onshoreResources: new FormControl('', Validators.required),
    headquarters: new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Z ,]+$/)]),
    offshoreResources: new FormControl('', Validators.required),
    speciality: new FormControl('', Validators.required),
    servicesOffered: new FormControl('', Validators.required),
    techStack:new FormControl('', Validators.required),
    nearShore: new FormControl('', Validators.required),
    clientPartnerName: new FormControl('', [
      Validators.required,
      Validators.pattern('^[a-zA-Z \-\']+')
    ]),
    deliveryManager: new FormControl('', Validators.required),
    customerName: new FormControl('', Validators.required),
    projectEndDate: new FormControl('', Validators.required),
  })

  @Output() postedData = new EventEmitter<any>();
  @Output() disable = new EventEmitter<any>();

  /**
   * userData is passed in customerinfo component open popu method x  
   * Assigning data to respective option Array  
   * @param userData : "User Data consist data selected by the user in customerInfo page "
   * @param customerDetails : CustomerDetails consist of options data should display in the front end
   */
  constructor(public formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public userData: any,
    public dataService: DataForOverviewService,
    private customerDetails: CustomerDetailsService,
    public postService: EditSharingDataService, private authService:AuthService) {
    this.deliveryModelOption = this.customerDetails.deliveryModelOption;
    this.headquatersOption = this.customerDetails.headquatersOption;
    this.serviceLines = this.customerDetails.serviceLines;
    this.currentDate = new Date().toISOString().slice(0, 10);
    this.isDM = role.isL1
  }
  /**
   * UpdateProfile
   *  this method is used to call the updateprofile method  to fetch the data in the form after 1ms
   */
  ngOnInit(): void {
    this.user = this.authService.getUserInfo()
    // this.user[0].userRoleId = 1;
    this.dropDownData()
    if (this.userData.modalData) {
      this.updateProfile()
    }
    else{
      this.dataConsist=true;
    }
    this.postService.stringSubject.subscribe(data => {
      this.postIntegrationData()
    })
  }

  isDisable(){
    this.disable.emit(this.bussinessForm.invalid)
  }

  dropDownData() {
    this.getIndustry()
    this.getDeliveryManager()
    this.getTimeZone()
  }

  postIntegrationData() {
    if (this.bussinessForm.invalid) {
      for (const control of Object.keys(this.bussinessForm.controls)) {
        this.bussinessForm.controls[control].markAsTouched();
      }
      this.dataConsist = true;
      this.postedData.emit(false)
      
    }
    else {
      this.postedData.emit(this.bussinessForm.value)
    }
  }
  /**
   * this method used to fetch data in the forms when edit button is clicked in cutomer info page
   */
  updateProfile() {
    let deliveryModelTemp = 'TNM'
    let headquaterTemp = "Newyork City,USA"
    this.bussinessForm.patchValue({
      customerName: this.userData.modalData.bussinessInformation.customerName,
      website: this.userData.modalData.bussinessInformation?.website.trim(),
      industry: this.userData.modalData.bussinessInformation?.industryId,
      clientPartnerName: this.userData.modalData.teamInfo?.clientPartnerName,
      companySize: this.userData.modalData.bussinessInformation.companySize,
      onshoreResources: this.userData.modalData.teamInfo.onshoreResources,
      offshoreResources: this.userData.modalData.teamInfo.offshoreResources,
      speciality: this.userData.modalData.bussinessInformation.speciality,
      servicesOffered:this.userData.modalData.bussinessInformation.servicesOffered,
      techStack:this.userData.modalData.bussinessInformation.techStack,
      nearShore: this.userData.modalData.teamInfo.nearShore,
      timeZone: this.userData.modalData.teamInfo?.timeZoneId,
      deliveryManager: this.userData.modalData.teamInfo?.deliveryManagerId,
      headquarters: headquaterTemp,
      deliveryModel: deliveryModelTemp,
      projectEndDate: this.userData.modalData.bussinessInformation.projectEndDate.substring(0, 10),
    });
    this.dataConsist=true; 
  }
  
  /**
   * Method is used to check input type number should not contain the +,-,e in the form 
   * @param event : When ever a keypressed the method will call
   */
  numberValidation(event: any) {
    if (this.invalidChars.includes(event.key)) {
      event.preventDefault();
    }
  }
  getIndustry() {
    this.dataConsist = false;
    this.dataService.getIndustryDropDown().subscribe((industryDropDown: any) => {
      industryDropDown.forEach((ele: any) => (
        this.industryOption.push(ele)))
      this.dataConsist = true;
    })
    
  }
  getDeliveryManager() {
    this.dataConsist = false;
    this.dataService.getDeliveryManagerDropDown().subscribe((deliveryManager: any) => {
      deliveryManager.forEach((ele: any) => (
      this.deliveryManagerOption.push(ele)))
      this.dataConsist = true;
    })
    console.log(this.deliveryManagerOption)
    console.log(this.deliveryManagerOption.findIndex((s: { id: any; }) => s.id == this.user[0].userId))
    console.log(this.deliveryManagerOption.filter((obj: { id: any; }) => console.log(obj.id)))
    //myArray.filter(obj => obj.id !== idToRemove);
  }
  getTimeZone(){
    this.dataConsist = false;
    this.dataService.getTimeZoneDropDown().subscribe((timeZone: any) => {
      timeZone.forEach((ele: any) => (this.timeZoneOption.push(ele)))
      this.dataConsist = true;
    })
  }
  setDataConsist(boolean:any){
    this.dataConsist = boolean
  }
}