import { JsonPipe } from '@angular/common';
import { ThisReceiver } from '@angular/compiler';
import { Component } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { BarControllerChartOptions, Chart, registerables } from 'chart.js';
import { DataForOverviewService } from '../shared/Services/data-for-overview.service';
import { EditModalComponent } from './edit-modal/edit-modal.component';
import { CustomerDetailsService } from './services/customer-details.service';
import {
  UserData, CustmerBusinessInformation, CustomerTeamInfo, CSATDetails, CustomerMoodDetails
  , CustomerVendors, CustomerFinancialHealth, CustomerEngagementHealth
} from './customer-info-interface';
import { EditSharingDataService } from '../shared/Services/edit-sharing-data.service';
import { ActivatedRoute } from '@angular/router';
import { filter } from 'rxjs/operators';
import { DashboardService } from '../shared/Services/dashboard.service';

Chart.register(...registerables);

@Component({
  selector: 'app-customer-info',
  templateUrl: './customer-info.component.html',
  styleUrls: ['./customer-info.component.scss'],
})
export class CustomerInfoComponent {

  data: any;
  count:number = 0;
  csatInfoMessage: string = "";
  load:boolean = false;
  public userData: UserData;
  FinancialChart: any;
  financialHealthValue: number = 80;
  EngagmentChart: any;
  csatDataRating: number = 0;
  vendorDatatemp: any = [];
  /** Vendors table Display coloum array */
  displayedColumns: string[] = ['vendors', 'service'];
  dataSource = [];
  /** Csat Option */
  stars = [1, 2, 3, 4, 5];

  /**Loader  */
  loader: boolean = true;

  /** Date declaration */
  updatedDate: any = "";

  /**CSAT Active Mood */

  activeBadIcon: boolean = false;
  activeGoodIcon: boolean = false;
  activeExcellentIcon: boolean = false;

  /** for Userrequested ID */
  sub: any;
  customerRequestedId: number=0;
  subscription: any;
  isDataConsist:boolean = false;

  /**
   *
   * @param apiCalls
   * @param matdialog
   * @param customerdetails
   */
  constructor(
    private apiCalls: DataForOverviewService,
    private matdialog: MatDialog,
    public postService: EditSharingDataService,
    private customerdetails: CustomerDetailsService,
    private route: ActivatedRoute, public _service:DashboardService ){
    this.userData = new UserData();
    // this.load = false
  }


  ngOnInit() {
    this.userData = new UserData()

    this.sub = this.route.params.subscribe(params => {
      this.customerRequestedId = +params['id'];// (+) converts string 'id' to a number
      this.apiCalls.updatecustomerRequestedId(this.customerRequestedId)
      this.getApiData();
   });
  }

  getApiData() {
    this.getBussinessOverviewData();
    this.getTeamInfoData();
    this.getVendorData();
    this.getCsatData();
    this.getCustomerMood();
    this.getFinancialHealthData();
    this.getEnagmentHealthData();
    // window.location.reload()
    // this.get();
  }

  activateLoader(){
    this.loader=true;
  }

  /**
   * CSAT Mood active tab
   */
  csatMood(customerMood: any) {
    this.activeBadIcon = false;
    this.activeGoodIcon = false;
    this.activeExcellentIcon = false;
    switch (customerMood) {
      case 1: this.activeBadIcon = true;
        break
      case 2: this.activeGoodIcon = true;
        break
      case 3: this.activeExcellentIcon = true;
        break
    }
  }

  getBussinessOverviewData() {
    this.loader = true;
    this.userData.bussinessInformation = new CustmerBusinessInformation();
    this.apiCalls.getBussinessOverviewData().subscribe((bussinessData: CustmerBusinessInformation) => {
      this.userData.bussinessInformation = bussinessData;
      this._service.updateUserData(this.userData);
      this.loader = false;
    })
  }

  getTeamInfoData() {
    this.loader = true;
    this.apiCalls.getTeamInfoData().subscribe((teamInfoData: CustomerTeamInfo) => {
      this.userData.teamInfo = teamInfoData;
      this._service.updateUserData(this.userData)
      this.loader = false;
    })
  }

  getVendorData() {
    this.loader = true;
    this.apiCalls.getVendorsData().subscribe((vendorData: []) => {
      this.dataSource = vendorData;
      this.userData.vendorsData = vendorData;
      this._service.updateUserData(this.userData)
      this.loader = false;
    })
  }

  getCsatData() {
    this.loader = true;
    this.apiCalls.getCsatData().subscribe((csatData: CSATDetails) => {
      this.csatDataRating = csatData.csatNumber;
      this.userData.csatDetails = csatData;
      this.csatInfoMessage=csatData.comments;
      this._service.updateUserData(this.userData)
      this.loader = false;
    })
  }

  getCustomerMood() {
    this.loader = true;
    this.apiCalls.getCustomerMood().subscribe((customerMoodData: CustomerMoodDetails) => {
      this.csatMood(customerMoodData.customerMood)
      this.userData.customermood = customerMoodData;
      this._service.updateUserData(this.userData)
      this.loader = false;
    })
  }

