import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OfficePresenceFormComponent } from './office-presence-form.component';

describe('OfficePresenceFormComponent', () => {
  let component: OfficePresenceFormComponent;
  let fixture: ComponentFixture<OfficePresenceFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OfficePresenceFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OfficePresenceFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
