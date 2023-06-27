import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-close-alert',
  templateUrl: './close-alert.component.html',
  styleUrls: ['./close-alert.component.scss']
})
export class CloseAlertComponent implements OnInit {

  constructor(public _dialogRef: MatDialogRef<CloseAlertComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private route: Router) { }

  ngOnInit(): void {
  }

  NoClose(event:any){
    event.preventDefault();
    this._dialogRef.close(CloseAlertComponent)
  }

}
