import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogMaintenanceAddComponent } from './dialog-maintenance-add.component';

describe('DialogMaintenanceAddComponent', () => {
  let component: DialogMaintenanceAddComponent;
  let fixture: ComponentFixture<DialogMaintenanceAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DialogMaintenanceAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DialogMaintenanceAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
