import { Routes } from '@angular/router';
import { loadRemoteModule } from '@angular-architects/module-federation';

import { AuthGuard } from '@providers/index';
import { environment } from '@environments/environment';
import { AppConstants } from '@utils/index';

import { SecurityLibUrlConstants } from 'security-lib';

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
    loadChildren: () => import('./pages/vehicle.routes').then(m => m.routes)  ,
    canActivate: [AuthGuard],
    data: { roles: ['admin'] }
  },
  {
    path: '**',
    redirectTo: SecurityLibUrlConstants.URL_HOME
  }
];
