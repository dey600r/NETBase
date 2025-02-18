import { Routes } from '@angular/router';
import { HomeComponent } from './home.component';
// import { AuthGuard } from '@core/guards/jwt.guard';
import { UrlConstants } from '@utils/index';
// import { AuthKeycloakGuard } from '@core/guards/keycloak.guard';


export const routesKeycloack: Routes = [
  { 
    path: '', 
    component: HomeComponent,
    children: [
    //   {
    //     path: UrlConstants.URL_SETTING,
    //     loadChildren: () => import('./setting/setting.module').then(mod => mod.SettingModule),
    //     canActivate: [AuthKeycloakGuard],
    //     data: { roles: ['admin'] }
    //   },
    //   {
    //     path: UrlConstants.URL_VEHICLE,
    //     loadChildren: () => import('./vehicle/vehicle.module').then(mod => mod.VehicleModule),
    //     canActivate: [AuthKeycloakGuard],
    //     data: { roles: ['admin'] }
    //   },
    //   {
    //     path: UrlConstants.URL_MAINTENANCE,
    //     loadChildren: () => import('./maintenance/maintenance.module').then(mod => mod.MaintenanceModule),
    //     canActivate: [AuthKeycloakGuard],
    //     data: { roles: ['admin'] }
    //   }
    ]
  }  
];

export const routesJWT: Routes = [
  { 
    path: '', 
    component: HomeComponent,
    children: [
    //   {
    //     path: UrlConstants.URL_SETTING,
    //     loadChildren: () => import('./setting/setting.module').then(mod => mod.SettingModule),
    //     canActivate: [AuthGuard],
    //     data: { roles: ['admin'] }
    //   },
    //   {
    //     path: UrlConstants.URL_VEHICLE,
    //     loadChildren: () => import('./vehicle/vehicle.module').then(mod => mod.VehicleModule),
    //     canActivate: [AuthGuard],
    //     data: { roles: ['admin'] }
    //   },
    //   {
    //     path: UrlConstants.URL_MAINTENANCE,
    //     loadChildren: () => import('./maintenance/maintenance.module').then(mod => mod.MaintenanceModule),
    //     canActivate: [AuthGuard],
    //     data: { roles: ['admin'] }
    //   }
    ]
  }  
];
