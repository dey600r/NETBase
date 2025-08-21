import { Routes } from '@angular/router';

import { UrlConstants } from '@app-utils/index';

import { AuthGuard } from '@app-providers/index';

export const routesJWT: Routes = [
    {
        path: UrlConstants.URL_LOGIN,
        loadComponent: () => import('@app-pages/security/login/login.component').then(m => m.LoginComponent)
    },
    {
        path: UrlConstants.URL_SIGNUP,
        loadComponent: () => import('@app-pages/security/signup/signup.component').then(m => m.SignupComponent)
    }
];

export const routesApp: Routes = [
    {
        path: '',
        redirectTo: UrlConstants.URL_HOME,
        pathMatch: 'full'
    },
    {
        path: UrlConstants.URL_HOME,
        loadComponent: () => import('@app-pages/home/home.component').then(m => m.HomeComponent),
        loadChildren: () => import('@app-pages/home/pages.routes').then(m => m.routesPages),
        //canActivate: [ AuthGuard ],
        data: { roles: ['admin', 'manager', 'customer'] }
    },
    {
        path: '**',
        redirectTo: UrlConstants.URL_HOME
    }
];

