//#region angular imports

import { Injectable, ErrorHandler, Inject, Injector, NgZone } from '@angular/core';
import { CoreUrl } from '../../core.url';
import { ErrorModel } from '../../models/error.model';
import { GlobalErrorService } from '../../services/error/global-error.service';
import { RouteService } from '../../services/route/route.service';

//#endregion angular imports


@Injectable()
export class AppErrorHandler extends ErrorHandler {

  //#region constructor

  constructor(@Inject(Injector) private injector: Injector, private zone: NgZone) {
    super();
  }

  //#endregion constructor

  //#region readonly properties

  private get errorService(): GlobalErrorService {
    return this.injector.get(GlobalErrorService);
  }

  private get routeService(): RouteService {
    return this.injector.get(RouteService);
  }

  //#endregion readonly properties

  //#region public functions

  /**
   * Handles error
   * @param error
   */
  public override handleError(error: any): void {
    //set error
    let errorInfo: ErrorModel = new ErrorModel();
    //TODO: set error model
    errorInfo.errorMessage = error.message;
    errorInfo.canNotify = false;
    this.errorService.onErrorHandler(errorInfo);

    //TODO: check why we are getting warning if navigation is not wrapped inside zone
    //this.routerHelper.redirect(CoreUrl.page.errorUrl);
    this.zone.run(() => this.routeService.redirect(CoreUrl.page.errorUrl));
  }

  //#endregion public functions
}
