import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AuthService, StoreService, CoreConstant } from 'src/app/@core';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-sso-callback',
  templateUrl: './sso-callback.component.html',
  styleUrls: ['./sso-callback.component.scss']
})
export class SsoCallbackComponent implements OnInit {

  constructor(private router: Router,
    private route: ActivatedRoute,
    private loginService: LoginService,
    private authService: AuthService,
    private http : HttpClient,
    private storageService: StoreService,
    ) { }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe((paramMap: ParamMap) => {
      let token = paramMap.get('access_token');
      if (token) {

        this.loginService.getClaims(token).subscribe((claims: any) => {
          this.storageService.setDataWithoutJSON(CoreConstant.storageKey.authToken, token);
          this.loginService.getUser(claims.email).subscribe((user:any)=>{
            this.authService.onLoginHandler(user, token as string);
            this.router.navigate(['companies-list']);
          });
        });
      }
      else {
        this.router.navigate(['login']);
      }
    });
  }

}
