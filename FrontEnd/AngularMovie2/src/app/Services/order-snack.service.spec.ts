import { TestBed } from '@angular/core/testing';

import { OrderSnackService } from './order-snack.service';

describe('OrderSnackService', () => {
  let service: OrderSnackService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrderSnackService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
