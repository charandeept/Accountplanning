import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EditSharingDataService } from 'src/app/shared/Services/edit-sharing-data.service';

@Component({
  selector: 'app-edit-customer-mood',
  templateUrl: './edit-customer-mood.component.html',
  styleUrls: ['./edit-customer-mood.component.scss']
})
export class EditCustomerMoodComponent implements OnInit {
  activeBadRating:boolean=false
  activeGoodRating:boolean=false
  activeExcellentRating:boolean=false
  selectedRating:Number=0;
  dataConsist:boolean=false;

  userDetails: any;

  @Output() postedData = new EventEmitter<any>();

  constructor( @Inject(MAT_DIALOG_DATA) public userData: any,
  public postService:EditSharingDataService) { 
    if(userData.modalData){
    this.customerMood(userData.modalData.customermood.customerMood)
    }
    this.dataConsist=true;
  }
  ngOnInit(): void {
    this.postService.stringSubject.subscribe(data=>{
      this.postingData()
    })
  }
  postingData(){
    this.postedData.emit({"customerMood":this.selectedRating})
  }

  customerMood( rating:number){
    this.selectedRating=rating;
    this.activeBadRating=false;
    this.activeGoodRating=false;
    this.activeExcellentRating=false;
    if(rating==1){
      this.activeBadRating=true;
    }
    else if(rating==2){
      this.activeGoodRating=true;
    }
    else if(rating==3){
      this.activeExcellentRating=true;
    }
  }
}
