import { Routes } from '@angular/router';
import { UrlConstants } from '@app-utils/index';

import { AuthGuard } from '@app-providers/index';

export const routesPages: Routes = [
    // {
    //   path: UrlConstants.URL_SETTING,
    //   loadComponent: () => import('./setting/setting.component').then(mod => mod.SettingComponent),
    //   canActivate: [AuthGuard],
    //   data: { roles: ['admin'] }
    // },
    {
      path: UrlConstants.URL_VEHICLE,
      loadChildren: () => import('vehicle-module/routes').then(m => m.routes),
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
