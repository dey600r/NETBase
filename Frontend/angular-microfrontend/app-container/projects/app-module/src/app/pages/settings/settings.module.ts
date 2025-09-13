import { RouterModule } from '@angular/router';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

// MODULE
import { SharedModule } from '@app-modules/shared.module';

@NgModule({
  declarations: [
  ],
  imports: [
  ],
  exports: [
    SharedModule,
    RouterModule
  ],
  providers: [],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class SettingsModule { }
