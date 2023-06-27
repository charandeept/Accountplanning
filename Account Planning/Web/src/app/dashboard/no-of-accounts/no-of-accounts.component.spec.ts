import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoOfAccountsComponent } from './no-of-accounts.component';

describe('NoOfAccountsComponent', () => {
  let component: NoOfAccountsComponent;
  let fixture: ComponentFixture<NoOfAccountsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoOfAccountsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NoOfAccountsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
