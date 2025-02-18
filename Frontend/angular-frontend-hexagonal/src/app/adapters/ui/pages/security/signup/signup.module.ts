import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { SharedModule } from '@modules/shared.module';

@NgModule({
  exports: [
    SharedModule
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class SignupModule { }
