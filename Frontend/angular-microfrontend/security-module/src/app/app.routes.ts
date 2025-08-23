import { Routes } from '@angular/router';

import { SecurityLibUrlConstants } from 'security-lib';

export const routes: Routes = [
    {
        path: SecurityLibUrlConstants.URL_LOGIN,
        loadComponent: () => import('@pages/login/login.component').then(m => m.LoginComponent)
    },
    {
        path: SecurityLibUrlConstants.URL_SIGNUP,
        loadComponent: () => import('@pages/signup/signup.component').then(m => m.SignupComponent)
    }
];
