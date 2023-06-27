import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { routeConfig } from '../org-hierarchy.routing';
import { MatTableModule } from '@angular/material/table';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MaterialModule } from 'src/app/shared';
import { EditHierarchyComponent } from './edit-hierarchy.component';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { FormsModule }   from '@angular/forms';
import { DeleteAlertComponent } from './delete-alert/delete-alert.component';


@NgModule({
  declarations: [
    EditHierarchyComponent,
    DeleteAlertComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routeConfig),
    MatTableModule,
    MaterialModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
  MatDialogModule,
  ReactiveFormsModule,
  MatSelectModule,MatButtonModule,
  MatSortModule,
  MatPaginatorModule,
  FormsModule,
  
  ]
})
export class EditHierarchyModule { }
