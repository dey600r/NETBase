import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';

import { APP_CONFIG, ProviderInterceptorApp } from 'security-lib';

import { routes } from './app.routes';
import { environment } from '@environments/environment';
import { ProviderAuthJWT, ProviderAuthKeycloak } from '@providers/index';

export const appConfig: ApplicationConfig = {
  providers: [
    { provide: APP_CONFIG, useValue: environment },
    (environment.keycloak.enable ? ProviderAuthKeycloak : ProviderAuthJWT),
    provideClientHydration(withEventReplay()), 
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideRouter(routes),
    ProviderInterceptorApp
  ]
};