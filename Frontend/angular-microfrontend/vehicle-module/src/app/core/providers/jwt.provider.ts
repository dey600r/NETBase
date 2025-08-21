import { provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';

// SERVICES
import { SecurityAbstractService, SecurityJWTService } from 'security-lib';

export const ProviderAuthJWT = [
  { provide: SecurityAbstractService, useClass: SecurityJWTService, multi: false },
  provideHttpClient(withFetch(), withInterceptorsFromDi())
];