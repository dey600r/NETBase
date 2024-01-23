import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@app/shared/modules/shared.module';
import { VehicleComponent } from './vehicle.component';
import { VehicleRoutingModule } from './vehicle-routing.module';



@NgModule({
  declarations: [
    VehicleComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    VehicleRoutingModule
  ],
  exports: [
    VehicleComponent
  ]
})
export class VehicleModule { }
