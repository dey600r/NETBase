import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot } from '@angular/router';
import { inject } from '@angular/core';
import { APP_CONFIG } from './app-config.provider';
import { createAuthJWTGuard, createAuthKeycloakGuard } from '../guards/index';

export const AuthGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    const config = inject(APP_CONFIG);
    return (config.keycloak.enable ? 
        createAuthKeycloakGuard(route, state) : 
        createAuthJWTGuard(route, state)
    );
};