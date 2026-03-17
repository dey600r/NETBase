import { AppConfig } from '@models/index';

import { ProviderCoreApp } from './core.provider';
import { buildProviderAuthKeycloak } from './keycloak.provider';
import { ProviderInterceptorApp } from './http.interceptor';
import { ProviderAuthJWT } from './jwt.provider';
import { APP_CONFIG } from './app-config.provider';

export function buildProviderAppConfig(config: AppConfig) {
    let providers = [];
    if(config.keycloak.enable) {
        providers = buildProviderAuthKeycloak(config);
    } else {
        providers = ProviderAuthJWT
    }
    return [...providers, 
        { provide: APP_CONFIG, useValue: config },
        ProviderInterceptorApp, 
        ProviderCoreApp
    ];
}
