import { KeycloakService } from "keycloak-angular";
import { environment } from '@environments/environment';
import { KeycloakOnLoad } from "keycloak-js";
import { APP_INITIALIZER } from "@angular/core";

function initializeKeycloak(keycloak: KeycloakService) {
      return () => keycloak.init({
          config: {
            url: environment.keycloak.url,
            realm: environment.keycloak.realm,
            clientId: environment.keycloak.clientId,
          },
          initOptions: {
            onLoad: environment.keycloak.onLoad as KeycloakOnLoad,  // allowed values 'login-required', 'check-sso';
            //flow: "standard",          // allowed values 'standard', 'implicit', 'hybrid';
          },
        }).then(x => console.log('Keycloack init', x))
        .catch(err => console.error('keycloak err', err));
  }

  export const ProvidersAuthApp = [
    { provide: APP_INITIALIZER, useFactory: initializeKeycloak, multi: true, deps: [KeycloakService] }
  ];