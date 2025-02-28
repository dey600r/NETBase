
// PORTS
import { LoginUIPort, SecurityApiPort, StorageDatabasePort, UserUIPort } from '@ports/index';

// DOMAINS
import { LoginJWTDomain, LoginKeycloakDomain, UserDomain } from '@domain/core/index';

// ADAPTERS
import { StorageService } from '@database/index';
import { SecurityService } from '@api/index';

import { environment } from '@environments/environment';

export const ProviderCoreApp = [
  { provide: StorageDatabasePort, useClass: StorageService, multi: false },
  { provide: SecurityApiPort, useClass: SecurityService, multi: false },
  { provide: LoginUIPort, useClass: (environment.keycloak.enable ? LoginKeycloakDomain: LoginJWTDomain), multi: false },
  { provide: UserUIPort, useClass: UserDomain, multi: false }
];