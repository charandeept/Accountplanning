//#region angular imports

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule, DomSanitizer } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

//#endregion angular imports


//#region components

import { NavBarComponent } from './nav-bar.component';

//#endregion components

//#region services

import { NavBarService } from './nav-bar.service';
import { MaterialModule } from '../../angular-material/material.module';
import { MatIconRegistry } from '@angular/material/icon';

//#endregion services

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule,
    MaterialModule
  ],
  declarations: [
    NavBarComponent
  ],
  exports: [
    NavBarComponent
  ],
  providers: [
    NavBarService
  ]
})
export class NavBarModule {
  constructor(
    private matIconRegistry: MatIconRegistry,
    private domSanitizer: DomSanitizer
  ){
    this.matIconRegistry.addSvgIcon(
      "CareerPath",
      this.domSanitizer.bypassSecurityTrustResourceUrl( "assets/images/Career Path.svg")
    );
    this.matIconRegistry.addSvgIcon(
      "Programs",
      this.domSanitizer.bypassSecurityTrustResourceUrl( "assets/images/Programs.svg")
    );
    this.matIconRegistry.addSvgIcon(
      "Vector",
      this.domSanitizer.bypassSecurityTrustResourceUrl( "assets/images/Vector.svg")
    );
  }
}



