import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@shared/modules/shared.module';
import { MaintenanceRoutingModule } from './maintenance-routing.module';
import { MaintenanceComponent } from './maintenance.component';



@NgModule({
  declarations: [
    MaintenanceComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MaintenanceRoutingModule
  ],
  exports: [
    MaintenanceComponent
  ]
})
export class MaintenanceModule { }
