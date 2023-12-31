//#region angular imports

import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoaderStatus } from '../../enums/loader-status.enum';

//#endregion angular imports

@Injectable()

export class LoaderService {

  private loaderStatusSubject: BehaviorSubject<LoaderStatus> = new BehaviorSubject<LoaderStatus>(LoaderStatus.None);

  public loaderStatus: Observable<LoaderStatus>;

  constructor() {
    this.loaderStatus = this.loaderStatusSubject.asObservable();
  }

  /**
   * starts loading bar
   */
  public start(): void {
    this.loaderStatusSubject.next(LoaderStatus.Start);
  }

  /**
   * completes loading bar
   */
  public complete(): void {
    this.loaderStatusSubject.next(LoaderStatus.Complete);
  }

  /**
   * stops loading bar
   */
  public stop(): void {
    this.loaderStatusSubject.next(LoaderStatus.Stop);
  }

  /**
   * gets loader model
   */
  public resetLoaderModel(): void {
    this.loaderStatusSubject.next(LoaderStatus.None);
  }

  /**
   * gets loader status
   */
  public getLoaderStatus(): LoaderStatus {
    return this.loaderStatusSubject.getValue();
  }

}
