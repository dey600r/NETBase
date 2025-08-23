import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { environment } from '@environments/environment';
import { APP_CONFIG, ProviderInterceptorApp, SecurityAbstractService, SecurityJWTService } from 'security-lib';
import { provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    { provide: APP_CONFIG, useValue: environment },
    { provide: SecurityAbstractService, useClass: SecurityJWTService, multi: false },
    provideHttpClient(withFetch(), withInterceptorsFromDi()),
    provideClientHydration(withEventReplay()), 
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideRouter(routes),
    ProviderInterceptorApp
  ]
};
