import { Component } from '@angular/core';
import { AuthService } from '../@core';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  styleUrls: ['./home.component.scss'],
  templateUrl: './home.html',
})
export class HomeComponent {



  colorScheme = {
    domain: ['#9CE280', '#FFD97F', '#FF8F90']
  };
  //#region constructor

  constructor(private authService: AuthService, private service: HomeService) {
    
  }
  
  //#endregion constructor
}
  //#endregion component events



