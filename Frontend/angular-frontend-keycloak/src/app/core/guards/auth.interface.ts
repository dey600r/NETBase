import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from "@angular/router";

export interface IPermissionsService {
    isAccessAllowed(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Promise<boolean | UrlTree>;
}