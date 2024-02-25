import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { HttpService, SecurityService, SettingService, VehicleService, MaintenanceService } from '@services/index';
import { MaterialModule } from '@shared/modules/material.module';
import { FlexLayoutServerModule } from '@angular/flex-layout/server';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
  declarations: [
  ],
  imports: [
    HttpClientModule,
    MaterialModule,
    FlexLayoutModule,
    FlexLayoutServerModule
  ],
  exports: [
    HttpClientModule,
    MaterialModule,
    FlexLayoutModule,
    FlexLayoutServerModule
  ],
  providers: [
    SettingService,
    SecurityService,
    MaintenanceService,
    VehicleService,
    HttpService
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class SharedModule { }
