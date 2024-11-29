import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParkingReservationFormComponent } from './parking-reservation-form.component';

describe('ParkingReservationFormComponent', () => {
  let component: ParkingReservationFormComponent;
  let fixture: ComponentFixture<ParkingReservationFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ParkingReservationFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParkingReservationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
