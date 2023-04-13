import { TestBed } from '@angular/core/testing';

import { CinemaSeatService } from './cinema-seat.service';

describe('CinemaSeatService', () => {
  let service: CinemaSeatService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CinemaSeatService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
