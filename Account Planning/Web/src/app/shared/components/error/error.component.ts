//#region angular imports

import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ErrorModel } from 'src/app/@core/models/error.model';
import { LoggerModel } from 'src/app/@core/models/logger.model';
import { GlobalErrorService } from 'src/app/@core/services/error/global-error.service';
import { GlobalEventManagerService } from 'src/app/@core/services/event-manager/global-event-manager.service';
import { Constant } from 'src/app/shared/utilities/constant';

//#endregion angular imports

@Component({
  selector: 'app-error',
  templateUrl: './error.html'
})
export class ErrorComponent implements OnInit, OnDestroy {

  //#region model properties

  public referenceNumber!: string;
  public errorModel: ErrorModel;

  private logSubscription!: Subscription;

  //#endregion model properties

  //#region constructor

  constructor(private service: GlobalErrorService, private eventService: GlobalEventManagerService) {
    this.errorModel = new ErrorModel();
  }

  //#endregion constructor

  //#region component events

  ngOnInit() {
    this.errorModel = this.service.getErrorInfo();
    this.eventService.notifyEvent(Constant.eventCode.menuIconToggle, false);
    this.logSubscription = this.service.getErrorInfo().errorLogResponse.subscribe((res: LoggerModel) => {
      this.referenceNumber = res.referenceNumber;
    });
  }

  ngOnDestroy() {
    this.service.clearErrorState();
    this.logSubscription.unsubscribe();
    this.eventService.notifyEvent(Constant.eventCode.menuIconToggle, true);
  }

  //#endregion component events


}
