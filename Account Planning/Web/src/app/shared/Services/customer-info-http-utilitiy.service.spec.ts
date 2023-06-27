import { TestBed } from '@angular/core/testing';

import { CustomerInfoHttpUtilitiyService } from './customer-info-http-utilitiy.service';

describe('CustomerInfoHttpUtilitiyService', () => {
  let service: CustomerInfoHttpUtilitiyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustomerInfoHttpUtilitiyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
