import { provideAppInitializer } from '@angular/core';
import { provideRouter, Routes } from '@angular/router';
import { loadRemoteModule } from '@angular-architects/module-federation';
import { provideHttpClient, withFetch, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';

import { 
    AutoRefreshTokenService, INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, includeBearerTokenInterceptor, 
    UserActivityService 
} from 'keycloak-angular';

import { AppConstants } from '../utils/index';
import { AppConfig } from '../models/index';
import { SecurityAbstractService, SecurityJWTService, SecurityKeycloakService } from '../services/index';

import { KEYCLOAK_INSTANCE } from './app-config.provider';
import { buildKeycloakInstance, buildUrlCondition, initializeKeycloak } from './keycloak.provider';
import { ProviderInterceptorApp } from './http.interceptor';
import { errorRoutes } from '../pages/error';

export function buildRoutesJWT(config: AppConfig): Routes {
  const securityModule = config.remotes.find(r => r.name === AppConstants.SECURITY_MODULE);
  return [
      {
          path: '',
          loadChildren: () =>
              // DYNAMIC WEB
              loadRemoteModule({
                  type: 'module',
                  remoteEntry: securityModule?.remoteEntry || '',
                  exposedModule: securityModule?.exposedModule || ''
              })
              .then(m => m.routes)
              .catch(err => {
                  console.warn('⚠️ No se pudo cargar SECURITY-MODULE:', err);
                  return errorRoutes;
                  //return import('security-lib').then(m => m.errorRoutes);
              }),
      //   loadChildren: () => import('security-module/routes').then(m => m.routes) --> STATIC WEB
      },
  ];
}

export function buildProviderAppConfig(config: AppConfig, routesApp: any[]) {
    if(config.keycloak.enable) {
        const keycloakInstance = buildKeycloakInstance(config);
        return [
            provideAppInitializer(initializeKeycloak(config, keycloakInstance)),
            provideRouter(routesApp),
            provideHttpClient(withFetch(), withInterceptorsFromDi(), withInterceptors([includeBearerTokenInterceptor])),
            AutoRefreshTokenService, UserActivityService,
            { provide: INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, useValue: [buildUrlCondition(config)] },
            { provide: SecurityAbstractService, useClass: SecurityKeycloakService, multi: false },
            { provide: KEYCLOAK_INSTANCE, useValue: keycloakInstance },
            ...ProviderInterceptorApp
        ];
    } else {
        return [
            { provide: SecurityAbstractService, useClass: SecurityJWTService, multi: false },
            provideHttpClient(withFetch(), withInterceptorsFromDi()),
            provideRouter([...routesApp, ...buildRoutesJWT(config)]),
            ...ProviderInterceptorApp
        ];
    }
}