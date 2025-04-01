import { TestBed } from '@angular/core/testing';

import { CustomersearchService } from './customersearch.service';

describe('CustomersearchService', () => {
  let service: CustomersearchService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustomersearchService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
