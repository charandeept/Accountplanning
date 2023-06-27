import { Component, OnInit } from '@angular/core';
import { environment } from './../../environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor() {
  }

  ngOnInit(): void {
  }
  SSO_Login(){
    window.open(environment.ssoUrl, '_self');
  }
}
