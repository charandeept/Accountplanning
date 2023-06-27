//#region angular imports

import { NgModule, ModuleWithProviders, ErrorHandler, Optional, SkipSelf, Provider } from '@angular/core';
import { UrlSerializer } from '@angular/router';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

//#endregion angular imports

//#region services



//#endregion services

//#region providers


//#endregion providers

//#region core interceptors


//#endregion core interceptors

//#region helpers/utilities/configs

import { HttpHelper } from './helper/http/http.helper';
import { AppConfigService } from './services/config/app-config.service';
import { AuthService } from './services/auth/auth.service';
import { GlobalErrorService } from './services/error/global-error.service';
import { GlobalEventManagerService } from './services/event-manager/global-event-manager.service';
import { LoaderService } from './services/loader/loader.service';
import { LoggerService } from './services/logger/logger.service';
import { RouteService } from './services/route/route.service';
import { StoreService } from './services/store/store.service';
import { LoaderInterceptor } from './interceptors/loader/loader.interceptor';
import { AuthInterceptor } from './interceptors/auth/auth.interceptor';
import { ErrorInterceptor } from './interceptors/error/error.interceptor';
import { AppErrorHandler } from './providers/error-handler/app-error-handler';
import { CustomStorage } from './storage/custom.storage';
import { CoreConstant } from './core.constant';
import { StorageType } from './enums/storage-type.enum';
import { AuthGuardService } from './guards';

//#endregion helpers/utilities/configs

const coreServices = [
  AppConfigService,
  AuthService,
  GlobalErrorService,
  GlobalEventManagerService,
  LoaderService,
  LoggerService,
  RouteService,
  StoreService,
  AuthGuardService
];

const coreInterceptors = [
  { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
//{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
];

const coreProviders: Provider = [
  //{ provide: ErrorHandler, useClass: AppErrorHandler }
];

@NgModule({
  imports: [
  ],
  declarations: [

    //#region components
    //#endregion components

  ],
  exports: [

    //#region modules
    //#endregion modules

    //#region components
    //#endregion components

    //#region directives
    //#endregion directives

    //#region pipes/filters
    //#endregion pipes/filters

  ],
  providers:[
    coreServices,
    CustomStorage,
    HttpHelper,
    { provide: CoreConstant.injectKey.globalStoreType, useValue: StorageType.Local },
    coreServices,
    HttpClientModule,
    coreInterceptors,
    coreProviders
  ]
})
export class CoreModule {

  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error(`CoreModule has already been loaded. Import Core modules in the AppModule only.`);
    }
  }
// ModuleWithProviders
//  static  forRoot(): any {
//     return <any>{
//       ngModule: CoreModule,
//       providers: [
//         CustomStorage,
//         HttpHelper,
//         { provide: CoreConstant.injectKey.globalStoreType, useValue: StorageType.Session },
//         coreServices,
//         HttpClientModule,
//         coreInterceptors,
//         coreProviders
//       ],
//     };
//   }
}

