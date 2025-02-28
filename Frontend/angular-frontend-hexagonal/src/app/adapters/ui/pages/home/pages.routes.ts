import { Routes } from '@angular/router';
import { AuthGuard } from '@guards/auth.guard';
import { UrlConstants } from '@utils/index';


export const routesPages: Routes = [
    {
      path: UrlConstants.URL_SETTING,
      loadComponent: () => import('./setting/setting.component').then(mod => mod.SettingComponent),
      canActivate: [AuthGuard],
      data: { roles: ['admin'] }
    },
    {
      path: UrlConstants.URL_VEHICLE,
      loadComponent: () => import('./vehicle/vehicle.component').then(mod => mod.VehicleComponent),
      canActivate: [AuthGuard],
      data: { roles: ['admin'] }
    },
    {
      path: UrlConstants.URL_MAINTENANCE,
      loadComponent: () => import('./maintenance/maintenance.component').then(mod => mod.MaintenanceComponent),
      canActivate: [AuthGuard],
      data: { roles: ['admin', 'customer'] }
    }
];
