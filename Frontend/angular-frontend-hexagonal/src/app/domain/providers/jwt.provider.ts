// PORTS
import { LoginUIPort } from '@ports/index';

// DOMAINS
import { LoginJWTDomain } from '@domain/core/index';

export const ProviderAuthJWT = [
  { provide: LoginUIPort, useClass: LoginJWTDomain, multi: false },
];