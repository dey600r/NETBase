import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { PagesRoutingModule } from './pages-routing.module';
import { HttpClientModule } from '@angular/common/http';

import { HttpService, SecurityService } from '@services/index';
import { MaterialModule } from '../../shared/modules/material.module';
import { FlexLayoutServerModule } from '@angular/flex-layout/server';
import { FlexLayoutModule } from '@angular/flex-layout';
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
    HttpClientModule,
    MaterialModule,
    FlexLayoutModule,
    FlexLayoutServerModule
  ],
  exports: [
    HomeComponent,
    HeaderComponent,
    MenuComponent
  ],
  providers: [
    SecurityService,
    HttpService
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class PagesModule { }
