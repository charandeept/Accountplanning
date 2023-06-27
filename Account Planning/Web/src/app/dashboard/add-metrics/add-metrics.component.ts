import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { metricListName, metricListValues, operatorListValues, operatorSelectValue } from '../services/dashboard';
import { DashboardService } from 'src/app/shared/Services/dashboard.service';

@Component({
  selector: 'app-add-metrics',
  templateUrl: './add-metrics.component.html',
  styleUrls: ['./add-metrics.component.scss']
})
export class AddMetricsComponent implements OnInit {

  public operatorValues: any;
  public metricValues: any;
  public cardDetails: any
  public metricName: any
  public accounType: string = ''
  public cardData: any;
  public editcard: any
  public editCardData: any;
  public selected: boolean = false;

  public cardForm: FormGroup = new FormGroup({
    MetricsID: new FormControl(''),
    OperatorID: new FormControl(''),
    Value: new FormControl('')

  })
  operatorSelect: string[];

  constructor(public dialogRef: MatDialogRef<AddMetricsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, public dashboardService: DashboardService, private formBuilder: FormBuilder, private route: Router) {

    this.operatorSelect = operatorSelectValue
    this.metricName = metricListName;
    this.operatorValues = operatorListValues
    this.metricValues = metricListValues;

  }
  ngOnInit() {
    this.editCardData = this.dashboardService.editCardId
    this.createMetrics();

    setTimeout(() => {
      if (this.data.cardType === 'Edit') {
        this.setUserValues()
      }
    }, 100);
  }


  private createMetrics() {
    this.cardForm = this.formBuilder.group({
      MetricsID: [this.data.cardType === 'Edit' ? this.data?.name : '', [Validators.required]],
      OperatorID: [this.data.cardType === 'Edit' ? this.data?.operatorid : '', [Validators.required]],
      Value: [this.data.cardType === 'Edit' ? this.data?.metricvalue : '', [Validators.required]]
    })

  }

  setUserValues() {
    let temp: string = "";
    this.accounType = this.data.cardType;
    switch (this.data.cardData.operatorid) {
      case '>': temp = "More than";
        break
      case '<': temp = "Less than";
        break
      default: temp = "Equal to";
    }
    if (this.accounType === "Edit") {
      this.cardForm.patchValue({
        MetricsID: this.data.cardData.name,
        OperatorID: temp,
        Value: this.data.cardData.metricvalue
      });
    }
  }

  onNoClick() {
    this.dialogRef.close();
  }

  modalAction(modalData: any) {
    switch (modalData.name) {
      case "addMetric":
        this.submit();
        break;

      case "editMetric":
        this.editData();
        break;

      default:
        break;
    }
  }

  submit() {
    if (this.cardForm.invalid) {
      for (const control of Object.keys(this.cardForm.controls)) {
        this.cardForm.controls[control].markAsTouched();
      }
    }
    else {
      this.cardData = this.cardForm.value
      this.cardData.Id = 0
      this.cardData.UserID = 4
      this.dashboardService.createCard(this.cardForm.value);
      this.submitValuesSet();
      this.dashboardService.createCard(this.cardData).subscribe(response => {
        console.log(this.cardData);
        console.log(response);
        if(!response){
          alert("Metric already exists on the board")
        }
      })
      this.dialogRef.close();
      this.reloadCurrentRoute()   
     }
  }

  public editData() {

    this.editcard = this.cardForm.value
    this.editcard.UserID = 4
    this.editcard.Id = this.data.cardData.cardid
    this.editDataSetValues();
    this.dashboardService.editCardData(this.editcard).subscribe(response => {
      console.log(response);
    })
    this.dialogRef.close();
    this.reloadCurrentRoute()
  }

  reloadCurrentRoute() {
    const currentUrl = this.route.url;
      this.route.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.route.navigate([currentUrl]);
      });
  }
  private editDataSetValues() {
    if (this.editcard.MetricsID == "CSAT") {
      this.editcard.MetricsID = 1;
    }
    else if (this.editcard.MetricsID == "Customer Mood") {
      this.editcard.MetricsID = 2;
    }
    else if (this.editcard.MetricsID == "Engagement Health") {
      this.editcard.MetricsID = 3;
    }
    else {
      this.editcard.MetricsID = 4;
    }
    if (this.editcard.OperatorID == "More than") {
      this.editcard.OperatorID = 1;
    }
    else if (this.editcard.OperatorID == "Less than") {
      this.editcard.OperatorID = 2;
    }
    else {
      this.editcard.OperatorID = 3;
    }
    if (this.editcard.MetricsID == 2) {
      if (this.editcard.Value == "Bad") {
        this.editcard.Value = 1;
      }
      else if (this.editcard.Value == "Good") {
        this.editcard.Value = 2;
      }
      else if (this.editcard.Value == "Excellent") {
        this.editcard.Value = 3;
      }
    }
    else {
      this.editcard.Value = Number(this.editcard.Value);
    }
  }

  private submitValuesSet() {
    if (this.cardData.MetricsID == "CSAT") {
      this.cardData.MetricsID = 1;
    }
    else if (this.cardData.MetricsID == "Customer Mood") {
      this.cardData.MetricsID = 2;
    }
    else if (this.cardData.MetricsID == "Engagement Health") {
      this.cardData.MetricsID = 3;
    }
    else {
      this.cardData.MetricsID = 4;
    }
    if (this.cardData.OperatorID == "More than") {
      this.cardData.OperatorID = 1;
    }
    else if (this.cardData.OperatorID == "Less than") {
      this.cardData.OperatorID = 2;
    }
    else {
      this.cardData.OperatorID = 3;
    }
    if (this.cardData.MetricsID == 2) {
      if (this.cardData.Value == "Bad") {
        this.cardData.Value = 1;
      }
      else if (this.cardData.Value == "Good") {
        this.cardData.Value = 2;
      }
      else if (this.cardData.Value == "Excellent") {
        this.cardData.Value = 3;
      }
    }
    else {
      this.cardData.Value = Number(this.cardData.Value);
    }
  }

  actionFunction() {
    console.log(this.cardForm)
    this.modalAction(this.data);
  }

  select() {
    this.selected = true;
  }
}
