import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { routeConfig } from '../../home/home.routing';



@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routeConfig),
    CommonModule,
  ]
})
export class AddOpportunityModule{ 
  
}
