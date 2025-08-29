import { Routes } from '@angular/router';
import { AuthGuard } from '@providers/index';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./maintenance.component').then(mod => mod.MaintenanceComponent),
    canActivate: [AuthGuard],
    data: { roles: ['admin'] }
  }
];
