import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { SecurityService } from '@services/index';

@Injectable({
    providedIn: 'root'
})
class PermissionsJWTService implements IPermissionsService {

    constructor( private securityService: SecurityService ) {}

    isAccessAllowed(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        return this.securityService.validateToken();
    }
}

export interface IPermissionsService {
    isAccessAllowed(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Promise<boolean | UrlTree>;
}
  
export const AuthGuard: CanActivateFn = (next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean | UrlTree> | boolean => {
    let service: IPermissionsService = inject(PermissionsJWTService);
    return service.isAccessAllowed(next, state);
}