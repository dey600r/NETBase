import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

import { MaintenanceComponent } from './maintenance.component';
import { DialogMaintenanceAddComponent } from './dialog-maintenance-add/dialog-maintenance-add.component';

// MODULE
import { SharedModule } from '@modules/shared.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
  ],
  imports: [
    MaintenanceComponent,
    DialogMaintenanceAddComponent
  ],
  exports: [
    MaintenanceComponent,
    DialogMaintenanceAddComponent,
    SharedModule,
    RouterModule
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class MaintenanceModule { }
