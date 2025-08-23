import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';

import { APP_CONFIG, ProviderInterceptorApp, SecurityAbstractService, SecurityJWTService } from 'security-lib';

import { environment } from '@environments/environment';
// import { ProviderAuthJWT, ProviderAuthKeycloak } from '@providers/index';
import { provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';
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
            // provideRouter([...routesJWT, ...routes])
          provideClientHydration(withEventReplay()), 
          provideZoneChangeDetection({ eventCoalescing: true }),
          // provideRouter(routes),
          ProviderInterceptorApp,
    ]
};
