import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot } from '@angular/router';

// KEYCLOAK
import { APP_CONFIG, KEYCLOAK_INSTANCE } from '@providers/index';

// PORTS
import { LoginUIPort } from '@ports/index';

const createAuthJWTGuard = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    return inject(LoginUIPort).validateToken(route.data['roles']);
};

const createAuthKeycloakGuard = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    const key = inject(KEYCLOAK_INSTANCE);
    const _loginPort = inject(LoginUIPort);

    return !!key.authenticated && !!key.realmAccess && _loginPort.validateRoles(key.realmAccess.roles, route.data['roles']);
};

export const AuthGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    const config = inject(APP_CONFIG);
    return (config.keycloak.enable ? 
        createAuthKeycloakGuard(route, state) : 
        createAuthJWTGuard(route, state)
    );
};
