import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot } from '@angular/router';
 import { APP_CONFIG, createAuthJWTGuard, createAuthKeycloakGuard } from 'security-lib';

import { inject } from '@angular/core';

export const AuthGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    const config = inject(APP_CONFIG);
    return (config.keycloak.enable ? 
        createAuthKeycloakGuard(route, state) : 
        createAuthJWTGuard(route, state)
    );
};