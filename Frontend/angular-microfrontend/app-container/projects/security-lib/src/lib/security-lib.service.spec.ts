import { TestBed } from '@angular/core/testing';

import { SecurityLibService } from './security-lib.service';

describe('SecurityLibService', () => {
  let service: SecurityLibService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SecurityLibService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
