import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerInfoHttpUtilitiyService } from 'src/app/shared/Services/customer-info-http-utilitiy.service';
import { DataForOverviewService } from 'src/app/shared/Services/data-for-overview.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerDetailsService {
  data: any = [];
  serviceLines: any = [];
  public industryOption: any = [];
  deliveryModelOption: any = [];
  deliveryManagerOption: any = [];
  headquatersOption: any = [];
  timeZoneOption: any = [];
  vendors: any = [];
  constructor(public customerDetails: DataForOverviewService,
    httpUtility : CustomerInfoHttpUtilitiyService) {
    this.customerDetails.getDropDown().subscribe((data: any) => {
      this.data = data;
      this.data.forEach((element: any) => {
        this.headquatersOption.push(element.Headquarters)
        this.timeZoneOption.push(element.Timezone)
        this.deliveryManagerOption.push(element.DeliveryManager)
        this.vendors.push({ [element.id]: element.vendors })
      });
    })
    this.customerDetails.getServiceLine().subscribe((data: any) => {
      data.forEach((element:any) => {
        this.serviceLines.push(element.serviceLine)
      })
    })
    this.customerDetails.getDeliveryModel().subscribe((data : any) => {
      data.forEach((element:any) => {
        this.deliveryModelOption.push(element.deliveryModel)
      })
    })
  }
}
