import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot, UrlTree } from '@angular/router';
import { SecurityService } from '@services/index';
import { IPermissionsService } from './auth.interface';

@Injectable({
    providedIn: 'root'
})
export class AuthJWTGuard implements IPermissionsService {

    constructor( private securityService: SecurityService ) {}

    isAccessAllowed(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        return this.securityService.validateToken();
    }
}
  
export const AuthGuard: CanActivateFn = (next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean | UrlTree> | boolean => {
    let service: IPermissionsService = inject(AuthJWTGuard);
    
    return service.isAccessAllowed(next, state);
}

