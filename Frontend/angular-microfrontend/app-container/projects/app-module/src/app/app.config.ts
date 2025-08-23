import { ApplicationConfig, InjectionToken, provideZoneChangeDetection } from '@angular/core';

import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { environment } from '@app-environments/environment';
import { APP_CONFIG, AppConfig, ProviderInterceptorApp, SecurityAbstractService, SecurityJWTService } from 'security-lib';
import { provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { routesApp, routesJWT } from './app.routes';

export const ProviderAuthJWT = [
  { provide: SecurityAbstractService, useClass: SecurityJWTService, multi: false },
  provideHttpClient(withFetch(), withInterceptorsFromDi()),
  provideRouter([...routesJWT, ...routesApp])
];

export const appConfig: ApplicationConfig = {
  providers: [
    { provide: APP_CONFIG, useValue: environment },
    (environment.keycloak.enable ? [] : ProviderAuthJWT),
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideClientHydration(withEventReplay()), 
    //provideAnimationsAsync(),
    ProviderInterceptorApp,
  ]
};