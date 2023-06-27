import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { routeConfig } from '../home/home.routing';

import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../shared';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { OrgHierarchyEditPopupComponent } from './org-hierarchy-edit-popup/org-hierarchy-edit-popup.component';
import { OrgHierarchyViewPopupComponent } from './org-hierarchy-view-popup/org-hierarchy-view-popup.component';
import {OrgHierarchyHoverViewComponent} from './org-hierarchy-hover-view/org-hierarchy-hover-view.component';

@NgModule({
  declarations: [
    OrgHierarchyEditPopupComponent,
    OrgHierarchyViewPopupComponent,
    OrgHierarchyHoverViewComponent
  ],
  entryComponents:[
    OrgHierarchyViewPopupComponent,
    OrgHierarchyHoverViewComponent
  ],
  imports: [
  RouterModule.forChild(routeConfig),
  CommonModule,
  MaterialModule,
  ReactiveFormsModule,
  MatCardModule,
  MatFormFieldModule,
  MatListModule,
  MatDialogModule,
  ReactiveFormsModule,
  MatSelectModule,MatButtonModule,MatTableModule,
  
  ]
})
export class OrgHierarchyModule { 
  
}