  getFinancialHealthData() {
    this.loader = true;
    this.apiCalls.getFinancialHealthData().subscribe((financialHealth: CustomerFinancialHealth) => {
      this.financailChart(financialHealth.financialHealth)
      this.userData.financialHealth = financialHealth;
      this._service.updateUserData(this.userData)
      this.loader = false;
    })
  }

  getEnagmentHealthData() {
    this.loader = true;
    this.apiCalls.getEnagmentHealthData().subscribe((engagmentHealth: CustomerEngagementHealth) => {
      this.engagmentChart(engagmentHealth.engagementHealth)
      this.userData.engagmentHealth = engagmentHealth;
      this._service.updateUserData(this.userData)
      this.loader = false;
    })
  }

  get(){
    this._service.updateUserData(this.userData)
  }

  financailChart(financialHealthData: any) {

    let badColor = financialHealthData <= 30 ? 'rgb(255,122,23)' : 'rgb(220,220,220)';
    let goodColor = financialHealthData > 30 && financialHealthData <= 70 ? 'rgb(253,214,26)' : 'rgb(220,220,220)';
    let excellentColor = financialHealthData > 70 && financialHealthData <= 100 ? 'rgb(35,199,70)' : 'rgb(220,220,220)';

    let badValue = financialHealthData <= 30 ?  financialHealthData: 0;
    let goodValue = financialHealthData > 30 && financialHealthData <= 70 ? financialHealthData: 0;
    let excellentValue = financialHealthData > 70 && financialHealthData <= 100 ? financialHealthData: 0;
    let empty = 100 - financialHealthData;

    const footer = (tooltipItems: any[]) => {
      return 'Financial Health Value: ' + financialHealthData;
    };

    var chartExist = Chart.getChart("canvas"); // <canvas> id
    if (chartExist != undefined)
      chartExist.destroy();
    this.FinancialChart = new Chart('canvas', {
      type: 'doughnut',
      data: {
        labels: [
          'Bad', 'Good', 'Excellent'
        ],

        datasets: [{
          label: 'Financial Health',
          data: [badValue, goodValue, excellentValue,empty],
          backgroundColor: [
            badColor,
            goodColor,
            excellentColor
          ],
          hoverOffset: 4,

        }],
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            display: false
            // position: "right",
            // labels: {
            //   usePointStyle: true,
            //   pointStyle: 'rectRounded',

            // },
          },
          tooltip: {
            mode: 'index',
              filter: function(tooltipItem, data) {  
                return tooltipItem.dataIndex !== 3;
              }
          }
          },
        aspectRatio: 0,
      },
    });
  }


  engagmentChart(engagmentHealthData: any) {
    var chartExist = Chart.getChart("canvas1");
    if (chartExist != undefined)
      chartExist.destroy();

    let badColor = engagmentHealthData <= 30 ? 'rgb(255,122,23)' : 'rgb(220,220,220)';
    let goodColor = engagmentHealthData > 30 && engagmentHealthData <= 70 ? 'rgb(253,214,26)' : 'rgb(220,220,220)';
    let excellentColor = engagmentHealthData > 70 && engagmentHealthData <= 100 ? 'rgb(35,199,70)' : 'rgb(220,220,220)';

    let badValue = engagmentHealthData <= 30 ?  engagmentHealthData: 0;
    let goodValue = engagmentHealthData > 30 && engagmentHealthData <= 70 ? engagmentHealthData: 0;
    let excellentValue = engagmentHealthData > 70 && engagmentHealthData <= 100 ? engagmentHealthData: 0;
    let empty = 100 - engagmentHealthData;

    const footer = (tooltipItems: any[]) => {
      return 'Engagement Health : ' + engagmentHealthData;
    };
    this.EngagmentChart = new Chart('canvas1', {
      type: 'doughnut',
      data: {
        labels: [
          'Bad', 'Good', 'Excellent'
        ],
        datasets: [{
          label: 'Enagagment Health',
          data: [badValue, goodValue, excellentValue,empty],
          
          backgroundColor: [
            badColor,
            goodColor,
            excellentColor
          ],
          
          hoverOffset: 10,

        }],
        
      },
      options: {

        responsive: true,
        plugins: {
          legend: {
            // position: "right",
            // labels: {
            //   usePointStyle: true,
            //   pointStyle: 'rectRounded',
            // }
            display: false,
          },
          tooltip: {
            mode: 'index',
              filter: function(tooltipItem, data) {  
                return tooltipItem.dataIndex !== 3;
              }
          }
        },
        aspectRatio: 0,
      }
    });
  }

  updateRating(r: any) {
    this.csatDataRating = r;
  }

  openPopup() {
    // this.getApiData()
    console.log(this.userData)
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = "edit-modal-component",
      dialogConfig.maxWidth = '80vw',
      dialogConfig.maxHeight = '90vh',
      dialogConfig.height = '100%',
      dialogConfig.width = "100%"
    dialogConfig.data = {

      modalData: this.userData,

      name: "editModal",
      actionButtonText: "Save & Update",
      modalType: "Edit"
    }
    console.log(this.userData)
    const dialogRef = this.matdialog.open(EditModalComponent, dialogConfig)
  }
}

