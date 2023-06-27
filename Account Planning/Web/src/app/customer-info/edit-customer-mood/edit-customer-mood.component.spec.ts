import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCustomerMoodComponent } from './edit-customer-mood.component';

describe('EditCustomerMoodComponent', () => {
  let component: EditCustomerMoodComponent;
  let fixture: ComponentFixture<EditCustomerMoodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCustomerMoodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCustomerMoodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
