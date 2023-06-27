import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEnablersComponent } from './create-enablers.component';

describe('CreateEnablersComponent', () => {
  let component: CreateEnablersComponent;
  let fixture: ComponentFixture<CreateEnablersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateEnablersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateEnablersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
