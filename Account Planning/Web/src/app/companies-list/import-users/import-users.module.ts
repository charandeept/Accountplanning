import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { routeConfig } from './import-users.routing';
import { MatTableModule } from '@angular/material/table';
import { ResponsePopupComponent } from './response-popup/response-popup.component';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';
import { MaterialModule } from 'src/app/shared';
import { EditUserPopupComponent } from './edit-user-popup/edit-user-popup.component';
import { MatDividerModule } from '@angular/material/divider';
import { MatDialogModule } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
        ResponsePopupComponent,
        EditUserPopupComponent
  ],
  entryComponents:[
    EditUserPopupComponent
  ],
  imports: [
    RouterModule.forChild(routeConfig),
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatSelectModule,
    MatCardModule,
    MaterialModule,
    ReactiveFormsModule,
    MatDividerModule,
    MatIconModule,
    MatDialogModule
  ]
})
export class ImportUsersModule { }
