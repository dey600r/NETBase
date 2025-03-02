import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';

import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { ProviderInterceptorApp, ProviderCoreApp, ProviderAuthJWT, ProviderAuthKeycloak } from '@providers/index';

import { environment } from '@environments/environment';


export const appConfig: ApplicationConfig = {
  providers: [
    (environment.keycloak.enable ? ProviderAuthKeycloak : ProviderAuthJWT),
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideClientHydration(withEventReplay()), 
    provideAnimationsAsync(),
    ProviderInterceptorApp,
    ProviderCoreApp
  ]
};
