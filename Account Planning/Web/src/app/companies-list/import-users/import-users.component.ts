import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DashboardService } from 'src/app/shared/Services/dashboard.service';
import { ResponsePopupComponent } from './response-popup/response-popup.component';
import { EditUserPopupComponent } from './edit-user-popup/edit-user-popup.component';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-import-users',
  templateUrl: './import-users.component.html',
  styleUrls: ['./import-users.component.scss']
})
export class ImportUsersComponent implements AfterViewInit {
  dataSource$!: MatTableDataSource<any>;
  pageSizeValues: any = [5,10,15,20];
  pageSize :number = 10;
  @ViewChild('paginator') paginator!: MatPaginator;
  ViewPopupRef: any;
  responsePopupRef: any;
  shortLink:string='';
  loading:boolean=false;
  file!:File;
  selectedFile:string='';
  errors:string='';
  public displayedColumns: string[] = ['id', 'name', 'emailAddress', 'designation', 'currentRole', 'isActive', 'modifiedBy', 'modifiedDate', 'action'];
  public filterOperators: string[] = [];
  public operator: string = "";
  public columnName: any;
  public filter: any=[];
  public filters: any={ filter:[], "searchText": null, "orderColumn": null, "orderType": null};
  public filterForm = new FormGroup({
    operator : new FormControl(''),
    value : new FormControl('')
  });
  constructor(public importlistservice: DashboardService, public dialog: MatDialog) { }

  ngAfterViewInit() 
  {
    this.importlistservice.getUsers().subscribe((response: any) => {
      this.dataSource$ = new MatTableDataSource(response);
      console.log(this.dataSource$)
      for (let index = 0; index < this.dataSource$.filteredData.length; index++) {
        if(this.dataSource$.filteredData[index].isActiveUI == "Y"){
          this.dataSource$.filteredData[index].isActiveUI = "Yes"
          this.dataSource$.filteredData[index].isActiveColor = "green"
        }
        else{
          this.dataSource$.filteredData[index].isActiveUI = "No"
          this.dataSource$.filteredData[index].isActiveColor = "red"
        }
        
      }
      this.dataSource$.paginator = this.paginator;
    });
  }

  downloadExistingUser() {
     this.importlistservice.downloadExistingUsers().subscribe(response => {
      let a = document.createElement('a');
        a.download='DmsList.xlsx';
      a.href = window.URL.createObjectURL(response);
      a.click();
    });

  }
  
  onChange(event: any) {
    this.errors='';
    this.file = event.target.files[0];
    this.selectedFile = this.file.name;
  }
  
  
  pageChange(event: any){
    this.pageSize = event.pageSize;
  }
  openAddUserPopup(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "950px"
    dialogConfig.data = {
      name: "AddUser",
      actionButtonText: "Create",
      cardType: "Add"
    }
    // const dialogRef = this.dialog.open(EditUserPopupComponent, dialogConfig)
    this.ViewPopupRef = this.dialog.open(EditUserPopupComponent, dialogConfig);
    this.ViewPopupRef.afterClosed().subscribe(() => {
      this.refreshTableView()
      this.ViewPopupRef = null;
    });

  }
  OpenEditUserPopup(user: any): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "950px"
    dialogConfig.data = {
      name: "EditUser",
      actionButtonText: "Save",
      cardType: "Edit",
      data: user
    }
    if (!user) return;
    this.ViewPopupRef = this.dialog.open(EditUserPopupComponent, dialogConfig);
    this.ViewPopupRef.afterClosed().subscribe(() => {
      this.refreshTableView()
      this.ViewPopupRef = null;
    });
  }
  search($event:any){
    this.filters["searchText"]=$event.target.value;
    this.refreshTableView()

  }
  getColumnName($event:any){
    this.columnName = $event.target.id;
    if(this.columnName == "InnovaId"){
      this.filterOperators = ["Less then", "Greater then", "Equals to", "Contains"];
    }
    if(this.columnName == "UserName"){
      this.filterOperators = ["Is exactly", "Contains", "Does not contain", "Starts with", "Ends with"];
    }
    let formdata: any={operator:'',value:''}
    this.filter.forEach((element: any)=>{
      if(element.columnName==this.columnName) formdata=element;
   });
   this.filterForm.patchValue({
    operator: formdata?.operator,
    value: formdata?.value
   })

  }
  refreshTableView(){
    this.importlistservice.importFilter(this.filters).subscribe((response: any)=>{
      this.dataSource$ = new MatTableDataSource(response);
      for (let index = 0; index < this.dataSource$.filteredData.length; index++) {
        if(this.dataSource$.filteredData[index].isActiveUI == "Y"){
          this.dataSource$.filteredData[index].isActiveUI = "Yes"
          this.dataSource$.filteredData[index].isActiveColor = "green"
        }
        else{
          this.dataSource$.filteredData[index].isActiveUI = "No"
          this.dataSource$.filteredData[index].isActiveColor = "red"
        }
        
      }
      this.dataSource$.paginator = this.paginator;
    });
  }
  applyFilter(filters:any):void{
    this.filter.push(
      {"columnName": this.columnName,
      "operator": this.filterForm.value.operator,
      "value": this.filterForm.value.value}
    );
    this.filters["filter"]=this.filter;
    this.refreshTableView();
   
  }
  applySort($event: any){
    this.filters["orderColumn"]=$event.target.id;
    this.filters["orderType"]="asc";
    this.refreshTableView();
  }
  
  removeFilter(){
    this.filter.forEach((element: any,index :any)=>{
      if(element.columnName==this.columnName) this.filter.splice(index,1);
   });
   this.refreshTableView();
  }
  
}
