import { provideKeycloak, withAutoRefreshToken, AutoRefreshTokenService, UserActivityService } from 'keycloak-angular';
import { KeycloakOnLoad } from 'keycloak-js';

import { environment } from '@environments/environment';

// PORTS
import { LoginUIPort } from '@ports/index';

// DOMAINS
import { LoginKeycloakDomain } from '@domain/core/index';

const provideKeycloakAngular = () =>
  provideKeycloak({
    config: {
      url: environment.keycloak.url,
      realm: environment.keycloak.realm,
      clientId: environment.keycloak.clientId,
    },
    initOptions: {
      onLoad: environment.keycloak.onLoad as KeycloakOnLoad,  // allowed values 'login-required', 'check-sso';
      //flow: "standard",          // allowed values 'standard', 'implicit', 'hybrid';
    },
    features: [
      withAutoRefreshToken({
        onInactivityTimeout: 'logout',
        sessionTimeout: 60000
      })
    ],
    providers: [AutoRefreshTokenService, UserActivityService]
  });

  export const ProviderAuthKeycloak = [
    provideKeycloakAngular(),
    { provide: LoginUIPort, useClass: LoginKeycloakDomain, multi: false },
  ];