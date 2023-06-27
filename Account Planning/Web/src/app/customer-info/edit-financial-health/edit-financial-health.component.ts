import { Component, EventEmitter, OnInit, Output ,Inject} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DataForOverviewService } from 'src/app/shared/Services/data-for-overview.service';
import { EditSharingDataService } from 'src/app/shared/Services/edit-sharing-data.service';

@Component({
  selector: 'app-edit-financial-health',
  templateUrl: './edit-financial-health.component.html',
  styleUrls: ['./edit-financial-health.component.scss']
})
export class EditFinancialHealthComponent implements OnInit {

  fhQuestion: any;

  /** */
  fhPostingData:Array<any>;

  @Output() postedData = new EventEmitter<any>();

  financialHealthForm = new FormGroup({
    question6: new FormControl('', Validators.required),
    question7: new FormControl('', Validators.required),
    question8: new FormControl('', Validators.required),
    question9: new FormControl('', Validators.required),
    question10: new FormControl('', Validators.required)
  });


  constructor(
    public postService: EditSharingDataService,
    private apiCalls: DataForOverviewService,
    @Inject(MAT_DIALOG_DATA) public userData: any
  ) {
      this.fhPostingData=[];
  }

  ngOnInit(): void {
    this.GetFinancialHealthQuestionnaire()
    this.updateFinancialHealth()
    this.postService.stringSubject.subscribe(data => {
      this.postingData()
    })
  }

  GetFinancialHealthQuestionnaire() {
    this.apiCalls.getFinancialHealthQuestionnaire().subscribe((fhQuestion: any) => {
      this.fhQuestion = fhQuestion;
    })
  }

  updateFinancialHealth(){
    this.financialHealthForm.patchValue({
      question6: this.userData.modalData != null ||this.userData.modalData != undefined?this.userData.modalData.financialHealth.data[0].selectedPoints:0,
      question7: this.userData.modalData != null ||this.userData.modalData != undefined?this.userData.modalData.financialHealth.data[1].selectedPoints:0,
      question8: this.userData.modalData != null ||this.userData.modalData != undefined?this.userData.modalData.financialHealth.data[2].selectedPoints:0,
      question9: this.userData.modalData != null ||this.userData.modalData != undefined?this.userData.modalData.financialHealth.data[3].selectedPoints:0,
      question10:this.userData.modalData != null ||this.userData.modalData != undefined?this.userData.modalData.financialHealth.data[4].selectedPoints:0,
    })    
  }


  postingData() {
    this.fhPostingData=[]
    
    let formValue=Object.values(this.financialHealthForm.value)
   for(let i=0;i<this.fhQuestion.length;i++){
    let temp={
      "customerId": this.userData.modalData != null ||this.userData.modalData != undefined? this.userData.modalData.bussinessInformation.customerId:0,
      "questionId": this.fhQuestion[i].questionId,
      "optionA": 0,
      "optionB": 0,
      "optionC": 0,
      "optionD": 0,
    } 
    temp.optionA=Number(formValue[i])
    this.fhPostingData.push(temp)
   }
    this.postedData.emit( this.fhPostingData )
  }

}
