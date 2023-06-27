import { EventEmitter, Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EditSharingDataService {


  public stringSubject: EventEmitter<any> = new EventEmitter<any>();

  public loaderBoolean:EventEmitter<any>=new EventEmitter<any>();

  
  constructor() { }


  passingRequest(){
    this.stringSubject.emit();
  }
  
  loaderActivation(){
    this.loaderBoolean.emit();
  }
}
