import { Routes } from '@angular/router';
import { loadRemoteModule } from '@angular-architects/module-federation';

import { AppConfig, SecurityLibUrlConstants } from 'security-lib';

import { AuthGuard } from '@app-providers/index';

import { AppConstants } from '@app-utils/index';

export function buildRoutesJWT(config: AppConfig): Routes {
    const securityModule = config.remotes.find(r => r.name === AppConstants.SECURITY_MODULE);
    return [
        {
            path: '',
            loadChildren: () =>
                // DYNAMIC WEB
                loadRemoteModule({
                    type: 'module',
                    remoteEntry: securityModule?.remoteEntry || '',
                    exposedModule: securityModule?.exposedModule || ''
                })
                .then(m => m.routes)
                .catch(err => {
                    console.warn('⚠️ No se pudo cargar SECURITY-MODULE:', err);
                    return import('security-lib').then(m => m.errorRoutes);
                }),
        //   loadChildren: () => import('security-module/routes').then(m => m.routes) --> STATIC WEB
        },
    ];
}

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
