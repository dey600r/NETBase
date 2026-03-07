// KEYCLOAK
import { createInterceptorCondition, IncludeBearerTokenCondition } from 'keycloak-angular';
import Keycloak, { KeycloakOnLoad } from 'keycloak-js';
import { AppConfig } from '../models/index';

export function buildUrlCondition(config: AppConfig) {
  return createInterceptorCondition<IncludeBearerTokenCondition>({
    //urlPattern: /^(http:\/\/localhost:8180)(\/.*)?$/i,
    //urlPattern: /^(config.keycloak.url)(\/.*)?$/i,
    urlPattern: new RegExp(`^(${config.keycloak.url})(\\/.*)?$`, 'i'),
    bearerPrefix: 'Bearer'
  });
}

export function buildKeycloakInstance(config: AppConfig) {
  return new Keycloak({
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