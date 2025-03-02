import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot } from '@angular/router';

// KEYCLOAK
import Keycloak from 'keycloak-js';

// PORTS
import { LoginUIPort } from '@ports/index';
import { environment } from '@environments/environment';

const createAuthJWTGuard = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    return inject(LoginUIPort).validateToken(route.data['roles']);
};

const createAuthKeycloakGuard = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    const key = inject(Keycloak);
    const _loginPort = inject(LoginUIPort);

    return !!key.authenticated && !!key.realmAccess && _loginPort.validateRoles(key.realmAccess.roles, route.data['roles']);
};

export const AuthGuard: CanActivateFn = (environment.keycloak.enable ? 
    createAuthKeycloakGuard :
    createAuthJWTGuard
);
