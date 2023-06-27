import { Component, ViewChild, ComponentRef, HostListener, OnInit, ViewContainerRef, Output } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { OrgHierarchyEditPopupComponent } from './org-hierarchy-edit-popup/org-hierarchy-edit-popup.component';
import { OrgHierarchyViewPopupComponent } from './org-hierarchy-view-popup/org-hierarchy-view-popup.component';
import { OrgHierarchyHoverViewComponent } from './org-hierarchy-hover-view/org-hierarchy-hover-view.component';
import { OrgHierarchyService } from '../shared/Services/org-hierarchy.service';



@Component({
  selector: 'app-org-hierarchy',
  templateUrl: './org-hierarchy.component.html',
  styleUrls: ['./org-hierarchy.component.scss'],
})
export class OrgHierarchyComponent {
  @Output()
  employeeDetails: any;
  apidata: any;
  employeelist: any
  updatedDate: any;
  ViewPopupRef: any;
  currentHoverElement: any;
  displayNoDataSection:boolean= false;
  selectedAccountName: any;
  selectedAccountId:any;
  noDataMessage:string='No data to display';
  isAccountSelected:boolean =true;
  employeeDetailsLength:number = 0;
  loader: boolean = true;
  private HoverComponentRef: ComponentRef<OrgHierarchyHoverViewComponent> | null = null;
  @ViewChild('popupHost', { read: ViewContainerRef }) viewContainer !: ViewContainerRef;
  
  constructor(public orgHierarchyService: OrgHierarchyService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getCustomerName();
  }


  getCustomerName(){
      this.selectedAccountId=localStorage.getItem('accountid');
      this.selectedAccountName=localStorage.getItem('accountName');
      if(this.selectedAccountId==null){
        this.noDataMessage='Please select an Account';
        this.isAccountSelected=false;
      }
      else{
        this.getParentDetails();
      }
      
  }
  getParentDetails(): void {
    this.employeeDetails = []
    this.orgHierarchyService.getViewHierarchyelement().subscribe((data) => {
      this.apidata = data;
      console.log(this.apidata)
      this.updatedDate = new Date(Math.max(...this.apidata.map((e: any) => new Date(e.updatedAt))));
      this.apidata.map((d: any) => {
        d.css = 'background-color:rgb(250, 250, 250); border:none; box-shadow:none !important;min-width:320px; max-width:360px; max-height:400px; border-radius:10px !important; height: auto; margin: 0px;',
          d.children = [];
      });
      if(this.apidata.length!=0){
        this.displayNoDataSection=true;
      this.apidata.forEach((element: any) => {
        if (element.reportsToId == 0) {
          this.employeeDetailsLength += 1
          this.employeeDetails.push(element);
        }
      })
      
    }
    else{
      this.displayNoDataSection=false;
    }
    if(this.employeeDetailsLength > 0){
      this.employeeDetails.forEach((element:any) => {
        this.getChildDetails(element)
      })
    }
    console.log("employee Details",this.employeeDetails)
    })
    
  }
  getChildDetails(detailsInfo: any): void {
    // console.log("detailsInfo")
    this.loader = false
    this.apidata.forEach((employee: any) => {
      if (detailsInfo.userId === employee.reportsToId) {
        detailsInfo.children.push(employee);
      }
    });
    detailsInfo.children.forEach((child: any) => {
      this.getChildDetails(child);
    })
  }



  editPopup(userdata: object): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = "org-hierarchy-edit-popup",
      dialogConfig.width = "950px",
      dialogConfig.height = "680px";
      dialogConfig.data = {
        dialogname: "editHierarcy",
        actionButtonText: "Save & Update",
        titleText: "Edit",
        editdata: userdata
      }
    const dialogRef = this.dialog.open(OrgHierarchyEditPopupComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((status)=>{
      if(status === 'success'){
        window.location.reload();
      }
    });
  }

  sign(name: string): string {
    var ls: number = 0;
    name = name.trim();
    for (let i = name.length - 1; i > 0; i--) {
      if (name[i] === " ") {
        ls = i;
        break
      }
    }
    if (ls !== 0) {
      return name[0] + name[ls + 1];
    } else {
      return name[0];
    }
  }




  //View on Click of Eye Icon
  OpenViewPopup(user: any): void {
    if (!user) return;
    this.ViewPopupRef = this.dialog.open(OrgHierarchyViewPopupComponent, {
      width: '750px',
      //height:'300px',
      panelClass: 'no-padding-dialog',
      data: user
    });
    this.ViewPopupRef.afterClosed().subscribe((result: { edit: boolean, user: any }): void => {
      if (result?.edit === true) {
        this.editPopup(result.user);
      }
      this.ViewPopupRef = null;
    });
  }

  // listener to On Hover on Avtar
  openOnHover(user: any, event: any): void {
    if (!user) return;
    this.currentHoverElement = event.target;
    const currentPosition = this.getHoveredElementPosition(event.target);
    setTimeout(() => {
      this.showHoverComponent(user, currentPosition);
    }, 700);
  }
  private getHoveredElementPosition(el: any) {
    const rect = el.getBoundingClientRect();
    return { top: rect.top, left: rect.left };
  }
  private createHoverComponent(user: any): ComponentRef<OrgHierarchyHoverViewComponent> {
    this.viewContainer.clear();
    const calloutComponentRef = this.viewContainer.createComponent(OrgHierarchyHoverViewComponent);
    calloutComponentRef.instance.user = user;
    return calloutComponentRef;
  }
  showHoverComponent(user: any, currentPosition: any) {
    this.HoverComponentRef = this.createHoverComponent(user);
    this.HoverComponentRef.instance.styleLeft = ((currentPosition.left + 250 > innerWidth) ? currentPosition.left - 400 : currentPosition.left - 70) + 'px';
    this.HoverComponentRef.instance.styleTop = ((currentPosition.top + 300 > innerHeight) ? currentPosition.top - 350 : currentPosition.top - 70) + 'px';
  }

  hideHoverComponent() {
    if (this.HoverComponentRef) {
      this.HoverComponentRef.destroy();
      this.HoverComponentRef = null;
    }
  }

  //listening to Closing of Hover popup
  @HostListener('mouseover', ['$event'])
  onMouseOver(event: any) {
    let hoverComponent = event.target;
    let inside = false;
    do {
      if (this.HoverComponentRef) {
        if (hoverComponent === this.HoverComponentRef.location.nativeElement || hoverComponent === this.currentHoverElement) {
          inside = true;
        }
      }
      hoverComponent = hoverComponent.parentNode;
    } while (hoverComponent);
    if (!inside) {
      this.hideHoverComponent();
    }
  }
}