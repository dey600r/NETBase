import { provideRouter } from '@angular/router';
import { provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';

import { routesApp, routesJWT } from '@adapters/ui/app.routes';

// PORTS
import { LoginUIPort } from '@ports/index';

// DOMAINS
import { LoginJWTDomain } from '@domain/core/index';

export const ProviderAuthJWT = [
  { provide: LoginUIPort, useClass: LoginJWTDomain, multi: false },
  provideHttpClient(withFetch(), withInterceptorsFromDi()),
  provideRouter([...routesJWT, ...routesApp])
];