import { Component,Inject,OnInit} from "@angular/core";
import { MatDialogRef,MAT_DIALOG_DATA} from "@angular/material/dialog";

@Component({
    selector: 'app-org-hierarchy-view-popup',
    templateUrl: './org-hierarchy-view-popup.component.html',
    styleUrls: ['./org-hierarchy-view-popup.component.scss']
  })
  
  export class OrgHierarchyViewPopupComponent {
    
    constructor(private viewPopupRef: MatDialogRef<OrgHierarchyViewPopupComponent> , @Inject(MAT_DIALOG_DATA) public user: any){}

    closeViewPopup(){
      this.viewPopupRef.close({edit:false,user:this.user});
    }

    Edit(){
      this.viewPopupRef.close({edit:true,user:this.user});
    }

  }