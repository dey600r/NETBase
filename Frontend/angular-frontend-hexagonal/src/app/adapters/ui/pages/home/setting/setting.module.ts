import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SharedModule } from '@modules/shared.module'
import { SettingComponent } from './setting.component';
import { DialogSettingAddComponent } from './dialog-setting-add/dialog-setting-add.component';

// PORTS
import { ReadSettingUIPort, SettingApiPort, WriteSettingUIPort } from '@ports/index';

// DOMAIN
import { ReadSettingDomain, WriteSettingDomain } from '@domain/core/index';

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
    { provide: ReadSettingUIPort, useClass: ReadSettingDomain, multi: false },
    { provide: WriteSettingUIPort, useClass: WriteSettingDomain, multi: false },
    { provide: SettingApiPort, useClass: SettingService, multi: false },
  ],
})
export class SettingModule { }
