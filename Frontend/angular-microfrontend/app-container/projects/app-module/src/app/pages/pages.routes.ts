import { Routes } from '@angular/router';
import { UrlConstants, AppConstants } from '@app-utils/index';

import { AuthGuard } from '@app-providers/index';
import { loadRemoteModule } from '@angular-architects/module-federation';
import { environment } from '@app-environments/environment';

export const routesPages: Routes = [
    // {
    //   path: UrlConstants.URL_SETTING,
    //   loadComponent: () => import('./setting/setting.component').then(mod => mod.SettingComponent),
    //   canActivate: [AuthGuard],
    //   data: { roles: ['admin'] }
    // },
    {
      path: UrlConstants.URL_VEHICLE,
      loadChildren: () =>
                  // DYNAMIC WEB
                  loadRemoteModule({
                      type: 'module',
                      remoteEntry: environment.remotes.find(r => r.name === AppConstants.VEHICLE_MODULE)?.remoteEntry || '',
                      exposedModule: environment.remotes.find(r => r.name === AppConstants.VEHICLE_MODULE)?.exposedModule || ''
                  })
                  .then(m => m.routes)
                  .catch(err => {
                      console.warn('⚠️ No se pudo cargar VEHICLE-MODULE:', err);
                      return import('security-lib').then(m => m.errorRoutes);
                  }),
      canActivate: [AuthGuard],
      data: { roles: ['admin'] }
    },
    {
      path: UrlConstants.URL_MAINTENANCE,
      loadChildren: () =>
                  // DYNAMIC WEB
                  loadRemoteModule({
                      type: 'module',
                      remoteEntry: environment.remotes.find(r => r.name === AppConstants.MAINTENANCE_MODULE)?.remoteEntry || '',
                      exposedModule: environment.remotes.find(r => r.name === AppConstants.MAINTENANCE_MODULE)?.exposedModule || ''
                  })
                  .then(m => m.routes)
                  .catch(err => {
                      console.warn('⚠️ No se pudo cargar MAINTENANCE-MODULE:', err);
                      return import('security-lib').then(m => m.errorRoutes);
                  }),
      canActivate: [AuthGuard],
      data: { roles: ['admin', 'customer'] }
    }
];
