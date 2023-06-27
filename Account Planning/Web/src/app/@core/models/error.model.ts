//#region angular imports

import { Observable } from 'rxjs';
import { LoggerModel } from './logger.model';

//#endregion angular imports


export class ErrorModel {

  //#region model properties

  /** error message */
  public errorMessage!: string;

  /** error response status code */
  public statusCode!: number;

  /** flag for notifying application of the global error */
  public canNotify!: boolean;

  /** observable for error log api response*/
  public errorLogResponse: Observable<LoggerModel>;

  //#endregion model properties

  //#region constructor

  constructor() {
    this.errorLogResponse = new Observable<LoggerModel>();
  }

  //#endregion constructor

}
