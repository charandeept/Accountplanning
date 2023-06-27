import { TestBed } from '@angular/core/testing';

import { EditSharingDataService } from './edit-sharing-data.service';

describe('EditSharingDataService', () => {
  let service: EditSharingDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EditSharingDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
