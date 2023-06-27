import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, RequiredValidator, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { OrgHierarchyService } from 'src/app/shared/Services/org-hierarchy.service';
import { Router } from '@angular/router';




@Component({
  selector: 'app-org-hierarchy-edit-popup',
  templateUrl: './org-hierarchy-edit-popup.component.html',
  styleUrls: ['./org-hierarchy-edit-popup.component.scss'],
})

export class OrgHierarchyEditPopupComponent implements OnInit {
  editform = new FormGroup({
    name: new FormControl('',Validators.required),
    designation: new FormControl('',Validators.required),
    gender: new FormControl(''),
    kdm: new FormControl('',Validators.required),
    reportsTo: new FormControl(''),
    engagementLevel: new FormControl('',Validators.required),
    innovaDM: new FormControl(''),
    linkedInUrl: new FormControl(''),
    persona: new FormControl(),
    roleDescription: new FormControl(''),
  })
  designations: any;
  KDM: any;
  reportTo: any;
  engagementLevels: any;
  engagementType: any;
  obj: any
  innovaUsers: any;
  loader:any;

  constructor(private dialogRef: MatDialogRef<OrgHierarchyEditPopupComponent>, @Inject(MAT_DIALOG_DATA) public userdata: any,private route:Router, public orghierarchyService: OrgHierarchyService ) { }
  ngOnInit() {
    this.getAPIData();
    if (this.userdata.titleText == "Edit") {
      this.fillProfile();
    }
  }

  activateLoader(){
    this.loader=true;
  }

  getAPIData() {
    this.orghierarchyService.getreportTo().subscribe((data) => { this.reportTo = data });
    this.orghierarchyService.getKDM().subscribe((data) => this.KDM = data);
    this.orghierarchyService.getengagementLevel().subscribe((data) => this.engagementLevels = data);
    this.orghierarchyService.getInnovaUsers().subscribe((data) => this.innovaUsers = data);
  }
  updatedkdmid(data: any) {
    this.userdata.influencerKdmId;
  }

  getediteddata() {
    
    this.engagementLevels.forEach((element: any) => {
      if (element.id == this.editform.value.engagementLevel) {
        this.userdata.editdata.engagementLevel_Name = element.name;
      }
    });
    this.reportTo.forEach((element: any) => {
      if (element.id == this.editform.value.reportsTo) {
        this.userdata.editdata.reoportsTO_Name = element.name;
      }

    });
    this.innovaUsers.forEach((element: any) => {
      if (element.id == this.editform.value.innovaDmid) {
        this.userdata.editdata.innovaDM_Name = element.name;
      }
    });
    this.KDM.forEach((element: any) => {
      if (element.id == this.editform.value.kdm) {
        this.userdata.editdata.influncerOrKdm_Name = element.name;
      }
    })

    this.obj = {
      persona: this.editform.value.persona,
      id: this.userdata.editdata.id,
      influencerKdmId: parseInt(this.editform.value.kdm),
      reportsToId: parseInt(this.editform.value.reportsTo),
      innovaDmid: parseInt(this.editform.value.innovaDM),
      customerId: parseInt(this.userdata.editdata.customerId),
      influencerOrKdm_Name: this.userdata.editdata.influncerOrKdm_Name,
      engagementLevelId: parseInt(this.editform.value.engagementLevel),
      engagementLevel_Name: this.userdata.editdata.engagementLevel_Name,
      name: this.editform.value.name,
      userId: this.userdata.editdata.userId,
      linkedInUrl: this.editform.value.linkedInUrl,
      roleDescription: this.editform.value.roleDescription,
      gender: this.editform.value.gender,
      designation: this.editform.value.designation,
      innovaDM_Name: this.userdata.editdata.innovaDM_Name,
      reportsTO_Name: this.userdata.editdata.reoportsTO_Name,
      updatedAt: new Date,
      updatedBy: "" 
    };
    setTimeout(() =>{this.orghierarchyService.seteditedData(this.obj).subscribe(() =>{});
    this.dialogRef.close();
    const currentUrl = this.route.url;
    this.route.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.route.navigate([currentUrl]);
    });
    } , 3000)
    
    
  }
  fillProfile() {
    this.editform.patchValue({
      name: this.userdata.editdata.name,
      designation: this.userdata.editdata.designation,
      gender: this.userdata.editdata.gender,
      kdm: this.userdata.editdata.influencerKdmId,
      engagementLevel: parseInt(this.userdata.editdata.engagementLevelId),
      linkedInUrl: this.userdata.editdata.linkedInUrl,
      innovaDM: this.userdata.editdata.innovaDmid,
      reportsTo: this.userdata.editdata.reportsToId,
      roleDescription: this.userdata.editdata.roleDescription,
      persona: this.userdata.editdata.persona
    });
  }
  addHierarcyData() {
    console.log(this.editform.value)
    this.obj = {
      influencerKdmId: parseInt(this.editform.value.kdm),
      reportsToId: parseInt(this.editform.value.reportsTo),
      innovaDmid: parseInt(this.editform.value.innovaDM),
      engagementLevelId: parseInt(this.editform.value.engagementLevel),
      name: this.editform.value.name,
      linkedInUrl: this.editform.value.linkedInUrl,
      roleDescription: this.editform.value.roleDescription,
      gender: this.editform.value.gender,
      designation: this.editform.value.designation,
      persona: this.editform.value.persona,
      customerId: localStorage.getItem('accountid')
     
    };

    console.log(this.obj);
    this.orghierarchyService.seteditedData(this.obj).subscribe(() =>this.dialogRef.close('success'),()=>this.dialogRef.close('failed'));
  }
  modalAction(modalData: any) {
    switch (modalData.dialogname) {
      case "addHierarcy":
        this.addHierarcyData();
        break;

      case "editHierarcy":
        this.getediteddata()
        break;

      default:
        break;
    }
  }
  actionFunction() { 
    if(this.editform.valid){
       this.modalAction(this.userdata);
    }
  }
  public myError = (controlName: string, errorName: string) =>{
    if(this.editform.controls[controlName].touched){
      return this.editform.controls[controlName].hasError(errorName);
    }
      return false;
    }
}
