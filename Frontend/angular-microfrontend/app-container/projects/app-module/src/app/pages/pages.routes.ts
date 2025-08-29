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
      // loadChildren: () => import('vehicle-module/routes').then(m => m.routes),
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
    //   loadComponent: () => import('./vehicle/vehicle.component').then(mod => mod.VehicleComponent),
      canActivate: [AuthGuard],
      data: { roles: ['admin'] }
    },
    // {
    //   path: UrlConstants.URL_MAINTENANCE,
    //   loadComponent: () => import('./maintenance/maintenance.component').then(mod => mod.MaintenanceComponent),
    //   canActivate: [AuthGuard],
    //   data: { roles: ['admin', 'customer'] }
    // }
];
