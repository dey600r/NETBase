import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot } from '@angular/router';
 import { createAuthJWTGuard, createAuthKeycloakGuard } from 'security-lib';

import { environment } from '@app-environments/environment';

export const AuthGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    return (environment.keycloak.enable ? 
        createAuthKeycloakGuard(route, state) : 
        createAuthJWTGuard(route, state)
    );
};