//#region angular imports
import { HttpRequest, HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor } from '@angular/common/http';
import { Injectable, Inject, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { CoreConstant } from '../../core.constant';
import { CoreUrl } from '../../core.url';
import { StringHelper } from '../../helper/string/string.helper';
import { AuthService } from '../../services/auth/auth.service';

//#endregion angular imports


@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  //#region constructor

  constructor(@Inject(Injector) private injector: Injector) {
  }

  //#endregion constructor

  //#region readonly properties

  private get authService(): AuthService {
    return this.injector.get(AuthService);
  }

  //#endregion readonly properties

  //#region public functions

  /**
   * overridden base implementation
   * @param req
   * @param next
   */
  public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req.clone({
      headers: this.addHeader(req)
    }))
  }

  //#endregion public functions

  //#region private functions

  /**
   * adds auth token header to http request
   * @param req
   */
  private addHeader(req: HttpRequest<any>): HttpHeaders {
    let headers: HttpHeaders = req.headers;
    if (req.url !== CoreUrl.page.loginUrl) {
      let token = this.authService.getAuthToken();
      // For each Request
      return headers.set(CoreConstant.header.authTokenName,
        StringHelper.format(CoreConstant.header.authTokenValue,"Bearer "+ token));
    }

    return headers;
  }

  //#endregion private functions

}
