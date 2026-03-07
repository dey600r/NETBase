import { Routes } from '@angular/router';

import { AppConfig, AuthGuard, SecurityLibUrlConstants } from 'security-lib';

export function buildRoutesApp(config: AppConfig): Routes {
    return [
        {
            path: '',
            redirectTo: SecurityLibUrlConstants.URL_HOME,
            pathMatch: 'full'
        },
        {
            path: SecurityLibUrlConstants.URL_HOME,
            loadComponent: () => import('@app-pages/home.component').then(m => m.HomeComponent),
            loadChildren: () => import('@app-pages/pages.routes').then(m => m.buildRoutesPages(config)),
            canActivate: [ AuthGuard ],
            data: { roles: ['admin', 'manager', 'customer'] }
        },
        // {
        //     path: '**',
        //     redirectTo: SecurityLibUrlConstants.URL_HOME
        // }
    ];
}
