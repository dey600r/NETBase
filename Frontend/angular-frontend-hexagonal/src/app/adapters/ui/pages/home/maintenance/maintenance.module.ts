import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

import { MaintenanceComponent } from './maintenance.component';
import { DialogMaintenanceAddComponent } from './dialog-maintenance-add/dialog-maintenance-add.component';

// MODULE
import { SharedModule } from '@modules/shared.module';
import { RouterModule } from '@angular/router';

// PORTS
import { ReadMaintenanceUIPort, WriteMaintenanceUIPort } from '@ports/index';

// DOMAIN
import { ReadMaintenanceDomain, WriteMaintenanceDomain } from '@domain/core/index';

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
  providers: [
    { provide: ReadMaintenanceUIPort, useClass: ReadMaintenanceDomain, multi: false },
    { provide: WriteMaintenanceUIPort, useClass: WriteMaintenanceDomain, multi: false }
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class MaintenanceModule { }
