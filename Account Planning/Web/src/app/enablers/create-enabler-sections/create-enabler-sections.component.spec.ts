import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEnablerSectionsComponent } from './create-enabler-sections.component';

describe('CreateEnablerSectionsComponent', () => {
  let component: CreateEnablerSectionsComponent;
  let fixture: ComponentFixture<CreateEnablerSectionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateEnablerSectionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateEnablerSectionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
