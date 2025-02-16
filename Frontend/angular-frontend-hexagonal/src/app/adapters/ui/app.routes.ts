import { Routes } from '@angular/router';
import { UrlConstants } from '@utils/index';

export const routes: Routes = [
    {
        path: '',
        redirectTo: UrlConstants.URL_HOME,
        pathMatch: 'full'
    },
    {
        path: UrlConstants.URL_HOME,
        loadComponent: () => import('@pages/security/login/login.component').then(m => m.LoginComponent)
    },
    {
        path: '**',
        redirectTo: UrlConstants.URL_HOME
    }
];
