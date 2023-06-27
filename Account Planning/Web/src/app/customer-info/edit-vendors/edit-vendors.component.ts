import { EventEmitter, Inject, Output } from '@angular/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CustomerDetailsService } from '../services/customer-details.service';
import { MatSort, Sort } from '@angular/material/sort';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatTableDataSource } from '@angular/material/table';
import { MatTable, } from '@angular/material/table';
import { DataForOverviewService } from 'src/app/shared/Services/data-for-overview.service';
import { EditSharingDataService } from 'src/app/shared/Services/edit-sharing-data.service';
import { CustomerVendors, VendorList } from '../customer-info-interface';
import { ContentObserver } from '@angular/cdk/observers';

@Component({
  selector: 'app-edit-vendors',
  templateUrl: './edit-vendors.component.html',
  styleUrls: ['./edit-vendors.component.scss']
})


export class EditVendorsComponent implements OnInit {
  serviceType: any = [];
  vendorColumnsToDisplay: string[] = ['vendorName', 'serviceType'];
  vendorsTableData :any=[];
  vendorAddedData: Array<VendorList> = [];

  @ViewChild(MatTable)
  table!: MatTable<any>;

  @Output() postedData = new EventEmitter<any>();
  columnSortCount: number = 1;
  userDetails: any;

  /**
   * 
   * @param customerDetails 
   * @param userData  fetched data from the Overview Card
   */
  constructor(customerDetails: CustomerDetailsService,
    @Inject(MAT_DIALOG_DATA) public userData: any,
    private _liveAnnouncer: LiveAnnouncer,
    private dataService : DataForOverviewService,
    public postService:EditSharingDataService
    ) {

  }

  vendorForm = new FormGroup({
    vendorName: new FormControl('', Validators.required),
    serviceType: new FormControl('', Validators.required)
  })

  ngOnInit(): void {
    if(this.userData.modalData){
    this.vendorsTableData = this.userData.modalData.vendorsData;
    }
    
    this.getServiceData()
    this.postingData()
    this.tableSort('vendorName')
  }

  postingData() {
    this.postService.stringSubject.subscribe(data => {
      this.postedData.emit(this.vendorAddedData)
    })
  }

  addVendorsData() {
    if (this.vendorForm.status === "INVALID") {
      for (const control of Object.keys(this.vendorForm.controls)) {
        this.vendorForm.controls[control].markAsTouched();
      }
    }
    else {
      this.vendorAddedData.push(this.vendorForm.value)
      this.vendorsTableData.push(this.vendorForm.value)
      this.table.renderRows();
      this.vendorForm.reset();
    }
  }

  tableSort(colNum: any) {
    this.vendorsTableData.sort((row1: any, row2: any) => {
      if (row1[colNum.active] < row2[colNum.active]) {
        return -1 * this.columnSortCount;
      }
      else if (row1[colNum.active] > row2[colNum.active]) {
        return 1 * this.columnSortCount;
      }
      return 0;
    });
    this.table != null || this.table != undefined ? this.table.renderRows():"";
    this.columnSortCount = this.columnSortCount * (-1);

  }

  getServiceData() {
    this.dataService.getVendorService().subscribe((serviceData: any) => {
      serviceData.forEach((ele: { customerService: string; }) => {
        this.serviceType.push(ele.customerService)
      })
    })
  }
}