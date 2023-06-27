//#region angular imports

import { TestBed, TestBedStatic } from '@angular/core/testing';

//#endregion angular imports

export class BaseSpecHelper {

  //#region constructor

  constructor() {
  }

  //#endregion constructor

  //#region public functions

  /**
   * sets test bed
   * @param importArray
   * @param declarationArray
   * @param providerArray
   */
  public setTestBed(importArray: any[],
    declarationArray: any[],
    providerArray: any[] = []): TestBedStatic {
    return TestBed.configureTestingModule(
      {
        imports: importArray,
        declarations: declarationArray,
        providers: providerArray
      }
    );
  }

  /**
   * gets router spy for navigateByUl
   */
  public getRouterNavigateByUrlSpy() {
    return jasmine.createSpyObj('Router', ['navigateByUrl']);
  }

  //#endregion public functions
}
