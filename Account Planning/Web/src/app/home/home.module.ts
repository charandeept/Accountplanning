import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../shared';
import { HomeComponent } from './home.component';
import { routeConfig } from './home.routing';

@NgModule({
  imports: [
    RouterModule.forChild(routeConfig),
    MaterialModule,
    ReactiveFormsModule
  ],
  declarations: [
    HomeComponent
  ]
})
export class HomeModule {
}



