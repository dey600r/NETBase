import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { environment } from '@app-environments/environment';
import { 
  APP_CONFIG, AppConfig, ENV_CONFIG, buildProviderAppConfig
} from 'security-lib';
import { buildRoutesApp } from './app.routes';

export function buildConfiguration(config: AppConfig): ApplicationConfig {
  return {
    providers: [
      { provide: ENV_CONFIG, useValue: environment },
      { provide: APP_CONFIG, useValue: config },
      provideZoneChangeDetection({ eventCoalescing: true }), 
      provideClientHydration(withEventReplay()), 
      provideAnimationsAsync(),
      ...buildProviderAppConfig(config, buildRoutesApp(config))
    ]
  };
}