import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogSettingAddComponent } from './dialog-setting-add.component';

describe('DialogSettingAddComponent', () => {
  let component: DialogSettingAddComponent;
  let fixture: ComponentFixture<DialogSettingAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DialogSettingAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DialogSettingAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
