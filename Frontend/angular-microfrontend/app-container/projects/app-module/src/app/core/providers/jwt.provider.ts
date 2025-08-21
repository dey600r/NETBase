import { provideRouter } from '@angular/router';
import { provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';

import { routesApp, routesJWT } from '@app/app.routes';

// SERVICES
import { SecurityAbstractService, SecurityJWTService } from 'security-lib';

export const ProviderAuthJWT = [
  { provide: SecurityAbstractService, useClass: SecurityJWTService, multi: false },
  provideHttpClient(withFetch(), withInterceptorsFromDi()),
  provideRouter([...routesJWT, ...routesApp])
];