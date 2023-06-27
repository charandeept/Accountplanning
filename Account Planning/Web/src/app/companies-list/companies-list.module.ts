import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { routeConfig } from '../home/home.routing';
import { ImportUsersComponent } from './import-users/import-users.component';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatMenuModule } from '@angular/material/menu';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ImportUsersComponent
  ],
  imports: [
    RouterModule.forChild(routeConfig),
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatPaginatorModule,
    MatMenuModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class CompaniesListModule{ 
  
}
