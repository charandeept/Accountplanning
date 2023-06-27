import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class CustomerInfoInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request);
  }

  
  /*** LOGIN PAGE */
  //   addHeader(req: HttpRequest<any>, token) {
  //     const headers: HttpHeaders = req.headers;
  //     if (req.url.search('login') === -1) {
  //         // For each Request
  //         return headers.set('Authorization', `Bearer ${token}`)
  //             .set('Content-Type', 'application/json');
  //     } else {
  //         // To get Api Token
  //         return headers.set('Content-Type', 'application/json');
  //     }

  // }


}
