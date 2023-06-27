import { TestBed } from '@angular/core/testing';

import { CsatRatingService } from './csat-rating.service';

describe('CsatRatingService', () => {
  let service: CsatRatingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CsatRatingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
