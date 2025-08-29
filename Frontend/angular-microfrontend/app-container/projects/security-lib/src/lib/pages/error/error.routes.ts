import { Routes } from '@angular/router';

export const errorRoutes: Routes = [
    {
        path: '',
        loadComponent: () => import('./error.page').then(m => m.ErrorPageComponent)
    }
];