import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnablersComponent } from './enablers.component';

describe('EnablersComponent', () => {
  let component: EnablersComponent;
  let fixture: ComponentFixture<EnablersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EnablersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EnablersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
