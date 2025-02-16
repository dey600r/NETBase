import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { HttpClientModule, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';

import { ProviderInterceptorApp } from '@providers/index';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideRouter(routes), 
    provideClientHydration(withEventReplay()), 
    provideAnimationsAsync(),
    provideHttpClient(withInterceptorsFromDi()),
    //importProvidersFrom(HttpClientModule),
    ProviderInterceptorApp
  ]
};
