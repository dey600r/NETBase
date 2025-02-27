import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { VehicleComponent } from './vehicle.component';
import { DialogConfigurationAddComponent } from './dialog-configuration-add/dialog-configuration-add.component';

// MODULE
import { SharedModule } from '@modules/shared.module';

// PORTS
import { ReadVehicleUIPort, VehicleApiPort, WriteVehicleUIPort } from '@ports/index';

// DOMAIN
import { ReadVehicleDomain, WriteVehicleDomain } from '@domain/core/index';

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
    { provide: ReadVehicleUIPort, useClass: ReadVehicleDomain, multi: false },
    { provide: WriteVehicleUIPort, useClass: WriteVehicleDomain, multi: false },
    { provide: VehicleApiPort, useClass: VehicleService, multi: false },
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class VehicleModule { }
