import { RouterModule } from '@angular/router';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

import { MaintenanceComponent } from './maintenance.component';
import { DialogMaintenanceAddComponent } from './dialog-maintenance-add/dialog-maintenance-add.component';

// MODULE
import { SharedModule } from '@modules/shared.module';

// PORTS
import { MaintenanceApiPort, QueryMaintenanceUIPort, CommandMaintenanceUIPort } from '@ports/index';

// DOMAIN
import { QueryMaintenanceDomain, CommandMaintenanceDomain } from '@domain/core/index';

// ADAPTERS
import { MaintenanceService } from '@api/index';

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
    { provide: QueryMaintenanceUIPort, useClass: QueryMaintenanceDomain, multi: false },
    { provide: CommandMaintenanceUIPort, useClass: CommandMaintenanceDomain, multi: false },
    { provide: MaintenanceApiPort, useClass: MaintenanceService, multi: false },
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class MaintenanceModule { }
