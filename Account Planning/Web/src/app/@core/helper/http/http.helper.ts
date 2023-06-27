//#region angular imports

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CoreConstant } from '../../core.constant';
import { environment } from 'src/environments/environment';

//#endregion angular imports


@Injectable()
export class HttpHelper {


  //#region constructor

  constructor(private http: HttpClient) {
  }

  //#endregion constructor

  //#region public functions

  /**
   * get json data from api
   * @param url
   * @param options
   */
  public get(url: string, options?: any): Observable<any> {
    let baseUrl = environment.apiBaseUrl;
    if (url) {
      return this.http.get(baseUrl + url);
    }
    return new Observable<any>();
  }

  /**
   * posts data to api
   * @param url
   * @param data
   */
  public post(url: string, data: any, options?: any): Observable<any> {
    let baseUrl = environment.apiBaseUrl;
    if (url) {
      url = baseUrl + url;
      // let httpheaders = new HttpHeaders();
      // httpheaders.append('Content-Type', 'multipart/form-data');
      // httpheaders.append('Access-Control-Allow-Origin', '*');
      // httpheaders.append('Access-Control-Request-Headers','Access-Control-Request-Headers')
      // httpheaders.append('Accept', 'applcation/ json');
      // httpheaders.append(CoreConstant.header.contentTypeName, CoreConstant.header.jsonContentType);
      return this.http.post(url, data);
    }
    return new Observable<any>();
  }

  /**
   * put api call
   * @param url
   * @param body
   */
  public put(url: string, body: any): Observable<any> {
    let baseUrl = environment.apiBaseUrl;
    if (url) {
      return this.http.put(baseUrl + url, body);
    }
    return new Observable<any>();

  }

  /**
   * delete api call
   * @param url
   */
  public delete(url: string): Observable<any> {
    let baseUrl = environment.apiBaseUrl;
    if (url) {
      return this.http.delete(baseUrl + url);
    }
    return new Observable<any>();

  }

  //#endregion public functions


}
