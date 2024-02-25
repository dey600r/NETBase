import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

// PAGE
import { HomeComponent } from './home.component';
import { PagesRoutingModule } from './pages-routing.module';

// MODULE
import { SharedModule } from '@modules/shared.module';

// COMPONENTS
import { HeaderComponent } from '@components/header/header.component';
import { MenuComponent } from '@components/menu/menu.component';

@NgModule({
  declarations: [
    HomeComponent,
    HeaderComponent,
    MenuComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    SharedModule
  ],
  exports: [
    HomeComponent,
    HeaderComponent,
    MenuComponent
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class PagesModule { }
