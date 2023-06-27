//#region angular imports

import { Injectable } from '@angular/core';
import { HttpHelper } from 'src/app/@core';
import { Observable } from 'rxjs';
import { MenuItemModel } from './models/menu-item.model';
import { NavMenuModel } from './models/nav-menu.model';

//#endregion angular imports


@Injectable()

export class NavBarService {

  //#region constructor

  constructor(private httpHelper: HttpHelper ) {
  }

  //#endregion constructor

  //#region service calls

  /**
   * get navigation menu
   */
  public getNavMenu(customerid:number):Observable<NavMenuModel> {
    //return this.httpHelper.get(Url.api.navMenuUrl);

    let dataModel: NavMenuModel = new NavMenuModel();

    let tab1: MenuItemModel = new MenuItemModel();
    tab1.code = 'p1';
    tab1.displayText = 'Dashboard';
    tab1.url = '/dashboard';
    tab1.icon =  "assets/images/menu/Overview.png";
    tab1.isExapand =false
    
    let tab2: MenuItemModel = new MenuItemModel();
    tab2.code = 'p2';
    tab2.displayText = 'My Programs';
    tab2.url = '/programs';
    tab2.icon = "assets/images/menu/MyPrograms.png";
    tab2.isExapand =true;

    let tab3: MenuItemModel = new MenuItemModel();
    tab3.code = 'p3';
    tab3.displayText = 'Account Info';
    tab3.url = '/account-info/'+customerid;
    tab3.icon = "assets/images/dashboardCustomerInfoIcon.svg";
    tab3.isExapand =true;

    let tab4: MenuItemModel = new MenuItemModel();
    tab4.code = 'p4';
    tab4.displayText = 'Org Hierarchy';
    tab4.url = '/org-hierarchy';
    tab4.icon = "assets/images/menu/group.svg";
    tab4.isExapand =true;
  
    let tab5: MenuItemModel = new MenuItemModel();
    tab5.code = 'p5';
    tab5.displayText = 'Opportunities';
    tab5.url = '/opportunities';
    tab5.icon = "assets/images/menu/article.svg";
    tab5.isExapand =true;
    
    let tab6: MenuItemModel = new MenuItemModel();
    tab6.code = 'p6';
    tab6.displayText = 'Enablers';
    tab6.url = '/enablers';
    tab6.icon = "assets/images/menu/location_away.svg";
    tab6.isExapand =true;

    dataModel.menuList = [];
     dataModel.menuList.push(tab1);
    // dataModel.menuList.push(tab2);
    dataModel.menuList.push(tab3);
    dataModel.menuList.push(tab4);

    dataModel.menuList.push(tab5);
    dataModel.menuList.push(tab6);

    let observable =new  Observable<NavMenuModel>(observer => {
      observer.next(dataModel);
      observer.complete();//to show we are done with our processing
    })

    return observable;
  }

  //#endregion service calls

  //#region private functions
  //#endregion private functions

}
