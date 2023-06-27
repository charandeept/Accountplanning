import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { AuthService } from 'src/app/@core';
import { _UserDetailsUrl } from '../shared/Services/url.constatnts';
import { CustomerInfoHttpUtilitiyService } from '../shared/Services/customer-info-http-utilitiy.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient,private authService: AuthService,private httpUtility: CustomerInfoHttpUtilitiyService,) {
  }

  public getClaims(token: string) {
    return this.http.get(`https://acs-sso-accelerator.azurewebsites.net/api/client-identifier/get-token-claims/1062?token=${token}`);
  }
  public getUser(email: string){
    return this.httpUtility.get(_UserDetailsUrl+email);
  }
}
