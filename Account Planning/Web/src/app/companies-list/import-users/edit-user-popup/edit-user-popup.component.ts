import { Component, OnInit , Inject } from '@angular/core';
import { MatDialog, MatDialogRef,MAT_DIALOG_DATA} from "@angular/material/dialog";
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DashboardService } from 'src/app/shared/Services/dashboard.service';
import { AuthService } from 'src/app/@core';
import { ResponsePopupComponent } from '../response-popup/response-popup.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-user-popup',
  templateUrl: './edit-user-popup.component.html',
  styleUrls: ['./edit-user-popup.component.scss']
})
export class EditUserPopupComponent implements OnInit {
  isChecked:boolean = false;
  roles: any;
  Note:any;
  editUser = new FormGroup({
    id: new FormControl(),
    emailAddress: new FormControl(),
    username: new FormControl('',[Validators.required]),
    designation: new FormControl('',[Validators.required]),
    isactive: new FormControl(''),
    roleId: new FormControl(''),
    modifiedBy:new FormControl(),
    modifiedOn:new FormControl()
  })
  responsePopupRef: any;
  addPopUp:any;
  errors: any;
  file: any;
  selectedFile: any;
  loading:boolean=false;
  constructor(public importlistservice: DashboardService, private authService: AuthService,private dialog:MatDialogRef<EditUserPopupComponent>, @Inject(MAT_DIALOG_DATA) public userdata: any,public _dialog: MatDialog,public route:Router) { 
    this.Note = `1. To add new users, Download the template, add the details and Upload 
                2. To Update the roles or Designation of the Users,"Download Existing Users" by 
                Clicking on the link and update their details in the Role column in the file and Upload`
    

  }

  ngOnInit(): void {
    this.importlistservice.getRoles().subscribe((roles: any)=>{this.roles = roles
      this.fillProfile();
    });
    console.log("data",this.userdata)
    
    if(this.userdata.cardType == "Add"){
      this.addPopUp = true
    }
    else{
      this.addPopUp = false
    }
  }
  fillProfile() {
    this.editUser.patchValue({
      id: this.userdata.cardType === 'Edit' ? this.userdata.data.innovaId  : '',
      emailAddress: this.userdata.cardType === 'Edit' ? this.userdata.data.userEmail : '',
      username: this.userdata.cardType === 'Edit' ? this.userdata.data.userName : '',
      designation: this.userdata.cardType === 'Edit' ? this.userdata.data.designation : '',
      isactive: this.userdata.cardType === 'Edit' ? this.userdata.data.isActive === 'true' ? 'Yes':'No' : '',
      roleId: this.userdata.cardType === 'Edit' ? parseInt(this.roles.find((role:any)=> role.name.toLowerCase() === this.userdata.data.role.toLowerCase()).userRoleId) : '',
      modifiedOn:this.userdata.cardType === 'Edit' ? this.userdata.data.modifiedDate : '',
      modifiedBy:this.userdata.cardType === 'Edit' ? this.userdata.data.modifiedBy : ''

    });
  }
  downloadTemplate() {
    this.importlistservice.getdownloadTemplate().subscribe(response => {
      let a= document.createElement('a');
      a.download='DMTEMPLATE.xlsx';
    a.href = window.URL.createObjectURL(response);
    a.click();
  });
}

  onChange(event: any) {
    this.errors='';
    this.file = event.target.files[0];
    this.selectedFile = this.file.name;
  }

  uploadfile() {
    this.loading = !this.loading;
    this.importlistservice.upload(this.file).subscribe((event: Response) => {
      if (typeof (event) === 'object') {
        this.loading = false;
      }
      this.selectedFile = '';
      this.responsePopup(event);
    },
      error => {
        if (error.status == 400) {
          console.log(error.error[0])
          this.selectedFile = '';
          this.errors=error.error[0].message;
        };

      }
)}
responsePopup(apidata: any) {
  this.responsePopupRef = this._dialog.open(ResponsePopupComponent, {
  height: 'auto',
  width: '1000px',
  maxHeight: '600px',
  data: apidata
});
// this.responsePopupRef.afterClosed().subscribe(()=>{
//   this.refreshTableView();
// })
}


  onCheckboxChange(event: any) {
    this.isChecked = event.target.checked;
    console.log(this.isChecked)
  }

  modalFunction(){
    if(this.userdata.cardType == "Add"){
      this.createUser()
    }
    else{
      if(this.userdata.cardType == "Edit"){
        this.UpdateUser()
      }
    }
  }

  UpdateUser(){
    let user: any = this.authService.getUserInfo();
    this.userdata.data = {
      ...this.userdata.data,
      userName : this.editUser.value.username,
      userRoleId : parseInt(this.editUser.value.roleId),
      designation : this.editUser.value.designation,
      isActive : this.editUser.value.isactive === 'Yes' ? true : false,
      modifiedBy : user[0].userId,
      modifiedDate : new Date().toISOString()
    }
    console.log(this.userdata.data)
    this.importlistservice.UpdateUser(this.userdata.data).subscribe((data:any)=>{console.log(data);this.reloadCurrentRoute();this.dialog.close('update')}); 
  }

  createUser(){
    if(!this.isChecked){
    let user: any = this.authService.getUserInfo();
    this.userdata.data = {
      ...this.userdata.data,
      userName : this.editUser.value.username,
      userRoleId : parseInt(this.editUser.value.roleId),
      designation : this.editUser.value.designation,
      isActive : this.editUser.value.isactive === 'Yes' ? true : false,
      modifiedBy : user[0].userId,
      modifiedDate : new Date().toISOString(),
      id:0
    }
    console.log(this.userdata.data)
    this.importlistservice.UpdateUser(this.userdata.data).subscribe((data:any)=>{console.log(data);this.reloadCurrentRoute();this.dialog.close('update')});
  }
  else{
    this.uploadfile()
    console.log("UPLOAD")
    this.dialog.close('uploaded')
  }
  }
  reloadCurrentRoute() {
    const currentUrl = this.route.url;
      this.route.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.route.navigate([currentUrl]);
      });
  }
  
}
