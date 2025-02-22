import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { SharedModule } from '@modules/shared.module';

// PORTS
import { UserUIPort, LoginUIPort } from '@ports/index';

// DOMAIN
import { LoginDomain, UserDomain } from '@core/security/index';

@NgModule({
  exports: [
    SharedModule
  ],
  providers: [
    { provide: UserUIPort, useClass: UserDomain, multi: false },
    { provide: LoginUIPort, useClass: LoginDomain, multi: false }
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class LoginModule { }
