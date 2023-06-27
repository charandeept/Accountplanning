import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services';
import { role } from 'src/app/shared/enums/role.enum';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {
  user: any;
  isDM: any;
  constructor(private authService : AuthService){
    this.isDM = role.isL1
  }
  canActivate(){
    this.user = this.authService.getUserInfo();
    this.user = this.user[0]
    if(this.user.userRoleId == this.isDM){
      return false;
    }
    return true;
  }
  
}
