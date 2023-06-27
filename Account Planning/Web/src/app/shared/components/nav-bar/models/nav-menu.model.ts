
//#region functional/model imports

import { MenuItemModel } from './menu-item.model';

//#endregion functional/model imports

export class NavMenuModel {

  //#region model properties

  public menuList: MenuItemModel[];
  
  //#endregion model properties

  //#region constructor

  constructor() {
    this.menuList = [];
  }

  //#endregion constructor

}
