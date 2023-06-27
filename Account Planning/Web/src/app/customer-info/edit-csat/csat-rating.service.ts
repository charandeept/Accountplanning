import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CsatRatingService   {
  userSelectedRating:number=0;
  ngOnInit() {
    alert(this.userSelectedRating)
   }
}
