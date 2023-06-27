import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/@core';
import { DashboardService } from 'src/app/shared/Services/dashboard.service';

@Component({
  selector: 'app-create-enabler-sections',
  templateUrl: './create-enabler-sections.component.html',
  styleUrls: ['./create-enabler-sections.component.scss']
})
export class CreateEnablerSectionsComponent implements OnInit {
  public cardForm: FormGroup = new FormGroup({
    title: new FormControl(''),
    authorName: new FormControl(''),
    link: new FormControl('')

  })
  cardData: any;
  user: any;
  cardID: any;

  constructor(private formBuilder: FormBuilder,public dialogRef: MatDialogRef<CreateEnablerSectionsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, private route: Router,private _authService: AuthService,private _service: DashboardService) { }

  ngOnInit(): void {
    this.user = this._authService.getUserInfo();
    this.createEnabler()
  }

  private createEnabler() {
    this.cardForm = this.formBuilder.group({
      title: [this.data.cardType === 'Edit' ? this.data.carddata.title : ''],
      authorName: [this.data.cardType === 'Edit' ? this.data.carddata.authorName : ''],
      link: [this.data.cardType === 'Edit' ? this.data.carddata.link : '']
    })
  }

  modalAction(modalData: any) {
    switch (modalData.name) {
      case "addLink":
        this.submit();
        break;

      case "editLink":
        this.edit();
        break;

      default:
        break;
    }
  }

  reloadCurrentRoute() {
    const currentUrl = this.route.url;
      this.route.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.route.navigate([currentUrl]);
      });
  }

  submit(){
    this.cardData = this.cardForm.value
    this.cardData.customerId = 1
    this.cardData.enablerTypeId = this.data.carddata.id
    this.cardID = 0
    this._service.getPostID(this.cardID)
    this._service.postenablercard(this.cardData).subscribe((data)=>{
      this.reloadCurrentRoute()
      this.dialogRef.close()
    })
  }

  edit(){
    this.cardData = this.cardForm.value
    this.cardData.customerId = 1
    this.cardData.enablerTypeId = this.data.carddata.enablerTypeId
    this.cardID = this.data.carddata.id
    this._service.getPostID(this.cardID)
    this._service.postenablercard(this.cardData).subscribe((data)=>{
      this.reloadCurrentRoute()
      this.dialogRef.close()
    })
    
    
  }
  

  actionFunction() {
    this.modalAction(this.data);
    
  }
  close(){
    this.dialogRef.close()
  }

}
