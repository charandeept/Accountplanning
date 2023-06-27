//#region angular imports

import { Injectable } from '@angular/core';
import { CoreUrl } from '../../core.url';
import { HttpHelper } from '../../helper/http/http.helper';
import { AppConfigModel } from '../../models/app-config.model';

//#endregion angular imports

@Injectable()

export class AppConfigService {

  //#region model properties

  private appConfigData: AppConfigModel

  //#endregion model properties

  //#region constructor

  constructor(private httpHelper: HttpHelper) {
    this.appConfigData = new AppConfigModel();
    this.setConfigData();
  }

  //#endregion constructor

  //#region public functions

  /**
   * gets configuration data
   */
  public getConfigData() {
    return this.appConfigData;
  }

  //#endregion public functions

  //#region private functions

  /**
   * sets app config model data
   */
  private setConfigData() {
    this.httpHelper.get(CoreUrl.api.appConfigUrl)
      .subscribe(
        (results: any) => {
          this.configDataMapper(results);
        });
  }

  /**
   * mapper for app config data
   * @param results
   */
  private configDataMapper(results: any) {

    //TODO: If model properties of server differ form client properties, use this place holder to map to the model
  }

  //#endregion private functions

}
