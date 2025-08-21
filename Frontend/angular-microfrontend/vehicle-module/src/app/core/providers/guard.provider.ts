import { CanActivateFn } from '@angular/router';
import { createAuthKeycloakGuard, createAuthJWTGuard } from 'security-lib';

import { environment } from '@environments/environment';

export const AuthGuard: CanActivateFn = (environment.keycloak.enable ? 
    createAuthKeycloakGuard :
    createAuthJWTGuard
);
