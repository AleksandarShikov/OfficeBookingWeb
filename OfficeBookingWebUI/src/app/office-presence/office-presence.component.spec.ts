import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OfficePresenceComponent } from './office-presence.component';

describe('OfficePresenceComponent', () => {
  let component: OfficePresenceComponent;
  let fixture: ComponentFixture<OfficePresenceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OfficePresenceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OfficePresenceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
