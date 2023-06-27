import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Color, LegendPosition, ScaleType } from '@swimlane/ngx-charts';
import { AddMetricsComponent } from './add-metrics/add-metrics.component';

import { NoOfAccountsComponent } from './no-of-accounts/no-of-accounts.component';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs';
import { DashboardService } from '../shared/Services/dashboard.service';
import { Router } from '@angular/router';
import { colors } from './services/dashboard';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [AddMetricsComponent],

})

export class DashboardComponent implements OnInit {

  public widgetsData: any;
  public editCardData: any
  public accountsid: any
  public noOfAccounts: any;
  public engagementHealth: any[] = [];
  public financialHealth: any[] = [];
  public sortEngagementHealth: any;
  public engagementHealthData: any;
  public sortFinancialHealth: any;
  public financialHealthData: any;
  public engagementHealthGet: any
  public financialHealthGet: any;
  public loadingComponent: boolean = true;
  public view: number[] = [300, 200];
  public legend: boolean = true;
  public showLabels: boolean = true;
  public animations: boolean = true;
  public below = LegendPosition.Below
  public innerPadding: number = 1;
  public isSmallScreen$:any;
  
  public months = ["January","February","March","April","May","June","July","August","September","October","November","December"];

  // Color scheme for Engagement Health
  colorSchemeEngagementHealth: Color = {
    name: 'myScheme',
    selectable: true,
    group: ScaleType.Ordinal,
    domain: ['red','green'],
  };

  // Color scheme for Financial Health
  colorSchemeFinanicalHealth: Color = {
    name: 'myScheme',
    selectable: true,
    group: ScaleType.Ordinal,
    domain: ['#2254a3', '#b1c25b'],
  };
  filtered: any;

  constructor(private http: HttpClient, public dashboardService: DashboardService, public _dialog: MatDialog,
    private breakpointObserver: BreakpointObserver,private route: Router) {}


  ngOnInit(): void {

    //Data for card
    this.onShowCardDetails();
    //Data for HeatMap
    this.onShowHeatMapDetails();

    this.breakpointObserver.observe('(max-width: 920px)')
    .subscribe((result) => {
      this.isSmallScreen$ = false;
      if(result.matches){
        this.isSmallScreen$ = true;
      }
    })

    
  }
  getcolor(metricvalue:any , metricid:any){
    
    if(metricid == 1){
      const color = metricvalue > 3 ? colors.excColor : (metricvalue < 3 ? colors.badColor : colors.goodColor);
      return color
    }
    else if(metricid == 2){
      const color = metricvalue == "Excellent" ? colors.excColor : (metricvalue == "Bad" ? colors.badColor : colors.goodColor);
      return color

    }
    else{
      const color = metricvalue >= 70 ? colors.excColor : (metricvalue < 30 ? colors.badColor : colors.goodColor);
      return color
    }
    
  }

  onShowHeatMapDetails() {

    //Engagement Health Data Get
    this.dashboardService.getAllDashboard().subscribe((data: any) => {
      data = data.engagementHealths
      for (let index = 0; index < this.months.length; index++) {
        this.filtered=(data.filter((engagementHealth: { month: string; }) => engagementHealth.month === this.months[index]))
        this.filtered = (this.filtered.map(function (item: any) {
          return { name: item[Object.keys(item)[0]], value: item[Object.keys(item)[1]] };
  
        }))
        this.engagementHealth.push({
          "name": this.months[index],
          "series": this.filtered
        })
      }

      this.engagementHealthGet = this.engagementHealth

      //Sort for Engagement Health
      this.sortEngagementHealth = this.engagementHealth[0].series
      this.sortEngagementHealth.sort(function (a: any, b: any) {
        return a.value < b.value ? -1 : a.value > b.value ? 1 : 0;
      });
      this.engagementHealthData = this.sortEngagementHealth;
      console.log(this.engagementHealth)

    });

    //FinancialHealth Data Get
    this.dashboardService.getAllDashboard().subscribe((data: any) => {
      data = data.financialHealths
      for (let index = 0; index < this.months.length; index++) {
        this.filtered=(data.filter((financialHealth: { month: string; }) => financialHealth.month === this.months[index]))
        this.filtered = (this.filtered.map(function (item: any) {
          return { name: item[Object.keys(item)[0]], value: item[Object.keys(item)[1]] };
        }))
        this.financialHealth.push({
          "name": this.months[index],
          "series": this.filtered
        })
      }
      this.financialHealthGet = this.financialHealth

      //Sort for Financial Health
      this.sortFinancialHealth = this.financialHealth[0].series
      this.sortFinancialHealth.sort(function (a: any, b: any) {
        return a.value < b.value ? -1 : a.value > b.value ? 1 : 0;
      });
      this.financialHealthData = this.sortFinancialHealth;
    });
  }

