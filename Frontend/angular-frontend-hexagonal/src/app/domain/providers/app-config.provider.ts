import { InjectionToken } from "@angular/core";

import Keycloak from 'keycloak-js';
import { AppConfig } from "@models/index";

export const APP_CONFIG = new InjectionToken<AppConfig>('APP_CONFIG');
export const KEYCLOAK_INSTANCE = new InjectionToken<Keycloak>('KEYCLOAK_INSTANCE');

export async function loadAppConfig(path: string) {
  console.log('Loading config from path:', path);
  // ✅ Browser
  const response = await fetch(`/${path}`);

  if (!response.ok) {
    throw new Error('Error loading config file (browser)');
  }

  return await response.json();
}