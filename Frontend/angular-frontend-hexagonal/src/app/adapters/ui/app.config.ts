import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routesApp, routesJWT } from './app.routes';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';

import { ProviderInterceptorApp, ProviderCoreApp, ProviderAuthJWT, ProviderAuthKeycloak } from '@providers/index';

import { environment } from '@environments/environment';


export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideRouter((environment.keycloak.enable ? routesApp : [...routesJWT, ...routesApp])), 
    provideClientHydration(withEventReplay()), 
    provideAnimationsAsync(),
    provideHttpClient(withFetch(), withInterceptorsFromDi()),
    ProviderInterceptorApp,
    ProviderCoreApp,
    (environment.keycloak.enable ? ProviderAuthKeycloak : ProviderAuthJWT)
  ]
};
