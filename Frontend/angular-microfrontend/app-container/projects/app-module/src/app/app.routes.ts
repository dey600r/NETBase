import { Routes } from '@angular/router';

import { SecurityLibUrlConstants } from 'security-lib';

import { AuthGuard } from '@app-providers/index';

export const routesJWT: Routes = [
    {
      path: '',
      loadChildren: () => import('security-module/routes').then(m => m.routes)
    },
];

export const routesApp: Routes = [
    {
        path: '',
        redirectTo: SecurityLibUrlConstants.URL_HOME,
        pathMatch: 'full'
    },
    {
        path: SecurityLibUrlConstants.URL_HOME,
        loadComponent: () => import('@app-pages/home.component').then(m => m.HomeComponent),
        loadChildren: () => import('@app-pages/pages.routes').then(m => m.routesPages),
        canActivate: [ AuthGuard ],
        data: { roles: ['admin', 'manager', 'customer'] }
    },
    {
        path: '**',
        redirectTo: SecurityLibUrlConstants.URL_HOME
    }
];

