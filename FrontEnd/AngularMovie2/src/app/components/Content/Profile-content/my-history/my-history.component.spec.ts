import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyHistoryComponent } from './my-history.component';

describe('MyHistoryComponent', () => {
  let component: MyHistoryComponent;
  let fixture: ComponentFixture<MyHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyHistoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
