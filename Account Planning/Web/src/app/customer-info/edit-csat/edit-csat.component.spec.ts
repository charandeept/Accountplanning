import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCSATComponent } from './edit-csat.component';

describe('EditCSATComponent', () => {
  let component: EditCSATComponent;
  let fixture: ComponentFixture<EditCSATComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCSATComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCSATComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
