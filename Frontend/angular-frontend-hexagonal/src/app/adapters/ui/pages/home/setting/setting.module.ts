import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SharedModule } from '@modules/shared.module'
import { SettingComponent } from './setting.component';
import { DialogSettingAddComponent } from './dialog-setting-add/dialog-setting-add.component';

// PORTS
import { QuerySettingUIPort, SettingApiPort, CommandSettingUIPort } from '@ports/index';

// DOMAIN
import { QuerySettingDomain, CommandSettingDomain } from '@domain/core/index';

// ADAPTERS
import { SettingService } from '@api/index';

@NgModule({
  declarations: [
  ],
  imports: [
    SettingComponent,
    DialogSettingAddComponent
  ],
  exports: [
    SettingComponent,
    DialogSettingAddComponent,
    SharedModule,
    RouterModule
  ],
  providers: [
    { provide: QuerySettingUIPort, useClass: QuerySettingDomain, multi: false },
    { provide: CommandSettingUIPort, useClass: CommandSettingDomain, multi: false },
    { provide: SettingApiPort, useClass: SettingService, multi: false },
  ],
})
export class SettingModule { }
