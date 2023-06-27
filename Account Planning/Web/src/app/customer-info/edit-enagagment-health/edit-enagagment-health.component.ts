import { temporaryAllocator } from '@angular/compiler/src/render3/view/util';
import { Component, EventEmitter, OnInit, Output ,Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DataForOverviewService } from 'src/app/shared/Services/data-for-overview.service';
import { EditSharingDataService } from 'src/app/shared/Services/edit-sharing-data.service';

@Component({
  selector: 'app-edit-enagagment-health',
  templateUrl: './edit-enagagment-health.component.html',
  styleUrls: ['./edit-enagagment-health.component.scss']
})
export class EditEnagagmentHealthComponent implements OnInit {

  
  ehQuestion: any;

  engagmentHealthForm = new FormGroup({
    question1: new FormControl('', Validators.required),
    question2: new FormControl('', Validators.required),
    question3: new FormControl('', Validators.required),
    question4: new FormControl('', Validators.required),
    question5: new FormControl('', Validators.required)
  });

  @Output() postedData = new EventEmitter<any>();

  ehPostingData: Array<any>;

  constructor(
    public postService: EditSharingDataService,
    private apiCalls: DataForOverviewService,
    @Inject(MAT_DIALOG_DATA) public userData: any
  ) {
    this.ehPostingData=[];
  }
  ngOnInit(): void {
    this.getEngagmentHealthQuestonnarie()
    this. updateEnagagementHealth()
    this.postService.stringSubject.subscribe(data => {
      this.postingData()
    })
  }

  getEngagmentHealthQuestonnarie() {
    this.apiCalls.getEngagementHealthQuestionnaire().subscribe((ehQuestion: any) => {
      this.ehQuestion=ehQuestion;
    })
  }
  updateEnagagementHealth(){
    this.engagmentHealthForm.patchValue({
      question1: this.userData.modalData != null || this.userData.modalData != undefined?this.userData.modalData.engagmentHealth.data[0].selectedPoints:0,
      question2: this.userData.modalData != null || this.userData.modalData != undefined?this.userData.modalData.engagmentHealth.data[1].selectedPoints:0,
      question3: this.userData.modalData != null || this.userData.modalData != undefined?this.userData.modalData.engagmentHealth.data[2].selectedPoints:0,
      question4: this.userData.modalData != null || this.userData.modalData != undefined?this.userData.modalData.engagmentHealth.data[3].selectedPoints:0,
      question5: this.userData.modalData != null || this.userData.modalData != undefined?this.userData.modalData.engagmentHealth.data[4].selectedPoints:0,
    })    
  }
  postingData() {
    this.ehPostingData=[]
    
    let formValue=Object.values(this.engagmentHealthForm.value)
   for(let i=0;i<this.ehQuestion.length;i++){
    let temp={
      "customerId": this.userData.modalData != null ||this.userData.modalData != undefined?this.userData.modalData.bussinessInformation.customerId:0,
      "questionId": this.ehQuestion[i].questionId,
      "optionA": 0,
      "optionB": 0,
      "optionC": 0,
      "optionD": 0,
    } 
    temp.optionA=Number(formValue[i])
    this.ehPostingData.push(temp)
   }
    this.postedData.emit( this.ehPostingData )
  }

  
}
