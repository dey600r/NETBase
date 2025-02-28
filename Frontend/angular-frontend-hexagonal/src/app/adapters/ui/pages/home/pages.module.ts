import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule } from '@angular/router';

// PAGE
import { HomeComponent } from './home.component';
// MODULE
import { SharedModule } from '@modules/shared.module';

// COMPONENTS
import { HeaderComponent } from '@components/header/header.component';
import { MenuComponent } from '@components/menu/menu.component';

@NgModule({
  declarations: [
  ],
  imports: [
    HomeComponent,
    HeaderComponent,
    MenuComponent
  ],
  exports: [
    HomeComponent,
    HeaderComponent,
    MenuComponent,
    SharedModule,
    RouterModule
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class PagesModule { }
