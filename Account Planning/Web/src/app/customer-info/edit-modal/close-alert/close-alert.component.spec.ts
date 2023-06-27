import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CloseAlertComponent } from './close-alert.component';

describe('CloseAlertComponent', () => {
  let component: CloseAlertComponent;
  let fixture: ComponentFixture<CloseAlertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CloseAlertComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CloseAlertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
