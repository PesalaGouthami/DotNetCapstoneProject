import { TestBed } from '@angular/core/testing';

import { LoanhistoryService } from './loanhistory.service';

describe('LoanhistoryService', () => {
  let service: LoanhistoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoanhistoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
