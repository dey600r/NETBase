import { InjectionToken } from "@angular/core";

import Keycloak from 'keycloak-js';
import { AppConfig } from "@models/index";

export const APP_CONFIG = new InjectionToken<AppConfig>('APP_CONFIG');
export const KEYCLOAK_INSTANCE = new InjectionToken<Keycloak>('KEYCLOAK_INSTANCE');

export async function loadAppConfig(path: string) {
  console.log('Loading config from path:', path);

  const isBrowser = typeof window !== 'undefined';

  if (isBrowser) {
    // ✅ Browser
    const response = await fetch(`/${path}`);

    if (!response.ok) {
      throw new Error('Error loading config file (browser)');
    }

    return await response.json();
  } else {
    // ✅ Node (SSR)
    const { readFile } = await import('fs/promises');
    const { join } = await import('path');

    const filePath = join(process.cwd(), 'src/', path);
    const file = await readFile(filePath, 'utf-8');

    return JSON.parse(file);
  }
}