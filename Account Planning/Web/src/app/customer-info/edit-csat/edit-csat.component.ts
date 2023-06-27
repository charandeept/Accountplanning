import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DataForOverviewService } from 'src/app/shared/Services/data-for-overview.service';
import { EditSharingDataService } from 'src/app/shared/Services/edit-sharing-data.service';
import { CsatRatingService } from './csat-rating.service';
@Component({
  selector: 'app-edit-csat',
  templateUrl: './edit-csat.component.html',
  styleUrls: ['./edit-csat.component.scss']
})
export class EditCSATComponent implements OnInit {
  stars = [1, 2, 3, 4, 5];
  userDetails: any = [];
  selectedRatingMessage: string = "";
  dataConsist: Boolean = false;
  selectedRating: number = 0;
  radioCommentBox: boolean = true;
  radioButtonChecked: boolean = true;
  customerServiceMessage: Array<string> = ["“Customer would like us to improve our service”", "“Customer would like us to improve our service2”",
    "“Customer is neutral”", "“Customer enjoys our service”", "“Customer enjoys our service”"]

  csatForm: FormGroup = new FormGroup({
    comments: new FormControl('', Validators.required)
  })

  @Output() postedData = new EventEmitter<any>();


  /**
   * @param csatServiceRating ="Instance of CSAT Service"
   */
  constructor(private csatServiceRating: CsatRatingService,
    @Inject(MAT_DIALOG_DATA) public userData: any, public dataservice: DataForOverviewService,
    public postService: EditSharingDataService) {
    this.defaulytFetchingData();
  }
  ngOnInit(): void {

    this.postService.stringSubject.subscribe(data => {
      this.postingCSATData()
    })
    this.byDefaulChecked()
  }

  byDefaulChecked() {
    if ((this.userData.name === 'addModal') || (this.userData.name === 'editModal' && this.userData.modalData.csatDetails.comments === '')) {
      this.radioCommentBox = false;
      this.radioButtonChecked = false;
    }
  }

  postingCSATData() {
    if (this.csatForm.invalid) {
      for (const control of Object.keys(this.csatForm.controls)) {
        this.csatForm.controls[control].markAsTouched();
      }
      this.postedData.emit(false)
    }
    else {
      this.postedData.emit({
        "csatNumber": this.selectedRating,
        "comments": this.csatForm.value.comments
      })
    }
  }

  /** integrating the datausing endpoints when the page loaded*/
  defaulytFetchingData() {
    if (this.userData.modalData) {
      this.selectedRating = this.userData.modalData.csatDetails.csatNumber;
      this.selectedRatingMessage = this.customerServiceMessage[this.selectedRating - 1];
      this.dataConsist = true;
      this.csatForm.patchValue({
        comments: this.userData.modalData.csatDetails.comments
      })

    }
    else {
      this.dataConsist = true;
    }
  }
  /**
   *  Get the selected rating by the user and storing the selected data in the service
   * @param ratingNumber :  Used to get the Rating selected by the User in the front end 
   */
  updateRating(ratingNumber: number) {
    this.selectedRating = ratingNumber;
    this.csatServiceRating.userSelectedRating = this.selectedRating;
    this.selectedRatingMessage = this.customerServiceMessage[ratingNumber - 1]
  }
  addComment() {
    this.radioCommentBox = !this.radioCommentBox
  }
}