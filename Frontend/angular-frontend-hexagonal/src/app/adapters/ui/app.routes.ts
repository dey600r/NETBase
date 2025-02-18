import { Routes } from '@angular/router';
import { UrlConstants } from '@utils/index';

export const routes: Routes = [
    {
        path: '',
        redirectTo: UrlConstants.URL_HOME,
        pathMatch: 'full'
    },
    {
        path: UrlConstants.URL_LOGIN,
        loadComponent: () => import('@pages/security/login/login.component').then(m => m.LoginComponent)
    },
    {
        path: UrlConstants.URL_SIGNUP,
        loadComponent: () => import('@pages/security/signup/signup.component').then(m => m.SignupComponent)
    },
    {
        path: UrlConstants.URL_HOME,
        loadComponent: () => import('@pages/home/home.component').then(m => m.HomeComponent)
    },
    {
        path: '**',
        redirectTo: UrlConstants.URL_HOME
    }
];
