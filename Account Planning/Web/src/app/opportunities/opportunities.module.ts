import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { routeConfig } from '../home/home.routing';
import { MatCardModule } from '@angular/material/card';



@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routeConfig),
    CommonModule,
    MatCardModule,

  ]
})
export class OpportunitiesModule { }
