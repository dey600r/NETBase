import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecurityLibComponent } from './security-lib.component';

describe('SecurityLibComponent', () => {
  let component: SecurityLibComponent;
  let fixture: ComponentFixture<SecurityLibComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SecurityLibComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SecurityLibComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
