import { Routes } from '@angular/router';
import { loadRemoteModule } from '@angular-architects/module-federation';

import { SecurityLibUrlConstants } from 'security-lib';

import { AuthGuard } from '@app-providers/index';

import { environment } from '@app-environments/environment';
import { AppConstants } from '@app-utils/index';

export const routesJWT: Routes = [
    {
        path: '',
        loadChildren: () =>
            // DYNAMIC WEB
            loadRemoteModule({
                type: 'module',
                remoteEntry: environment.remotes.find(r => r.name === AppConstants.SECURITY_MODULE)?.remoteEntry || '',
                exposedModule: environment.remotes.find(r => r.name === AppConstants.SECURITY_MODULE)?.exposedModule || ''
            })
            .then(m => m.routes)
            .catch(err => {
                console.warn('⚠️ No se pudo cargar SECURITY-MODULE:', err);
                return import('security-lib').then(m => m.errorRoutes);
            }),
    //   loadChildren: () => import('security-module/routes').then(m => m.routes) --> STATIC WEB
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

