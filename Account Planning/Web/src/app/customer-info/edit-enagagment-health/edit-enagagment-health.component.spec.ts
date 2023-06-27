import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditEnagagmentHealthComponent } from './edit-enagagment-health.component';

describe('EditEnagagmentHealthComponent', () => {
  let component: EditEnagagmentHealthComponent;
  let fixture: ComponentFixture<EditEnagagmentHealthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditEnagagmentHealthComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditEnagagmentHealthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
