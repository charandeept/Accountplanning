import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { SsoCallbackComponent } from './sso-callback/sso-callback.component';
import {MatButtonModule} from '@angular/material/button';
import { SharedComponentsModule } from "../shared/components/shared-components.module";

@NgModule({
    declarations: [LoginComponent, SsoCallbackComponent],
    exports: [LoginComponent, SsoCallbackComponent],
    imports: [
        CommonModule,
        LoginRoutingModule,
        MatButtonModule,
        SharedComponentsModule
    ]
})
export class LoginModule { }
