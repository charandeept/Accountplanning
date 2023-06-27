//#region angular imports

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppFooterComponent } from './app-footer/app-footer.component';
import { AppHeaderComponent } from './app-header/app-header.component';
import { ErrorComponent } from './error/error.component';
import { LoaderComponent } from './loader/loader.component';
import { NavBarModule } from './nav-bar/nav-bar.module';
import { GlobalErrorService } from 'src/app/@core/services';
import { MaterialModule } from '../angular-material/material.module';

//#endregion angular imports

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule,
    NavBarModule,
    MaterialModule
  ],
  declarations: [

    //#region components

    AppFooterComponent,
    AppHeaderComponent,
    ErrorComponent,
    LoaderComponent,

    //#endregion components

  ],
  exports: [

    //#region modules

    MaterialModule,
    NavBarModule,

    //#endregion modules

    //#region components

    AppFooterComponent,
    AppHeaderComponent,
    ErrorComponent,
    LoaderComponent,

    //#endregion components
    
  ],
  providers:[
    GlobalErrorService
  ]
})
export class SharedComponentsModule {
}
