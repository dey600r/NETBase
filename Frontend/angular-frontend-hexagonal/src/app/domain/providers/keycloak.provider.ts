import { provideAppInitializer } from '@angular/core';
import { provideHttpClient, withFetch, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { provideRouter } from '@angular/router';

// KEYCLOAK
import { 
  AutoRefreshTokenService,
  createInterceptorCondition, INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, IncludeBearerTokenCondition,
  includeBearerTokenInterceptor,
  UserActivityService, 

} from 'keycloak-angular';
import KeycloakModule, { KeycloakOnLoad } from 'keycloak-js';
import type Keycloak from 'keycloak-js';

// DOMAINS
import { AppConfig } from '@models/index';
import { routesApp } from '@adapters/ui/app.routes';
import { LoginUIPort } from '@ports/index';
import { LoginKeycloakDomain } from '@core/index';
import { KEYCLOAK_INSTANCE } from './app-config.provider';


export function buildUrlCondition(config: AppConfig) {
  return createInterceptorCondition<IncludeBearerTokenCondition>({
    //urlPattern: /^(http:\/\/localhost:8180)(\/.*)?$/i,
    //urlPattern: /^(config.keycloak.url)(\/.*)?$/i,
    urlPattern: new RegExp(`^(${config.keycloak.url})(\\/.*)?$`, 'i'),
    bearerPrefix: 'Bearer'
  });
}

const KeycloakCtor = (KeycloakModule as any).default || KeycloakModule;

export function buildKeycloakInstance(config: AppConfig) {
  return new KeycloakCtor({
    url: config.keycloak.url,
    realm: config.keycloak.realm,
    clientId: config.keycloak.clientId,
  });
}

export function initializeKeycloak(config: AppConfig, keycloakInstance: Keycloak): () => Promise<void> {
  return async () => {
    try {
      if(window !== undefined) {
        const authenticated = await keycloakInstance.init({
          onLoad: config.keycloak.onLoad as KeycloakOnLoad, // or 'check-sso' for silent authentication
          checkLoginIframe: false
        });
        console.log('✅ Keycloak initialized', authenticated ? 'User authenticated' : 'User not authenticated');

      }
    } catch (error) {
      //console.error('❌ Keycloak initialization failed', error);
    }
  };
}

export function buildProviderAuthKeycloak(config: AppConfig) {
  const keycloakInstance = buildKeycloakInstance(config);
  return [
      provideAppInitializer(initializeKeycloak(config, keycloakInstance)),
      provideRouter(routesApp),
      provideHttpClient(withFetch(), withInterceptorsFromDi(), withInterceptors([includeBearerTokenInterceptor])),
      AutoRefreshTokenService, UserActivityService,
      { provide: INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, useValue: [buildUrlCondition(config)] },
      { provide: LoginUIPort, useClass: LoginKeycloakDomain, multi: false },
      { provide: KEYCLOAK_INSTANCE, useValue: keycloakInstance }
  ];
}

          