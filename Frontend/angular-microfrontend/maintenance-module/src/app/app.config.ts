import { ApplicationConfig, provideAppInitializer, provideZoneChangeDetection } from '@angular/core';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';

import { 
  APP_CONFIG, KEYCLOAK_INSTANCE, ProviderInterceptorApp, SecurityAbstractService, SecurityJWTService, SecurityKeycloakService 
} from 'security-lib';

import { environment } from '@environments/environment';
import { provideHttpClient, withFetch, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { routesApp, routesJWT } from './app.routes';
import { initializeKeycloak, kecloakInstance, urlCondition } from '@providers/index';
import { AutoRefreshTokenService, INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, includeBearerTokenInterceptor, UserActivityService } from 'keycloak-angular';

export const ProviderAuthJWT = [
  { provide: SecurityAbstractService, useClass: SecurityJWTService, multi: false },
  provideHttpClient(withFetch(), withInterceptorsFromDi()),
  provideRouter([...routesJWT, ...routesApp])
];

const ProviderAuthKeycloak = [
  provideAppInitializer(initializeKeycloak()),
  provideRouter(routesApp),
  provideHttpClient(withFetch(), withInterceptorsFromDi(), withInterceptors([includeBearerTokenInterceptor])),
  AutoRefreshTokenService, UserActivityService,
  { provide: INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, useValue: [urlCondition] },
  { provide: SecurityAbstractService, useClass: SecurityKeycloakService, multi: false },
  { provide: KEYCLOAK_INSTANCE, useValue: kecloakInstance }
]

export const appConfig: ApplicationConfig = {
  providers: [
    { provide: APP_CONFIG, useValue: environment },
    (environment.keycloak.enable ? ProviderAuthKeycloak : ProviderAuthJWT),
    provideClientHydration(withEventReplay()), 
    provideZoneChangeDetection({ eventCoalescing: true }),
    ProviderInterceptorApp,
  ]
};
