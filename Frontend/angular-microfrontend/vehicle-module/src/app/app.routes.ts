import { Routes } from '@angular/router';
import { AuthGuard } from '@providers/index';
import { SecurityLibUrlConstants } from 'security-lib';

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
    loadChildren: () => import('./pages/vehicle.routes').then(m => m.routes)  ,
    canActivate: [AuthGuard],
    data: { roles: ['admin'] }
  },
  {
    path: '**',
    redirectTo: SecurityLibUrlConstants.URL_HOME
  }
];
