import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DashboardService } from 'src/app/shared/Services/dashboard.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-no-of-accounts',
  templateUrl: './no-of-accounts.component.html',
  styleUrls: ['./no-of-accounts.component.scss']
})
export class NoOfAccountsComponent implements OnInit {
  customerList: any;
  dataSource: any;

  constructor(private _service: DashboardService, public dialogRef: MatDialogRef<NoOfAccountsComponent>,@Inject(MAT_DIALOG_DATA) public data: number,private router: Router) { }

  ngOnInit(): void {
    this._service.getAccounts().subscribe((data) => {
      this.dataSource = data;
    })
  }
  displayedColumns: string[] = ['name', 'service', 'veiw'];
  onNoClick() { }

  onClick(element:any){
    this.router.navigate(['/account-info',element.customerID]);
    this.dialogRef.close();
  }
}
