import { Routes } from '@angular/router';
import { UrlConstants } from './core/utils';

export const routes: Routes = [
    {
      path: '',
      loadComponent: () => import('./pages/vehicle.component').then(mod => mod.VehicleComponent),
    //   canActivate: [AuthGuard],
    //   data: { roles: ['admin'] }
    }
];
