import { ApplicationConfig, InjectionToken, provideZoneChangeDetection } from '@angular/core';

import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { AuthGuard, ProviderAuthJWT, ProviderAuthKeycloak } from '@app-providers/index';

import { environment } from '@app-environments/environment';
import { APP_CONFIG, AppConfig, ProviderInterceptorApp } from 'security-lib';


export const appConfig: ApplicationConfig = {
  providers: [
    { provide: APP_CONFIG, useValue: environment },
    (environment.keycloak.enable ? ProviderAuthKeycloak : ProviderAuthJWT),
    //AuthGuard,
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideClientHydration(withEventReplay()), 
    //provideAnimationsAsync(),
    ProviderInterceptorApp,
  ]
};