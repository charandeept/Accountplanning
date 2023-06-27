import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { map, concatAll, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';




@Injectable({
  providedIn: 'root'
})
export class CustomerInfoHttpUtilitiyService {
  private baseApiUrl: string | undefined;
  constructor(
    private http: HttpClient,
    private router: Router
  ) {
    this.baseApiUrl = environment.apiBaseUrl;
  }
  /**
     * Post
     * @param url
     * @param body
     */
  public post(url: string, body: any) {
    return this.http.post(this.getApiUrl(url), body).pipe(
      catchError((e) => this.handleError(e))
    );
  }

  /**
   * Post
   * @param url
   * @param body
   */
  public put(url: string, body: any) {
    return this.http.put(this.getApiUrl(url), body)
      .pipe(
        catchError((e) => this.handleError(e))
      );
  }

  /**
   * Patch
   * @param url
   * @param body
   */
  public patch(url: string, body: any) {
    return this.http.patch(this.getApiUrl(url), body)
      .pipe(
        catchError((e) => this.handleError(e))
      );
  }
  /**
   * delete
   * @param url
   * @param options
   */
  public delete(url: string, options?: HttpParams) {
    return this.http.delete(this.getApiUrl(url)).pipe(
      catchError((e) => this.handleError(e))
    );
  }
  /**
   * get
   * @param url
   * @param options
   */
  // public get(url: string, options?: HttpParams) {
  //   return this.http.get(this.getApiUrl(url))
  //     .pipe(
  //       catchError((e) => this.handleError(e))
  //     );
  // }
  public get(url: string) {
    return this.http.get(this.getApiUrl(url))
      .pipe(
        catchError((e) => this.handleError(e))
      );
  }

  /**
   * getFile
   * @param url
   * @param options
   */
  public getFile(url: string, options?: HttpParams) {
    window.open(this.getApiUrl(url));
  }

  /**
   * handleError
   * @param response
   */
  private handleError(errorResponse: HttpErrorResponse) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorStatus = '404';
    console.log('error occurred -', errorResponse);

    if (errorResponse instanceof HttpErrorResponse) {
      errorStatus = errorResponse.status > 0 ? errorResponse.status.toLocaleString() : '404';
    }
    return throwError(errorResponse);
  }


  /**
   * getApiUrl
   * @param url
   */
  private getApiUrl(url: string) {
    // if (url.search('localhost') >= 0) {
    //   return `${this.localUrl}${url.replace('localhost/', '')}`;
    // } else {
    //   return `${this.baseApiUrl}${url}`;
    // }
    return `${this.baseApiUrl}${url}`;
  }
}
