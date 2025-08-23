import { Routes } from '@angular/router';
import { AuthGuard } from '@providers/index';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./vehicle.component').then(mod => mod.VehicleComponent),
    canActivate: [AuthGuard],
    data: { roles: ['admin'] }
  }
];
