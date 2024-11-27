import { TestBed } from '@angular/core/testing';

import { OfficePresenceService } from './office-presence.service';

describe('OfficePresenceService', () => {
  let service: OfficePresenceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OfficePresenceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
