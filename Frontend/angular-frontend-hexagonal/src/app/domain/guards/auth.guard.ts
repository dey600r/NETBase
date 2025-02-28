import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { AuthGuardData, createAuthGuard } from 'keycloak-angular';

// PORTS
import { LoginUIPort } from '@ports/index';
import { environment } from '@environments/environment';

const createAuthJWTGuard = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    return inject(LoginUIPort).validateToken(route.data['roles']);
};

const isKeycloackAccessAllowed = async (route: ActivatedRouteSnapshot, state: RouterStateSnapshot, authData: AuthGuardData): Promise<boolean | UrlTree> => {
    
    const { authenticated, grantedRoles } = authData;

    const _loginPort = inject(LoginUIPort);

    if(authenticated && Object.values(grantedRoles.resourceRoles).some(x => _loginPort.validateRoles(x, route.data['roles']))) {
        return true;
    }

    const router = inject(Router);
    return router.parseUrl(state.url);
};

export const AuthGuard: CanActivateFn = (environment.keycloak.enable ? 
    createAuthGuard<CanActivateFn>(isKeycloackAccessAllowed) : 
    createAuthJWTGuard
);
