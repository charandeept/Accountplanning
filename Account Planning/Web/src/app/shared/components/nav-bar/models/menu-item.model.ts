

export class MenuItemModel {

  //#region model properties

  public code!: string;
  public displayText!: string;
  public url!: string;
  public icon!: string;
  public isActive!: boolean;
  public childNodes: MenuItemModel[];

  public isExapand!: boolean;

  //#endregion model properties

  //#region constructor

  constructor() {
    this.childNodes = [];
  }

  //#endregion constructor

}
