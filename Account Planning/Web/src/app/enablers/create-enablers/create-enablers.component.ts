import { Component, OnInit,Inject } from '@angular/core';
import { stringToKeyValue } from '@angular/flex-layout/extended/style/style-transforms';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Route, Router } from '@angular/router';
import { DashboardService } from 'src/app/shared/Services/dashboard.service';

@Component({
  selector: 'app-create-enablers',
  templateUrl: './create-enablers.component.html',
  styleUrls: ['./create-enablers.component.scss']
})
export class CreateEnablersComponent implements OnInit {
  public cardForm: FormGroup = new FormGroup({
    title: new FormControl(''),
  })
  cardData: any;

  constructor(public dialogRef: MatDialogRef<CreateEnablersComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, private formBuilder: FormBuilder, private route:Router , private _service:DashboardService) { }

  ngOnInit(): void {
    this.createLink()
    
  }
  private createLink() {
    this.cardForm = this.formBuilder.group({
      title: [this.data.cardType === 'Edit' ? this.data.carddata.name : ''],  
    })
  }
  modalAction(modalData: any) {
    switch (modalData.name) {
      case "addEnabler":
        this.submit();
        break;

      case "editEnabler":
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
    const cardid = 0
    this._service.getPostID(cardid)
    this.cardData = this.cardForm.value
    this._service.postenabler(this.cardForm.value).subscribe(response => {
      this.reloadCurrentRoute()
      this.dialogRef.close()
    })
    
    
  }
  edit(){
    this._service.getPostID(this.data.carddata.id)
    this._service.postenabler(this.cardForm.value).subscribe(response => { 
      this.reloadCurrentRoute()
      this.dialogRef.close()
    })
  }
  close(){
    this.dialogRef.close()
  }

}
