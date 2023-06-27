//#region angular imports
import { HttpRequest, HttpEvent, HttpHandler, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Injectable, Inject, Injector } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, retryWhen } from 'rxjs/operators';
import { CoreConstant } from '../../core.constant';
import { CoreUrl } from '../../core.url';
import { StringHelper } from '../../helper/string/string.helper';
import { ErrorModel } from '../../models/error.model';
import { AuthService } from '../../services/auth/auth.service';
import { GlobalErrorService } from '../../services/error/global-error.service';
import { RouteService } from '../../services/route/route.service';

//#endregion angular imports

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  //#region constructor

  constructor(@Inject(Injector) private injector: Injector) {
  }

  //#endregion constructor

  //#region readonly properties

  private get errorService(): GlobalErrorService {
    return this.injector.get(GlobalErrorService);
  }

  private get authService(): AuthService {
    return this.injector.get(AuthService);
  }

  private get routeService(): RouteService {
    return this.injector.get(RouteService);
  }

  //#endregion readonly properties

  //#region public functions

  /**
   * overridden base implementation
   * @param req
   * @param next
   */
  public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      //retry(2),
      catchError((errorResponse: HttpErrorResponse) => {
        let errorInfo: ErrorModel = new ErrorModel;
        errorInfo.statusCode = errorResponse.status;

        if (errorResponse.error instanceof ErrorEvent) {
          // client-side error
          errorInfo.errorMessage = StringHelper.format(CoreConstant.logMessage.clientApiError, errorResponse.error.message);
        } else {
          // server-side error
          errorInfo.errorMessage = StringHelper.format(CoreConstant.logMessage.serverApiError, errorResponse.status.toString(), errorResponse.message);
        }
        //TODO:Handle error as per requirements
        let canRethrow: boolean = true;
        switch (errorInfo.statusCode) {
          case CoreConstant.statusCode.unAuthenticated:
            this.authService.onLogoutHandler();
            canRethrow = false;
            this.routeService.redirect(CoreUrl.page.loginUrl);
            break;
          case CoreConstant.statusCode.unAuthorized:
            break;
          case CoreConstant.statusCode.badRequest:
            break;
          case CoreConstant.statusCode.fileNotFound:
            this.errorService.onErrorHandler(errorInfo);
            canRethrow = false;
            this.routeService.redirect(CoreUrl.page.errorUrl);
            break;
          case CoreConstant.statusCode.serverError:
            break;
        }
        if (canRethrow) {
          return throwError(errorResponse);
        }
        else {
          return new Observable<HttpEvent<any>>();
        }
      })
    );
  }

  //#endregion public functions
}
