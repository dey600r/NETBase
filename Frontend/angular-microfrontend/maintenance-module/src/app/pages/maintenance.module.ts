import { RouterModule } from '@angular/router';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

import { MaintenanceComponent } from './maintenance.component';
import { DialogMaintenanceAddComponent } from './dialog-maintenance-add/dialog-maintenance-add.component';

// MODULE
import { SharedModule } from '@modules/shared.module';

@NgModule({
  declarations: [
  ],
  imports: [
    DialogMaintenanceAddComponent
  ],
  exports: [
    DialogMaintenanceAddComponent,
    SharedModule,
    RouterModule
  ],
  providers: [],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class MaintenanceModule { }
