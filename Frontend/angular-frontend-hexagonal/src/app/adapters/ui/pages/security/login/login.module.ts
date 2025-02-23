import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { SharedModule } from '@modules/shared.module';

// PORTS
import { UserUIPort, LoginUIPort } from '@app/domain/ports/index';

// DOMAIN
import { LoginDomain, UserDomain } from '@core/security/index';

@NgModule({
  exports: [
    SharedModule
  ],
  providers: [
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class LoginModule { }
