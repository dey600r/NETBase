import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

// KEYCLOAK
// import Keycloak from 'keycloak-js';

// PORTS
import { SecurityAbstractService } from '@lib-services/index';

export const createAuthJWTGuard = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    return inject(SecurityAbstractService).validateToken(route.data['roles']);
};

export const createAuthKeycloakGuard = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    // const key = inject(Keycloak);
    // const _loginPort = inject(SecurityAbstractService);

    // return !!key.authenticated && !!key.realmAccess && _loginPort.validateRoles(key.realmAccess.roles, route.data['roles']);
    return true;
};

// export const AuthGuard: CanActivateFn = (inject(AppConfig).keycloak.enable ? 
//     createAuthKeycloakGuard :
//     createAuthJWTGuard
// );
