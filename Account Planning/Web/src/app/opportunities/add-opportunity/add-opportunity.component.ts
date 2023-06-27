import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, Inject, OnInit } from '@angular/core';
import { MatChipInputEvent } from '@angular/material/chips';
import { FormGroup, FormControl } from '@angular/forms';
import { OpportunityIntegrationMethodsService } from '../../shared/Services/opportunity-integration-methods.service';
import { opportunitiesList } from '../opportunities_interface';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { formatDate } from '@angular/common';


@Component({
  selector: 'app-add-opportunity',
  templateUrl: './add-opportunity.component.html',
  styleUrls: ['./add-opportunity.component.scss']
})

export class AddOpportunityComponent implements OnInit {

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  skills: any = [];
  opportunities: any;
  tempRoleId: number=0;
  modifiedDate = new Date();


  categoryDropDown: Array<any> = [];
  opportunityForm = new FormGroup({
    roleTitle: new FormControl(''),
    experience: new FormControl(''),
    noofRoles: new FormControl(''),
    category: new FormControl(''),
    skills: new FormControl([]),
    postedDate: new FormControl(''),
    location: new FormControl(''),
    roleDescription: new FormControl('')
  })

  constructor(private apiCalls: OpportunityIntegrationMethodsService,
    @Inject(MAT_DIALOG_DATA) public userData: any) {
    this.dropDown()
  }

  ngOnInit(): void {
    this.editFetchingDetails()
  }

  editFetchingDetails() {
    // alert(this.userData.modalData.minExperience+'-'+this.userData.modalData.maxExperience)
       if (this.userData.modalType === 'edit') {
        this.tempRoleId=this.userData.modalData.roleId
      this.opportunityForm.patchValue({
        roleTitle: this.userData.modalData.roleTitle,
        experience: this.userData.modalData.minExperience+'-'+this.userData.modalData.maxExperience,
        noofRoles: this.userData.modalData.noOfRoles,
        category: this.userData.modalData.categoryId,
        skills: this.userData.modalData.skills,
        postedDate: this.modifiedDate.toISOString(),
        location: this.userData.modalData.location,
        roleDescription: this.userData.modalData.roleDescription
      })
    }
    console.log(this.opportunityForm.value.skills);
    
  }

  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;
    // to add skills
    if ((value || '').trim()) {
      this.skills.push(value.trim());
    }
    // to Reset the input value  
    if (input) {
      input.value = '';
    }
    console.log(this.skills);
  }

  remove(skills: any): void {
    const index = this.skills.indexOf(skills);
    if (index >= 0) {
      this.skills.splice(index, 1);
    }
  }

  dropDown() {
    this.getCategoryDetails()
  }
  postOpportunityDetails() {
    this.opportunities = {
      roleId: this.tempRoleId,
      roleDescription: this.opportunityForm.value.roleDescription,
      customerId: 3,
      roleTitle: this.opportunityForm.value.roleTitle,
      categoryId: parseInt(this.opportunityForm.value.category),
      noOfRoles: parseInt(this.opportunityForm.value.noofRoles),
      skills: this.skills.toString(),
      postedDate: new Date(this.opportunityForm.value.postedDate).toISOString(),
      location: this.opportunityForm.value.location,
      isBookMarked: false,
      minExperience: parseInt(this.opportunityForm.value.experience.split("-")[0]),
      maxExperience: parseInt(this.opportunityForm.value.experience.split("-")[1]),
      opportunitiesId: 1
    }
    console.log(this.opportunities)
    this.apiCalls.postOpportunitiesList(this.opportunities,this.tempRoleId).subscribe(response => {
      console.log(response);
    });

  }
  getCategoryDetails() {
    this.apiCalls.getCategoryDetails().subscribe((categoryList: Array<any>) => {
      this.categoryDropDown = categoryList;
    })
  }

}
