import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { OrgHierarchyService } from 'src/app/shared/Services/org-hierarchy.service';

@Component({
  selector: 'app-delete-alert',
  templateUrl: './delete-alert.component.html',
  styleUrls: ['./delete-alert.component.scss']
})
export class DeleteAlertComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DeleteAlertComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private hierarchydata: OrgHierarchyService,private route: Router) { }

  ngOnInit(): void {
    console.log(this.data)
  }

  close(){
    this.dialogRef.close()
  }
  delete(){
    
    console.log(this.data.carddata)
    this.hierarchydata.deleteHierarchy(this.data.carddata).subscribe((data)=>{
      const currentUrl = this.route.url;
      this.route.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.route.navigate([currentUrl]);
      });
      this.dialogRef.close()
    })
  }

}
