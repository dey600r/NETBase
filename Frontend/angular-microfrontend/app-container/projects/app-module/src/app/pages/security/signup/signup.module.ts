import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { SharedModule } from '@app-modules/shared.module';

@NgModule({
  exports: [
    SharedModule
  ],
  providers: [
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class SignupModule { }
