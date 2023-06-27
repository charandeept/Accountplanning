import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { LayoutModule } from '@angular/cdk/layout';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FlexLayoutModule } from '@angular/flex-layout';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule, HttpHelper } from './@core';
import { AppConfigService, AuthService, GlobalErrorService, GlobalEventManagerService, LoaderService, LoggerService, RouteService, StoreService } from './@core/services';
import { LayoutComponent } from './layout/layout.component';
import { SharedComponentsModule } from './shared';
import { CustomerInfoComponent } from './customer-info/customer-info.component';
import { DataForOverviewService } from './shared/Services/data-for-overview.service';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { OrgHierarchyComponent } from './org-hierarchy/org-hierarchy.component';
import { OrgChartModule } from 'angular13-organization-chart';
import { DashboardComponent } from './dashboard/dashboard.component';
import {  MatTableModule } from '@angular/material/table';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { NoOfAccountsComponent } from './dashboard/no-of-accounts/no-of-accounts.component';
import { AddMetricsComponent } from './dashboard/add-metrics/add-metrics.component';
import { CompaniesListComponent } from './companies-list/companies-list.component';

import { CustomerInfoInterceptor } from './@core/interceptors/request/customer-info.interceptor';
import { LoginModule } from './login/login.module';
import { AddOpportunityComponent } from './opportunities/add-opportunity/add-opportunity.component';
import { EditBussinessComponent } from './customer-info/edit-bussiness/edit-bussiness.component';
import { EditCSATComponent } from './customer-info/edit-csat/edit-csat.component';
import { EditCustomerMoodComponent } from './customer-info/edit-customer-mood/edit-customer-mood.component';
import { EditEnagagmentHealthComponent } from './customer-info/edit-enagagment-health/edit-enagagment-health.component';
import { EditFinancialHealthComponent } from './customer-info/edit-financial-health/edit-financial-health.component';
import { EditModalComponent } from './customer-info/edit-modal/edit-modal.component';
import { EditVendorsComponent } from './customer-info/edit-vendors/edit-vendors.component';
import { OpportunitiesComponent } from './opportunities/opportunities.component';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { EnablersComponent } from './enablers/enablers.component';
import { CreateEnablersComponent } from './enablers/create-enablers/create-enablers.component';
import { CreateEnablerSectionsComponent } from './enablers/create-enabler-sections/create-enabler-sections.component';
import { RemoveAlertComponent } from './enablers/remove-alert/remove-alert.component'

const coreServices = [
  AppConfigService,
  AuthService,
  GlobalErrorService,
  GlobalEventManagerService,
  LoaderService,
  LoggerService,
  RouteService,
  StoreService,
  HttpHelper,

];

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    OrgHierarchyComponent,
    DashboardComponent,
    NoOfAccountsComponent,
    AddMetricsComponent,
    CompaniesListComponent, 
    CompaniesListComponent,
    CustomerInfoComponent,
    EditModalComponent,
    CustomerInfoComponent,
    EditBussinessComponent,
    EditCSATComponent,
    EditVendorsComponent,
    EditCustomerMoodComponent,
    EditFinancialHealthComponent,
    EditEnagagmentHealthComponent,
    OpportunitiesComponent,
    CompaniesListComponent, AddOpportunityComponent, EnablersComponent, CreateEnablersComponent,CreateEnablerSectionsComponent,RemoveAlertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    CoreModule,
    LoginModule,
    LayoutModule,
    SharedComponentsModule,
    OrgChartModule,
    MatCardModule,
    MatIconModule,
    NgxChartsModule,
    MatMenuModule,
    MatButtonModule,
    MatCardModule,
    MatDialogModule,
    FormsModule,
    MatTableModule,
    FlexLayoutModule,
    AngularEditorModule
  ],
  providers: [coreServices, 
    { 
      provide: HTTP_INTERCEPTORS,
       useClass: CustomerInfoInterceptor, 
       multi: true 
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
