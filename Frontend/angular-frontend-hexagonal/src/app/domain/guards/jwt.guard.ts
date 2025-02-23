import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot, UrlTree } from '@angular/router';

import { IPermissionsService } from './auth.interface';

// PORTS
import { ILoginUIPort, LoginUIPort } from '@ports/index';

@Injectable({
    providedIn: 'root'
})
export class AuthJWTGuard implements IPermissionsService {

    // INJECTABLES
    private readonly _loginPort: ILoginUIPort = inject(LoginUIPort);

    isAccessAllowed(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        return this._loginPort.validateToken(next.data['roles']);
    }
}
  
export const AuthGuard: CanActivateFn = (next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean | UrlTree> | boolean => {
    let service: IPermissionsService = inject(AuthJWTGuard);
    
    return service.isAccessAllowed(next, state);
}

