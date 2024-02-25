import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UrlConstants } from '@utils/index';
import { AuthGuard } from '@core/guards/jwt.guard';
import { environment } from '@environments/environment';
import { AuthKeycloakGuard } from '@core/guards/keycloak.guard';

export const routesKeycloack: Routes = [
  {
        path: '',
        redirectTo: UrlConstants.URL_HOME,
        pathMatch: 'full'
  },
  {
        path: UrlConstants.URL_HOME,
        loadChildren: () => import('./pages/home/pages.module').then(mod => mod.PagesModule),
        canActivate: [AuthKeycloakGuard],
        data: { roles: ["realm-admin"] }
  },
  {
        path: '**',
        redirectTo: UrlConstants.URL_HOME
    }
];

export const routesJWT: Routes = [
      {
            path: '',
            redirectTo: UrlConstants.URL_HOME,
            pathMatch: 'full'
      },
      {
            path: UrlConstants.URL_HOME,
            loadChildren: () => import('./pages/home/pages.module').then(mod => mod.PagesModule),
            canActivate: [AuthGuard],
            data: { roles: ["realm-admin"] }
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
            redirectTo: UrlConstants.URL_HOME
        }
    ];
@NgModule({
  imports: [RouterModule.forRoot((environment.keycloak.enable ? routesKeycloack : routesJWT), {})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
