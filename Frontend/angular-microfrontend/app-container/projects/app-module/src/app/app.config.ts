import { ApplicationConfig, provideAppInitializer, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withFetch, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { AutoRefreshTokenService, INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, includeBearerTokenInterceptor, UserActivityService } from 'keycloak-angular';

import { environment } from '@app-environments/environment';
import { initializeKeycloak, kecloakInstance, urlCondition } from '@app-providers/index';
import { 
  APP_CONFIG, KEYCLOAK_INSTANCE, ProviderInterceptorApp, SecurityAbstractService, SecurityJWTService, SecurityKeycloakService 
} from 'security-lib';
import { routesApp, routesJWT } from './app.routes';

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
  { provide: KEYCLOAK_INSTANCE, useValue: kecloakInstance },
]

export const appConfig: ApplicationConfig = {
  providers: [
    { provide: APP_CONFIG, useValue: environment },
    (environment.keycloak.enable ? ProviderAuthKeycloak : ProviderAuthJWT),
    { provide: SecurityAbstractService, useClass: SecurityKeycloakService, multi: false },
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideClientHydration(withEventReplay()), 
    provideAnimationsAsync(),
    ProviderInterceptorApp
  ]
};