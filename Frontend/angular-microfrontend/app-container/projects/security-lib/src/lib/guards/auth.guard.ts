import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

// PORTS
import { SecurityAbstractService } from '../services/index';
import { KEYCLOAK_INSTANCE } from '../providers';

export const createAuthJWTGuard = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    return inject(SecurityAbstractService).validateToken(route.data['roles']);
};

export const createAuthKeycloakGuard = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    const key = inject(KEYCLOAK_INSTANCE);
    const _loginPort = inject(SecurityAbstractService);

    return !!key.authenticated && !!key.realmAccess && _loginPort.validateRoles(key.realmAccess.roles, route.data['roles']);
};
