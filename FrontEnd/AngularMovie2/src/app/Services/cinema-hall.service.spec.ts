import { TestBed } from '@angular/core/testing';

import { CinemaHallService } from './cinema-hall.service';

describe('CinemaHallService', () => {
  let service: CinemaHallService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CinemaHallService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
