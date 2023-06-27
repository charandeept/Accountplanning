import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AddOpportunityComponent } from './add-opportunity/add-opportunity.component';
import { OpportunityIntegrationMethodsService } from '../shared/Services/opportunity-integration-methods.service';
import { AngularEditorConfig } from '@kolkov/angular-editor';
@Component({
  selector: 'app-opportunities',
  templateUrl: './opportunities.component.html',
  styleUrls: ['./opportunities.component.scss']
})
export class OpportunitiesComponent implements OnInit {
  oportunitiesList: Array<any> = [];
  profile: string = '';
  currentDate: any;
  postedTime: any;
  convertedTime: any;
  selectedAccount:any;


  config: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: '5rem',
    minHeight: '5rem',
    placeholder: 'Enter text here...',
    translate: 'no',
    defaultParagraphSeparator: 'p',
    defaultFontName: 'Arial',
    uploadWithCredentials: false,
    sanitize: true,

    toolbarHiddenButtons: [
      ['strikeThrough', 'undo', 'redo', 'indent',
        'outdent',
        'insertUnorderedList',
        'insertOrderedList',
        'heading',
        'fontName', 'subscript',
        'superscript', 'unlink', 'insertVideo',
        'insertHorizontalRule',
        'removeFormat',
        'toggleEditorMode', 'fontSize',
        'textColor',
        'backgroundColor',
        'customClasses','backColor','foreColor']
    ],
    
    


  };

  /**   *    
   *  @param matdialog : for mat dialog box   *
   *  @param apiCalls : To call integrating api call methods   
   */
  constructor(public matdialog: MatDialog,
    private apiCalls: OpportunityIntegrationMethodsService) {
  }
  /**   * 1. getApiCalls is used to get integrated methods    */
  ngOnInit(): void {
    this.getApiCalls()
    this.selectedAccount =localStorage.getItem('accountName')
    
  }
  getApiCalls() {
    this.getOpportunitiesList()
  }
  /** Get Opportunities List for Recently Posted Jobs */
  getOpportunitiesList() {
    this.currentDate = new Date()
    this.apiCalls.getOpportunitiesList().subscribe((opportunitiesList: Array<any>) => {

      this.oportunitiesList = opportunitiesList;
      console.log("Last Modified date" , this.oportunitiesList[0])
      this.oportunitiesList.forEach((ele: any) => {
        ele.imgurl = this.generateDefaultImage(ele.roleTitle)
        this.postedTime = new Date(ele.postedDate)
        this.convertedTime = (Date.parse(this.currentDate) - Date.parse(this.postedTime)) / 1000 / 60 / 60;
        ele.covertedHours = this.SplitTime(this.convertedTime);
      })
      this.sortingBookmark(this.oportunitiesList)
    })
  }

  /**
   * updating bookmark by click event
   * 
   * @param roleId by using roleid looping the opportunities list and updating th bookmark
   */
  updateBookMark(roleId: any) {
    this.oportunitiesList.forEach((ele: any) => {
      if (ele.roleId === roleId) {
        ele.isBookMarked = !ele.isBookMarked
      }
    })
    this.sortingBookmark(this.oportunitiesList)
  }

  /**
   * 
   * @param array  : Array to sort the list using bookmark
   */
  sortingBookmark(array: Array<any>) {
    array.sort((a, b) => b.isBookMarked - a.isBookMarked)
  }

  /**
   * 
   * @param numberOfHours convert dateTime format to hours and days
   * @returns an object with Hours and Days to represent in opportunities list
   */
  SplitTime(numberOfHours: any) {
    var Days = Math.floor(numberOfHours / 24);
    var Remainder = numberOfHours % 24;
    var Hours = Math.floor(Remainder);
    if (numberOfHours > 24) {
      return ({ "Days": Days, "Hours": Hours })
    }
    else {
      return ({ "Hours": Math.floor(numberOfHours) })
    }
  }
  /**
   * 
   * @param name : 
   * @returns 
   */
  generateDefaultImage(name: string) {
    const canvas = document.createElement("canvas");
    canvas.style.display = "none";
    canvas.width = 32;
    canvas.height = 32;
    document.body.appendChild(canvas);
    const context = canvas.getContext("2d")!;
    context.fillStyle = "#F4F4F4";
    context.fillRect(0, 0, canvas.width, canvas.height);
    context.font = "14px Inter";
    context.fillStyle = "#80818B";
    const nameArray = name.split(" ");
    let initials = "";
    for (let i = 0; i < nameArray.length; i++) {
      if (i <= 1) {
        initials = initials + nameArray[i][0];
      }
    }
    if (initials.length > 1) {
      context.fillText(initials.toUpperCase(), 6, 22);
    } else {
      context.fillText(initials.toUpperCase(), 11, 22);
    }
    const data = canvas.toDataURL();
    document.body.removeChild(canvas);
    return data;
  }
  /**
   * 
   * @param roleId passing through f5tech the data for edit pop up
   */
  editPopUp(roleId: Number) {
    this.oportunitiesList.forEach((data: any) => {
      if (data.roleId == roleId) {
        this.editOpportunity(data)
      }
    })
  }

  editOpportunity(data: any) {
    console.log(data)
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = "edit-opportunity",
      dialogConfig.width = "950px",
      dialogConfig.data = {
        name: "editOpportunity",
        actionButtonText: "Create",
        modalType: "edit",
        modalData: data
      }
    const dialogRef = this.matdialog.open(AddOpportunityComponent, dialogConfig)
  }

  /** opportunities open pop up */
  addopportunity() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = "add-opportunity",
      dialogConfig.width = "950px",
      dialogConfig.data = {
        name: "addOpportunity",
        actionButtonText: "Create",
        modalType: "Add"
      }
    const dialogRef = this.matdialog.open(AddOpportunityComponent, dialogConfig)
  }
}