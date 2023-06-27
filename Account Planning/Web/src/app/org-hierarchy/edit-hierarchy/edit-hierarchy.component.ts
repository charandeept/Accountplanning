import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { OrgHierarchyService } from 'src/app/shared/Services/org-hierarchy.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { OrgHierarchyEditPopupComponent } from '../org-hierarchy-edit-popup/org-hierarchy-edit-popup.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { orgHierarcyEdit } from 'src/app/shared/models/org-hierarchymodel';
import { OrgHierarchyViewPopupComponent } from '../org-hierarchy-view-popup/org-hierarchy-view-popup.component';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { DeleteAlertComponent } from './delete-alert/delete-alert.component';
@Component({
  selector: 'app-edit-hierarchy',
  templateUrl: './edit-hierarchy.component.html',
  styleUrls: ['./edit-hierarchy.component.scss']
})
export class EditHierarchyComponent implements OnInit, AfterViewInit {
  employeedata: any;
  public dataSource=new MatTableDataSource<orgHierarcyEdit>()
  public displayedColumns: string[] = ['name', 'gender', 'designation', 'influencerOrKdm_Name', 'engagementLevelId', 'innovaDM_Name', 'reportsTO_Name','action'];
  ViewPopupRef: any;

  public filterForm = new FormGroup({
    operator : new FormControl('Starts with'),
    value : new FormControl('')
  });
  filter : any;
  searchText : string = '';
  public condition :any = [];
  sort : any = {ColumnName : 'Name',sortBy : 'Asc'};
  private activeColumn : string = '';
  public filterOperators: string[] = ["exactly","contains","Does not Contain","startswith","endswith"];
  public showNoDataSection: boolean= false;
  

  constructor(private hierarchydata: OrgHierarchyService, private dialog: MatDialog, private route: Router) {
  }
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  pageSize : any = 10;
  ngOnInit() {
    this.getEditHierarcyData();  
  }
  private getEditHierarcyData() {
    this.hierarchydata.getViewHierarchyelement().subscribe(data => {
      this.dataSource.data = data as orgHierarcyEdit[];
          if(this.dataSource.data.length===0){
            this.showNoDataSection=true;
          }  
    });
    
  }
  addPopup() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = "org-hierarchy-edit-popup",
      dialogConfig.width = "950px",
      dialogConfig.data = {
        dialogname: "addHierarcy",
        actionButtonText: "Create",
        titleText: "Add",
      }
    const dialogRef = this.dialog.open(OrgHierarchyEditPopupComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((status)=>{
      if(status === 'success'){
        this.UpdateDataView();
      }  
    });
  }
  editPopup(userdata: object): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = "org-hierarchy-edit-popup",
      dialogConfig.width = "950px",
      dialogConfig.data = {
        dialogname: "editHierarcy",
        actionButtonText: "Save & Update",
        titleText: "Edit",
        editdata: userdata
      }
    const dialogRef = this.dialog.open(OrgHierarchyEditPopupComponent, dialogConfig)
    dialogRef.afterClosed().subscribe((status)=>{
      if(status === 'success'){
        this.UpdateDataView();
      }  
    });
  }
  OpenViewPopup(user:any):void{
    if(!user) return; 
    this.ViewPopupRef = this.dialog.open(OrgHierarchyViewPopupComponent,{
      width:'750px',
      // height:'300px',
      panelClass:'no-padding-dialog',
      data:user
    });
    this.ViewPopupRef.afterClosed().subscribe((result:{edit:boolean,user:any}):void=>{
      if(result?.edit === true){
        this.editPopup(result.user);
      }
      this.ViewPopupRef = null;
    });
  }
  ngAfterViewInit() {
    if (this.dataSource) {
      this.dataSource.paginator = this.paginator;
    }
  }
  FilterDataSpread(event:any){
    this.activeColumn = event.target.id;
    let FormData = this.condition.find((filter:any)=>filter.ColumnName === this.activeColumn);
    this.filterForm.patchValue({
      operator: FormData?.Operator,
      value: FormData?.Value
    });
  }
  ApplyFilter(){
    if(!this.filterForm.value.operator) return;
    this.filter = this.condition.find((filter: any)=> filter.ColumnName === this.activeColumn);
    if(this.filter === undefined){
      this.condition.push({ColumnName : this.activeColumn,Operator:this.filterForm.value.operator,Value : this.filterForm.value.value})
    }else{
      this.filter.Operator = this.filterForm.value.operator;
    this.filter.Value = this.filterForm.value.value;
    }
    this.UpdateDataView();
  }
  ClearFilter(){
    this.filter = this.condition.find((filter: any)=> filter.ColumnName === this.activeColumn);
    this.condition.pop(this.filter);
    this.UpdateDataView();
  }
  ApplySort(event: any){
    this.activeColumn = event.target.id;
    this.sort = {
      ColumnName : this.activeColumn,
      sortBy : this.sort.sortBy === 'Asc' ? 'Desc' : 'Asc'};
    this.UpdateDataView();
  }
  Search(){
    this.UpdateDataView();
  }
  UpdateDataView(){
    this.hierarchydata.getFilteredHierarchyData({customerId: localStorage.getItem('accountid'),filterconditions:this.condition,searchText:this.searchText,orderColumn:this.sort.ColumnName,orderType:this.sort.sortBy}).subscribe((FilteredData: any)=>{
      this.dataSource.data = FilteredData as orgHierarcyEdit[];
      this.dataSource.paginator = this.paginator;
    })
  }
  pageChange(event: any){
    this.pageSize = event.pageSize;
  }

  deleteEmployee(employee:any){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "18%"
    dialogConfig.data = {
      name: "deleteEmployee",
      carddata: employee
    }
    const dialogRef = this.dialog.open(DeleteAlertComponent, dialogConfig)
    // console.log(employee)
    // this.hierarchydata.deleteHierarchy(employee).subscribe((data)=>{
    //   const currentUrl = this.route.url;
    //   this.route.navigateByUrl('/', { skipLocationChange: true }).then(() => {
    //     this.route.navigate([currentUrl]);
    //   });
    // })
  }
}