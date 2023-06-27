import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../shared';
import { DataForOverviewService } from '../shared/Services/data-for-overview.service';
import { CustomerInfoComponent } from './customer-info.component';
import { routeConfig } from './customer-info.routing';
import {MatSelectModule} from '@angular/material/select';
import { EditVendorsComponent } from './edit-vendors/edit-vendors.component';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import {ChartModule} from 'primeng/chart';
import { CloseAlertComponent } from './edit-modal/close-alert/close-alert.component';


@NgModule({
  imports: [
    RouterModule.forChild(routeConfig),
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
  MatDialogModule,
  ReactiveFormsModule,
  MatSelectModule,MatButtonModule,MatTableModule,
  ChartModule
  
  ],
  declarations: [
    
  
    CloseAlertComponent
  ],
 

  providers: [DataForOverviewService],
})
export class CustomerInfoModule {
}