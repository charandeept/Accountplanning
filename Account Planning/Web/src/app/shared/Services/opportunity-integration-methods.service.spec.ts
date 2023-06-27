import { TestBed } from '@angular/core/testing';

import { OpportunityIntegrationMethodsService } from './opportunity-integration-methods.service';

describe('OpportunityIntegrationMethodsService', () => {
  let service: OpportunityIntegrationMethodsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OpportunityIntegrationMethodsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
