import { ApplicationConfig, provideAppInitializer, Provider, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withFetch, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { AutoRefreshTokenService, INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, includeBearerTokenInterceptor, UserActivityService } from 'keycloak-angular';

import { environment } from '@app-environments/environment';
import { buildKeycloakInstance, buildUrlCondition, initializeKeycloak } from '@app-providers/index';
import { 
  APP_CONFIG, AppConfig, ENV_CONFIG, KEYCLOAK_INSTANCE, ProviderInterceptorApp, SecurityAbstractService, SecurityJWTService, SecurityKeycloakService 
} from 'security-lib';
import { buildRoutesApp, buildRoutesJWT } from './app.routes';

export function buildConfiguration(config: AppConfig): ApplicationConfig {
  
  let ProviderSecurity: any[] = [];
  if(config.keycloak.enable) {
    const keycloakInstance = buildKeycloakInstance(config);
    ProviderSecurity = [
      provideAppInitializer(initializeKeycloak(config, keycloakInstance)),
      provideRouter(buildRoutesApp(config)),
      provideHttpClient(withFetch(), withInterceptorsFromDi(), withInterceptors([includeBearerTokenInterceptor])),
      AutoRefreshTokenService, UserActivityService,
      { provide: INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, useValue: [buildUrlCondition(config)] },
      { provide: SecurityAbstractService, useClass: SecurityKeycloakService, multi: false },
      { provide: KEYCLOAK_INSTANCE, useValue: keycloakInstance },
    ];
  } else {
    ProviderSecurity = [
      { provide: SecurityAbstractService, useClass: SecurityJWTService, multi: false },
      provideHttpClient(withFetch(), withInterceptorsFromDi()),
      provideRouter([...buildRoutesApp(config), ...buildRoutesJWT(config)])
    ];
  }
  
  return {
    providers: [
      { provide: ENV_CONFIG, useValue: environment },
      { provide: APP_CONFIG, useValue: config },
      provideZoneChangeDetection({ eventCoalescing: true }), 
      provideClientHydration(withEventReplay()), 
      provideAnimationsAsync(),
      ...ProviderSecurity,
      ...ProviderInterceptorApp
    ]
  };
}