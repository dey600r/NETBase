import { Routes } from '@angular/router';

import { AuthGuard, SecurityLibUrlConstants } from 'security-lib';

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
