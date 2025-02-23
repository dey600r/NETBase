import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { SharedModule } from '@modules/shared.module';

// PORTS
import { UserUIPort, SignupUIPort } from '@app/domain/ports/index';

// DOMAIN
import { SignUpDomain, UserDomain } from '@core/security/index';

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
