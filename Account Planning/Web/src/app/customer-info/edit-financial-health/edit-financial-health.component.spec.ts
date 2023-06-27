import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditFinancialHealthComponent } from './edit-financial-health.component';

describe('EditFinancialHealthComponent', () => {
  let component: EditFinancialHealthComponent;
  let fixture: ComponentFixture<EditFinancialHealthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditFinancialHealthComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditFinancialHealthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
