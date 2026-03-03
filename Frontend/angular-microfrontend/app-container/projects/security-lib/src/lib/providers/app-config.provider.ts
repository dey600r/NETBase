import { APP_INITIALIZER, InjectionToken, Provider } from "@angular/core";

import Keycloak from 'keycloak-js';
import { AppConfig, EnvConfig } from "../models/index";

export const ENV_CONFIG = new InjectionToken<EnvConfig>('ENV_CONFIG');
export const APP_CONFIG = new InjectionToken<AppConfig>('APP_CONFIG');
export const KEYCLOAK_INSTANCE = new InjectionToken<Keycloak>('KEYCLOAK_INSTANCE');

export async function loadAppConfig(path: string): Promise<AppConfig> {
  const response = await fetch(path);
  if (!response.ok) {
    throw new Error('Error loading config file');
  }
  return response.json();
}

export async function provideAppConfig(path: string): Promise<Provider> {
    const config: AppConfig = await loadAppConfig(path);
    return [ { provide: APP_CONFIG, useValue: config } ];
}