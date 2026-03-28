import { Routes } from '@angular/router';
import { AuthGuard } from '@microfrontend/security-lib';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./vehicle.component').then(mod => mod.VehicleComponent),
    canActivate: [AuthGuard],
    data: { roles: ['admin'] }
  }
];
