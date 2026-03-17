import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';

import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { AppConfig } from '@models/index';

import { buildProviderAppConfig } from '@providers/index';


export function buildConfiguration(config: AppConfig): ApplicationConfig {
  return {
    providers: [
      provideZoneChangeDetection({ eventCoalescing: true }), 
      provideClientHydration(withEventReplay()), 
      provideAnimationsAsync(),
      buildProviderAppConfig(config)
    ]
  };
}
