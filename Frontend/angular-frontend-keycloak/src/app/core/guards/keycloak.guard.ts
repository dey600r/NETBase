
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { KeycloakAuthGuard, KeycloakService } from 'keycloak-angular';
import { IPermissionsService } from './auth.interface';
import { SecurityService } from '@services/index';

@Injectable({
  providedIn: 'root'
})
export class AuthKeycloakGuard extends KeycloakAuthGuard implements IPermissionsService {
  
  constructor(
    protected override readonly router: Router,
    protected readonly keycloak: KeycloakService,
    private securityService: SecurityService
  ) {
    super(router, keycloak);
  }
  
  async isAccessAllowed(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Promise<boolean | UrlTree> {
    
    if (!this.authenticated) {
      await this.keycloak.login({
        redirectUri: window.location.origin + state.url,
      });
    }

    return this.securityService.validateRoles(this.roles, route.data['roles']);
  }
}