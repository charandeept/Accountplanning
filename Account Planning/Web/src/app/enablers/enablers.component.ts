import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DashboardService } from '../shared/Services/dashboard.service';
import { CreateEnablerSectionsComponent } from './create-enabler-sections/create-enabler-sections.component';
import { CreateEnablersComponent } from './create-enablers/create-enablers.component';
import { RemoveAlertComponent } from './remove-alert/remove-alert.component';
import { colors } from './enabler';

@Component({
  selector: 'app-enablers',
  templateUrl: './enablers.component.html',
  styleUrls: ['./enablers.component.scss']
})
export class EnablersComponent implements OnInit {
 
  public enablersdata:any
  public enablers:any
  public enablersCount:any
  public count:any
  filtered: any
  public enablersData: any[] = [];
  public enabler:any;
  public name:any;
  
  public circleColor:any;
  public showInitials:boolean = false;
  constructor(public _dialog: MatDialog, private _data:DashboardService,public route:Router) { }

  ngOnInit(): void {
    this.getEnabler()
  }
  addEnabler() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "20%"
    dialogConfig.data = {
      name: "addEnabler",
      actionButtonText: "Create",
      cardType: "Create",
    }
    const dialogRef = this._dialog.open(CreateEnablersComponent, dialogConfig)
  }
  editEnabler(enabler:any){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "20%"
    dialogConfig.data = {
      name: "editEnabler",
      actionButtonText: "Save",
      cardType: "Edit",
      carddata: enabler
    }
    const dialogRef = this._dialog.open(CreateEnablersComponent, dialogConfig)
  }
  addLink(data:any){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "29%"
    dialogConfig.data = {
      name: "addLink",
      actionButtonText: "Create",
      cardType: "Create",
      carddata: data
    }
    const dialogRef = this._dialog.open(CreateEnablerSectionsComponent, dialogConfig)
  }
  editLink(data:any , name:any){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "29%"
    dialogConfig.data = {
      name: "editLink",
      actionButtonText: "Save",
      cardType: "Edit",
      carddata: data,
      title: name
    }
    const dialogRef = this._dialog.open(CreateEnablerSectionsComponent, dialogConfig)
  }
  getEnabler(){
    this._data.getenablers().subscribe((data)=>{
      this.enablersdata = data
      this.enablersCount = this.enablersdata.count
      this.enablers = this.enablersdata.enablers
      this.count = this.enablersCount.length
      for (let i = 0; i < this.enablersCount.length; i++) {
        this.filtered=(this.enablers.filter((enablers: { enablerTypeId: number; }) => enablers.enablerTypeId === this.enablersCount[i].enablerTypeId))
          for (let index = 0; index < this.filtered.length; index++) {
            const element = this.filtered[index].title;
            if(this.createDP(element) == " "){
              this.filtered[index].showInitials = false
            }
            else{
              this.showInitials = true;
              this.filtered[index].initials = this.createDP(element)
              const digit = this.getColorIndex(index)
              this.circleColor = colors[(index + i) % (10 * digit)]
              this.filtered[index].color = this.circleColor
              this.filtered[index].showInitials = true
            }
          }
          
        this.enablersData.push({
          "name": this.enablersCount[i].enablerTitle,
          "id":this.enablersCount[i].enablerTypeId,
          "count":this.enablersCount[i].count,
          "data": this.filtered
        })
      }
    }) 
  }

  getColorIndex(n:any){
    return n.toString().length
  }

  removeEnabler(enabler:any){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "18%"
    dialogConfig.data = {
      name: "removeEnabler",
      carddata: enabler
    }
    const dialogRef = this._dialog.open(RemoveAlertComponent, dialogConfig)
  }

  removeEnablerCard(section:any){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "18%"
    dialogConfig.data = {
      name: "removeEnablerCard",
      carddata: section
    }
    const dialogRef = this._dialog.open(RemoveAlertComponent, dialogConfig)
  }

  createDP(name:any){
    if(name.length !== 0){
    let initials = name[0];
    for (let index = 0; index < name.length; index++) {
      
      if (name[index] === ' '){
        initials += name[index + 1]
      }
      if(initials.length == 2){
        break;
      }}
      return initials
    }
    else{
      return " ";
    }
    
  }
}