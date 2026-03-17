import { mergeApplicationConfig, ApplicationConfig } from '@angular/core';
import { provideServerRendering } from '@angular/platform-server';
import { provideServerRoutesConfig } from '@angular/ssr';
import { buildConfiguration } from './app.config';
import { serverRoutes } from './app.routes.server';

export function buildServerConfiguration(config: any): ApplicationConfig {
  const serverConfig: ApplicationConfig = {
    providers: [
      provideServerRendering(),
      provideServerRoutesConfig(serverRoutes)
    ]
  };

  return mergeApplicationConfig(buildConfiguration(config), serverConfig);
}
