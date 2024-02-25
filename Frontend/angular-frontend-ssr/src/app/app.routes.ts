import { Routes } from '@angular/router';
import { UrlConstants } from '@utils/index';
import { AuthGuard } from '@app/core/guards/user.guard';

export const routes: Routes = [
    {
        path: '',
        redirectTo: UrlConstants.URL_LOGIN,
        pathMatch: 'full'
    },
    {
        path: UrlConstants.URL_HOME,
        loadChildren: () => import('./pages/home/pages.module').then(mod => mod.PagesModule),
        canActivate: [AuthGuard]
    },
    {
        path: UrlConstants.URL_LOGIN,
        loadChildren: () => import('./pages/security/login/login.module').then(mod => mod.LoginModule)
    },
    {
        path: UrlConstants.URL_SIGNUP,
        loadChildren: () => import('./pages/security/signup/signup.module').then(mod => mod.SignupModule)
    },
    {
        path: '**',
        redirectTo: UrlConstants.URL_LOGIN
      }
];

