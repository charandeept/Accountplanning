import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login.component';
import { SsoCallbackComponent } from './sso-callback/sso-callback.component';

const routes: Routes = [
      {
        path: '',
        component: LoginComponent
      },
      {
        path:'sso-callback',
        component: SsoCallbackComponent
      }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
