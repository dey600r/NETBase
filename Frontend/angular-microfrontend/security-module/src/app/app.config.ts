import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { environment } from '@environments/environment';
import { APP_CONFIG, AppConfig, ENV_CONFIG, ProviderInterceptorApp, SecurityAbstractService, SecurityJWTService } from 'security-lib';
import { provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';

export function buildConfiguration(config: AppConfig): ApplicationConfig {
  return {
    providers: [
      { provide: ENV_CONFIG, useValue: environment },
      { provide: APP_CONFIG, useValue: config },
      { provide: SecurityAbstractService, useClass: SecurityJWTService, multi: false },
      provideHttpClient(withFetch(), withInterceptorsFromDi()),
      provideClientHydration(withEventReplay()), 
      provideZoneChangeDetection({ eventCoalescing: true }), 
      provideRouter(routes),
      ProviderInterceptorApp
    ]
  };
}
