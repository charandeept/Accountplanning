//#region angular imports

import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, Input, SimpleChanges, ViewChild, OnInit, OnDestroy, OnChanges } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/@core';
import { DataForOverviewService } from '../../Services/data-for-overview.service';
import { MenuItemModel } from './models/menu-item.model';
import { NavMenuModel } from './models/nav-menu.model';
import { role } from '../../enums/role.enum';

//#endregion angular imports

//#region functional/model imports

import { NavBarService } from './nav-bar.service';

//#endregion functional/model imports

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.html',
  styleUrls: ['./nav-bar.scss']
})
export class NavBarComponent implements OnInit, OnDestroy, OnChanges {

  //#region input properties

  @Input() show: boolean = false;
  
  @ViewChild('sideMenu')

  customerInfoId:number=1;
  navBar!: { toggle: () => void; };
  navbarMenu: MenuItemModel[] = [];
  index!: number;
  user:any;
  mobileQuery: MediaQueryList;
  private mobileQueryListener: () => void;
  //#endregion input properties


  //#region constructor

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, private service: NavBarService, private router: Router,
    public dataService:DataForOverviewService , private authservice:AuthService) {
    this.mobileQuery = media.matchMedia('(max-width: 992px)');
    this.mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addEventListener('change', this.mobileQueryListener);
    this.getCustomerId()
  }

  //#endregion constructor

  //#region life cycle hooks

  ngOnInit() {
    this.user = this.authservice.getUserInfo()
    this.getCustomerId()
    this.service.getNavMenu(this.customerInfoId).subscribe((menu: NavMenuModel) => {
      this.navbarMenu.push(...menu.menuList);
      if(this.user[0].userRoleId == role.isL1){
        this.navbarMenu.splice(0,1)
      }
    })
    
    // console.log(this.navbarMenu)
  }

  customerInfo(){
    this.getCustomerId()
    this.router.navigate(['/account-info',this.customerInfoId])
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['show']) {
      this.navBar?.toggle();
    }
  }

  ngOnDestroy() {
    this.mobileQuery.removeEventListener('change', this.mobileQueryListener)
  }

  getCustomerId(){
    this.customerInfoId=this.dataService.getcustomerRequestedId();
  }
  //#endregion cycle hooks

}
