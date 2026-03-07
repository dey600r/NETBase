import { Routes } from '@angular/router';
import { AuthGuard } from 'security-lib';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./maintenance.component').then(mod => mod.MaintenanceComponent),
    canActivate: [AuthGuard],
    data: { roles: ['admin'] }
  }
];