  //Data for card widgets
  onShowCardDetails() {
    this.dashboardService.getAllDashboard().subscribe((data) => {
      this.widgetsData = data.metric;
      console.log(data.metric)
      this.noOfAccounts = data.noOfAccounts
      this.showCardSetValues();
    })
  }
  //addmetrics Dialog box
  addMetric() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = "add-metrics-component",
      dialogConfig.width = "29%"
    dialogConfig.data = {
      name: "addMetric",
      actionButtonText: "Create",
      cardType: "Create"
    }
    const dialogRef = this._dialog.open(AddMetricsComponent, dialogConfig)
  }

  //Edit Metric Dialog Box
  editMetric(data: any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = "add-metrics-component",
      dialogConfig.width = "29%",
      dialogConfig.data = {
        name: "editMetric",
        actionButtonText: "Update",
        cardType: "Edit",
        cardData: data
      }
    const dialogRef = this._dialog.open(AddMetricsComponent, dialogConfig)
  }

  //delete
  deleteCard(id: number) {
    this.dashboardService.deleteCardData(id).subscribe((data: any) => {
      data = id
    })
    const currentUrl = this.route.url;
    this.route.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.route.navigate([currentUrl]);
    });  }

  //show number of accounts
  showAccounts(data: any) {
    const dialogRef = this._dialog.open(NoOfAccountsComponent, {
      width: '29%',
      height: '40%',
      data: this.widgetsData.filter((cardid: string | number) => cardid !== this.widgetsData[cardid])
    })
    this.dashboardService.cardId = data
  }


  private showCardSetValues() {
    // console.log(this.widgetsData)
    for (let i = 0; i < this.widgetsData.length; i++) {
      if (this.widgetsData[i].metricid == 1) {
        this.widgetsData[i].name = "CSAT";
        this.widgetsData[i].img = '../assets/images/hotel_class.png';
      }
      else if (this.widgetsData[i].metricid == 2) {
        this.widgetsData[i].name = "Customer Mood";
        this.widgetsData[i].img = '../assets/images/add_reaction.png';
      }
      else if (this.widgetsData[i].metricid == 3) {
        this.widgetsData[i].name = "Engagement Health";
        this.widgetsData[i].img = '../assets/images/campaign.png';
      }
      else {
        this.widgetsData[i].name = "Financial Health";
        this.widgetsData[i].img = '../assets/images/monetization_on.png';
      }
      if (this.widgetsData[i].operatorid == 1 && (this.widgetsData[i].metricid == 1 || this.widgetsData[i].metricid == 3 || this.widgetsData[i].metricid == 4)) {
        this.widgetsData[i].operatorid = '>';
      }
      else if (this.widgetsData[i].operatorid == 2 && (this.widgetsData[i].metricid == 1 || this.widgetsData[i].metricid == 3 || this.widgetsData[i].metricid == 4)) {
        this.widgetsData[i].operatorid = '<';
      }
      else if (this.widgetsData[i].operatorid == 3 && (this.widgetsData[i].metricid == 1 || this.widgetsData[i].metricid == 3 || this.widgetsData[i].metricid == 4)) {
        this.widgetsData[i].operatorid = '=';
      }
      if (this.widgetsData[i].metricid == 2) {
        if (this.widgetsData[i].metricvalue == 1) {
          this.widgetsData[i].metricvalue = 'Bad';

        }
        else if (this.widgetsData[i].metricvalue == 2) {
          this.widgetsData[i].metricvalue = 'Good';
        }
        else {
          this.widgetsData[i].metricvalue = 'Excellent';
        }

        this.widgetsData[i].operatorid = '';
      }
    }
  }
}

