import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { VehicleComponent } from './vehicle.component';
import { DialogConfigurationAddComponent } from './dialog-configuration-add/dialog-configuration-add.component';

// MODULE
import { SharedModule } from '@modules/shared.module';

@NgModule({
  declarations: [
  ],
  imports: [
    // VehicleComponent,
    DialogConfigurationAddComponent
  ],
  exports: [
    // VehicleComponent,
    DialogConfigurationAddComponent,
    SharedModule,
    RouterModule
  ],
  providers: [
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class VehicleModule { }
