import { Component, OnInit,Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DashboardComponent } from 'src/app/dashboard/dashboard.component';
import { DashboardService } from 'src/app/shared/Services/dashboard.service';

@Component({
  selector: 'app-remove-alert',
  templateUrl: './remove-alert.component.html',
  styleUrls: ['./remove-alert.component.scss']
})
export class RemoveAlertComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<RemoveAlertComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private _service:DashboardService,private route: Router) { }

  ngOnInit(): void {

  }
  reloadCurrentRoute() {
    const currentUrl = this.route.url;
      this.route.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.route.navigate([currentUrl]);
      });
  }
  remove(){
    if(this.data.name == "removeEnabler"){
      this._service.deleteenabler(this.data.carddata.id).subscribe((data)=>{
        this.reloadCurrentRoute()
        this.dialogRef.close()
      })
    
    
    }
    else{
      this._service.deleteenablercard(this.data.carddata.id).subscribe((data)=>{
        this.reloadCurrentRoute()
        this.dialogRef.close()
    })
    
    
    

    }
  }
  close(){
    this.dialogRef.close()
  }

}
