//#region angular imports

import { Component, ViewChild, AfterViewInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoaderStatus } from 'src/app/@core/enums/loader-status.enum';
import { LoaderService } from 'src/app/@core/services/loader/loader.service';
import { Constant } from 'src/app/shared/utilities/constant';

//#endregion angular imports


@Component({
  selector: 'app-loader',
  templateUrl: './loader.html',
  styleUrls: ['./loader.scss']
})
export class LoaderComponent implements AfterViewInit, OnDestroy {

  //#region view child

  @ViewChild(Constant.loader.progressElement, { static: true }) progressorElement: any;

  //#endregion view child

  //#region model properties

  public loaderStatus: LoaderStatus = 0;
  public loaderElement: any;
  public show: boolean;

  private progress: any;
  private width: number = 1;
  private loaderSubscription: Subscription;

  //#endregion model properties

  //#region constructor

  constructor(private loaderService: LoaderService) {
    this.show = false;
    this.loaderSubscription = this.loaderService.loaderStatus.subscribe((val: LoaderStatus) => {
      this.loaderStatus = val;
      this.onLoaderStatusChangeHandler();
    });
  }

  //#endregion constructor

  //#region component events

  ngAfterViewInit() {
    this.loaderElement = this.progressorElement;
  }

  ngOnDestroy() {
    if (this.loaderSubscription) {
      this.loaderSubscription.unsubscribe();
    }
  }

  //#endregion component events

  //#region private functions

  /**
   * loader status change handler
   */
  private onLoaderStatusChangeHandler(): void {
    if (this.loaderElement) {
      if (!this.progress && this.loaderStatus == LoaderStatus.Start) {
        this.width = 10;
        let handler: Function = this.frame.bind(this);
        this.progress = setInterval(handler, 10);
      }

    }
  }

  /**
   * call back for set interval
   */
  private frame() {
    if (this.loaderElement) {

      if (this.loaderStatus == LoaderStatus.Start) {
        this.show = true;
        this.width = this.width + 10;
        if (this.width > 90) {
          this.width = 90;
        }
        this.loaderElement.nativeElement.style.width = `${this.width.toString()}%`;
      }
      else if (this.loaderStatus == LoaderStatus.Stop || this.loaderStatus == LoaderStatus.Complete) {
        this.loaderElement.nativeElement.style.width = Constant.loader.fullPercentile;
        clearInterval(this.progress);
        this.progress = null;
        this.loaderService.resetLoaderModel();
        setTimeout(() => {
          this.show = false;
        }, 100);
      }

    }
  }

  //#endregion private functions
  
}
