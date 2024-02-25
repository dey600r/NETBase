import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogConfigurationAddComponent } from './dialog-configuration-add.component';

describe('DialogConfigurationAddComponent', () => {
  let component: DialogConfigurationAddComponent;
  let fixture: ComponentFixture<DialogConfigurationAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DialogConfigurationAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DialogConfigurationAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
