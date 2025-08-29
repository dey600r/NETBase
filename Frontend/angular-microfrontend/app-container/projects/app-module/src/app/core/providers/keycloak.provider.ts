// KEYCLOAK
import { createInterceptorCondition, IncludeBearerTokenCondition } from 'keycloak-angular';
import Keycloak, { KeycloakOnLoad } from 'keycloak-js';
import { environment } from '@app-environments/environment';


export const urlCondition = createInterceptorCondition<IncludeBearerTokenCondition>({
  //urlPattern: /^(http:\/\/localhost:8180)(\/.*)?$/i,
  urlPattern: /^(environment.keycloak.url)(\/.*)?$/i,
  bearerPrefix: 'Bearer'
});

export const kecloakInstance = new Keycloak({
  url: environment.keycloak.url,
  realm: environment.keycloak.realm,
  clientId: environment.keycloak.clientId,
});

export function initializeKeycloak(): () => Promise<void> {
  return async () => {
    try {
      if(window !== undefined) {
        const authenticated = await kecloakInstance.init({
          onLoad: environment.keycloak.onLoad as KeycloakOnLoad, // or 'check-sso' for silent authentication
          checkLoginIframe: false
        });
        console.log('✅ Keycloak initialized', authenticated ? 'User authenticated' : 'User not authenticated');

      }
    } catch (error) {
      //console.error('❌ Keycloak initialization failed', error);
    }
  };
}