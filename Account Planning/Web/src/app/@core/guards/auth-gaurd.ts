//#region angular imports
import { Injectable } from '@angular/core';
import { Router, CanActivate, UrlTree } from '@angular/router';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { CoreUrl } from '../core.url';
import { AuthService } from '../services/auth/auth.service';
//#endregion core imports


@Injectable()
export class AuthGuardService implements CanActivate {

  //#region constructor

  constructor(private router: Router, private service: AuthService) {
  }

  //#endregion constructor

  //#region public functions

  /**
   * implementation gor can active interface method
   */
  public canActivate(): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.service.isUserAuthenticated.pipe(
      map(val => {
        if (val === true) {
          return true;
        } else {
          this.router.navigateByUrl(CoreUrl.page.loginUrl);
          return false;
        }
      }),
      catchError((err) => {
        this.router.navigateByUrl(CoreUrl.page.loginUrl);
        return of(false);
      }));
  }

}
