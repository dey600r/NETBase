import { InjectionToken } from "@angular/core";

import Keycloak from 'keycloak-js';
import { AppConfig } from "../models/index";

export const APP_CONFIG = new InjectionToken<AppConfig>('APP_CONFIG');
export const KEYCLOAK_INSTANCE = new InjectionToken<Keycloak>('KEYCLOAK_INSTANCE');