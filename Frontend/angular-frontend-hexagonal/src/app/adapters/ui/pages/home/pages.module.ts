import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { provideRouter, RouterModule } from '@angular/router';

// PAGE
import { HomeComponent } from './home.component';
import { routesJWT, routesKeycloack } from './pages.routes';

// MODULE
import { SharedModule } from '@modules/shared.module';

// COMPONENTS
import { HeaderComponent } from '@components/header/header.component';
import { MenuComponent } from '@components/menu/menu.component';

import { environment } from '@environments/environment';

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
  providers: [provideRouter((environment.keycloak.enable ? routesKeycloack : routesJWT))],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class PagesModule { }
