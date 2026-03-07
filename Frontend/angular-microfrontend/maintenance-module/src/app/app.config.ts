import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';

import { 
  APP_CONFIG, AppConfig, buildProviderAppConfig, ENV_CONFIG
} from 'security-lib';

import { environment } from '@environments/environment';
import { routesApp } from './app.routes';

export function buildConfiguration(config: AppConfig): ApplicationConfig {
  return {
    providers: [
      { provide: ENV_CONFIG, useValue: environment },
      { provide: APP_CONFIG, useValue: config },
      provideClientHydration(withEventReplay()), 
      provideZoneChangeDetection({ eventCoalescing: true }),
      ...buildProviderAppConfig(config, routesApp)
    ]
  };
}
