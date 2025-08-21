import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule } from '@angular/router';

// MODULE
import { SharedModule } from '@app-modules/shared.module';

// COMPONENTS
import { HeaderComponent } from '@app-components/header/header.component';
import { MenuComponent } from '@app-components/menu/menu.component';

@NgModule({
  declarations: [
  ],
  imports: [
    HeaderComponent,
    MenuComponent
  ],
  exports: [
    HeaderComponent,
    MenuComponent,
    SharedModule,
    RouterModule
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class PagesModule { }
