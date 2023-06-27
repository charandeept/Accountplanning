import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddHierarchyPopupComponent } from './add-hierarchy-popup.component';

describe('AddHierarchyPopupComponent', () => {
  let component: AddHierarchyPopupComponent;
  let fixture: ComponentFixture<AddHierarchyPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddHierarchyPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddHierarchyPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
