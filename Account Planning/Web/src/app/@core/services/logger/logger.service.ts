//#region angular imports

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CoreUrl } from '../../core.url';
import { LogLevel } from '../../enums/log-level.enum';
import { HttpHelper } from '../../helper/http/http.helper';
import { LoggerModel } from '../../models/logger.model';

//#endregion angular imports

@Injectable()

export class LoggerService {


  //#region constructor

  constructor(private httpHelper: HttpHelper) {
  }

  //#endregion constructor

  //#region public functions

  /**
   * logs info message
   * @param message
   */
  public logInfo(message: string): Observable<LoggerModel> {
    return this.logData(LogLevel.Info, message);
  }

  /**
   * logs info message
   * @param message
   */
  public logError(message: string): Observable<LoggerModel> {
    return this.logData(LogLevel.Error, message);
  }

  //#endregion public functions

  //#region private functions

  /**
   * processes log information
   * @param logLevel
   * @param message
   */
  private logData(logLevel: LogLevel, message: string): Observable<any> {
    let logModel: LoggerModel = new LoggerModel();
    logModel.logLevel = logLevel;
    logModel.logMessage = message;
    return this.httpHelper.post(CoreUrl.api.logDataUrl, logModel);
  }

  //#endregion private functions

}
