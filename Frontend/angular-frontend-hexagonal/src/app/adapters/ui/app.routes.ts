import { Routes } from '@angular/router';
import { AuthGuard } from '@guards/auth.guard';
import { UrlConstants } from '@utils/index';

import { environment } from '@environments/environment';

const routesJWT: Routes = [
    {
        path: UrlConstants.URL_LOGIN,
        loadComponent: () => import('@pages/security/login/login.component').then(m => m.LoginComponent)
    },
    {
        path: UrlConstants.URL_SIGNUP,
        loadComponent: () => import('@pages/security/signup/signup.component').then(m => m.SignupComponent)
    }
];

const routesApp: Routes = [
    {
        path: '',
        redirectTo: UrlConstants.URL_HOME,
        pathMatch: 'full'
    },
    {
        path: UrlConstants.URL_HOME,
        loadComponent: () => import('@pages/home/home.component').then(m => m.HomeComponent),
        loadChildren: () => import('@pages/home/pages.routes').then(m => m.routesPages),
        canActivate: [AuthGuard],
        data: { roles: ['admin', 'manager', 'customer'] }
    },
    {
        path: '**',
        redirectTo: UrlConstants.URL_HOME
    }
];

export const routes: Routes = (environment.keycloak.enable ? routesApp : [...routesJWT, ...routesApp]);
