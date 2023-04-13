import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingNavComponent } from './booking-nav.component';

describe('BookingNavComponent', () => {
  let component: BookingNavComponent;
  let fixture: ComponentFixture<BookingNavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookingNavComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookingNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
