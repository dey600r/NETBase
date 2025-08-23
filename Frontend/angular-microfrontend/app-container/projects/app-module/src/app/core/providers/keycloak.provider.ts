import { provideHttpClient, withFetch, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';

// KEYCLOAK
// import { 
//   AutoRefreshTokenService, UserActivityService, 
//   createInterceptorCondition, IncludeBearerTokenCondition, INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, 
//   includeBearerTokenInterceptor,

// } from 'keycloak-angular';
// import Keycloak, { KeycloakOnLoad } from 'keycloak-js';
import { environment } from '@app-environments/environment';
import { routesApp } from '@app/app.routes';

// SERVICES
// import { SecurityKeycloakService, SecurityService } from 'security-lib';

// DOMAINS
import { provideAppInitializer } from '@angular/core';
import { provideRouter } from '@angular/router';


// const urlCondition = createInterceptorCondition<IncludeBearerTokenCondition>({
//   //urlPattern: /^(http:\/\/localhost:8180)(\/.*)?$/i,
//   urlPattern: /^(environment.keycloak.url)(\/.*)?$/i,
//   bearerPrefix: 'Bearer'
// });

// export const kecloakInstance = new Keycloak({
//   url: environment.keycloak.url,
//   realm: environment.keycloak.realm,
//   clientId: environment.keycloak.clientId,
// });

// export function initializeKeycloak(): () => Promise<void> {
//   return async () => {
//     try {
//       if(window !== undefined) {
//         const authenticated = await kecloakInstance.init({
//           onLoad: environment.keycloak.onLoad as KeycloakOnLoad, // or 'check-sso' for silent authentication
//           checkLoginIframe: false
//         });
//         console.log('✅ Keycloak initialized', authenticated ? 'User authenticated' : 'User not authenticated');

//       }
//     } catch (error) {
//       //console.error('❌ Keycloak initialization failed', error);
//     }
//   };
// }


export const ProviderAuthKeycloak = [
  // provideAppInitializer(initializeKeycloak()),
  //provideRouter(routesApp),
  // provideHttpClient(withFetch(), withInterceptorsFromDi(), withInterceptors([includeBearerTokenInterceptor])),
  // AutoRefreshTokenService, UserActivityService,
  // { provide: INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, useValue: [urlCondition] },
  // { provide: SecurityService, useClass: SecurityKeycloakService, multi: false },
  // { provide: Keycloak, useValue: kecloakInstance }
];