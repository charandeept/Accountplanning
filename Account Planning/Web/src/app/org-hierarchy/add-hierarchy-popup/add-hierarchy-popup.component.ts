import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-hierarchy-popup',
  templateUrl: './add-hierarchy-popup.component.html',
  styleUrls: ['./add-hierarchy-popup.component.scss']
})
export class AddHierarchyPopupComponent implements OnInit {
  editform= new FormGroup({
    name: new FormControl(''),
    designation: new FormControl(''),
    gender: new FormControl(''),
    kdm: new FormControl(''),
    reportsTo: new FormControl(''),
    engagementLevel: new FormControl(''),
    pmInContact: new FormControl(''),
    linkedInUrl: new FormControl(''),
    roleDescription: new FormControl(''),

  })

  constructor() { }

  ngOnInit(): void {
  }

}
