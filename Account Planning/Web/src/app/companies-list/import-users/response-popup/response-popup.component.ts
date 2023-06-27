import { getTreeNoValidDataSourceError } from '@angular/cdk/tree';
import { Component, Inject, OnInit } from '@angular/core';
import {  MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'app-response-popup',
  templateUrl: './response-popup.component.html',
  styleUrls: ['./response-popup.component.scss']
})
export class ResponsePopupComponent implements OnInit {

  dataSource$!: MatTableDataSource<any>;
  displayedColumns: string[]=['emailAddress','status','message']
  constructor(@Inject(MAT_DIALOG_DATA) public data:any) { }

  ngOnInit(): void {
    this.getdata();

  }
  getdata(){
    JSON.stringify(this.data);
    this.dataSource$ = new MatTableDataSource(this.data);
    
  }

}
