import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { PagesRoutingModule } from './pages-routing.module';
import { HttpClientModule } from '@angular/common/http';

import { HttpService, SecurityService } from '@services/index';


@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    HttpClientModule
  ],
  exports: [
    HomeComponent
  ],
  providers: [
    SecurityService,
    HttpService
  ],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class PagesModule { }
