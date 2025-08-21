import { inject, Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
 import { createAuthKeycloakGuard, createAuthJWTGuard, AppConfig } from 'security-lib';

import { environment } from '@app-environments/environment';
// import { SecurityAbstractService } from 'security-lib';

// const createAuthJWTGuard = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
//     return inject(SecurityAbstractService).validateToken(route.data['roles']);
// };

// const createAuthKeycloakGuard = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
//     // const key = inject(Keycloak);
//     // const _loginPort = inject(SecurityAbstractService);

//     // return !!key.authenticated && !!key.realmAccess && _loginPort.validateRoles(key.realmAccess.roles, route.data['roles']);
//     return true;
// };

// export const AuthGuard: CanActivateFn = (environment.keycloak.enable ? 
//     createAuthKeycloakGuard :
//     createAuthJWTGuard
// );

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {

    constructor(private router: Router) {}
    // canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    //         if (environment.keycloak.enable) {
    //             return createAuthKeycloakGuard(route, state);
    //         } else {
    //             return createAuthJWTGuard(route, state);
    //         }
    //     }
    canActivate(): boolean {
    // tu lógica de auth
    return true;
  }
//   canActivate = (environment.keycloak.enable ? 
//     createAuthKeycloakGuard :
//     createAuthJWTGuard);
}