import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { SharedModule } from '@modules/shared.module';

// PORTS
import { SignupUIPort } from '@ports/index';

// DOMAIN
import { SignUpDomain } from '@domain/core/index';

@NgModule({
  exports: [
    SharedModule
  ],
  providers: [
    { provide: SignupUIPort, useClass: SignUpDomain, multi: false }
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class SignupModule { }
