import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { VehicleComponent } from './vehicle.component';
import { DialogConfigurationAddComponent } from './dialog-configuration-add/dialog-configuration-add.component';

// MODULE
import { SharedModule } from '@modules/shared.module';

// PORTS
import { QueryVehicleUIPort, VehicleApiPort, CommandVehicleUIPort } from '@ports/index';

// DOMAIN
import { QueryVehicleDomain, CommandVehicleDomain } from '@domain/core/index';

// ADAPTERS
import { VehicleService } from '@api/index';

@NgModule({
  declarations: [
  ],
  imports: [
    VehicleComponent,
    DialogConfigurationAddComponent
  ],
  exports: [
    VehicleComponent,
    DialogConfigurationAddComponent,
    SharedModule,
    RouterModule
  ],
  providers: [
    { provide: QueryVehicleUIPort, useClass: QueryVehicleDomain, multi: false },
    { provide: CommandVehicleUIPort, useClass: CommandVehicleDomain, multi: false },
    { provide: VehicleApiPort, useClass: VehicleService, multi: false },
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class VehicleModule { }
