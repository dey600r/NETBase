import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: '',
        loadChildren: () => import('./pages/pages.module').then(mod => mod.PagesModule)
    },
    {
        path: 'login',
        loadChildren: () => import('./pages/security/login/login.module').then(mod => mod.LoginModule)
    },
    {
        path: '**',
        redirectTo: 'login'
      }
];
