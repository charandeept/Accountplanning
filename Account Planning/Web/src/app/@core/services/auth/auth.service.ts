//#region angular imports

import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CoreConstant } from '../../core.constant';
import { EmployeeModel } from '../../models';
import { StoreService } from '../store/store.service';

//#endregion angular imports
@Injectable()

export class AuthService {

  //#region model properties

  public isUserAuthenticated: Observable<boolean>;
  public isUserInfoAvaliable: Observable<boolean>;

  private userInfo: EmployeeModel = new EmployeeModel;
  private isAuthenticated: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  private userInfoSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  //#endregion model properties

  //#region constructor

  constructor(private storageService: StoreService) {
    this.isUserAuthenticated = this.isAuthenticated.asObservable();
    this.isUserInfoAvaliable = this.userInfoSubject.asObservable();
    const token = this.storageService.getDataWithoutParse(CoreConstant.storageKey.authToken);
    const user = this.storageService.getData(CoreConstant.storageKey.user);

    if (token && user) {
      this.userInfo = user;
      //set authentication status
      this.setAuthenticationStatus(true);
    }
  }

  //#endregion constructor

  //#region public functions

  /**
   * sets authentication status
   * @param isLoggedIn
   */
  public setAuthenticationStatus(isLoggedIn: boolean): void {
    this.isAuthenticated.next(isLoggedIn);
  }

  /**
   * handles login functionality
   * @param user
   * @param authToken
   */
  public onLoginHandler(user: EmployeeModel, authToken: string) {
    //set token in storage
    this.storageService.setDataWithoutJSON(CoreConstant.storageKey.authToken, authToken);

    //set authentication status
    this.setAuthenticationStatus(true);

    //set user info
    this.setUserInfo(user);
  }

  /**
   * handles log out functionality
   */
  public onLogoutHandler() {
    //remove toke from storage
    this.storageService.removeData(CoreConstant.storageKey.authToken);

    //set suthentiation status
    this.setAuthenticationStatus(false);

    //reset user info
    this.resetUserInfo();
  }

  /**
   * gets auth token
   */
  public getAuthToken(): string {
    return this.storageService.getDataWithoutParse(CoreConstant.storageKey.authToken);
  }

  /**
   * gets authenticated user info
   */
  public getUserInfo(): EmployeeModel {
    return this.userInfo;
  }

  //#endregion public functions

  //#region private functions

  /**
   * sets user info
   * @param user
   */
  public setUserInfo(user: EmployeeModel): void {
    if (user) {
      this.userInfo = user;

      this.storageService.setData(CoreConstant.storageKey.user, user);

      this.userInfoSubject.next(true);
      // this.userInfo.userName = user.userName;
      // this.userInfo.email = user.email;

      // this.userInfo.firstName = user.firstName;
      // this.userInfo.lastName = user.lastName;
      // this.userInfo.Practice = user.Practice;
      // this.userInfo.Department = user.Department;
      // this.userInfo.Role = user.Role;
      // this.userInfo.Grade = user.Grade;
      // this.userInfo.Level = user.Level;
    }
  }

  /**
   * resets user info
   */
  private resetUserInfo(): void {
    this.userInfo = new EmployeeModel();
  }

  //#endregion private functions

}
