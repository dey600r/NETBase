
// PORTS
import { LoginUIPort, SecurityApiPort, StorageDatabasePort, UserUIPort } from '@ports/index';

// DOMAINS
import { LoginDomain, UserDomain } from '@domain/core/index';

// ADAPTERS
import { StorageService } from '@database/index';
import { SecurityService } from '@api/index';

export const ProviderCoreApp = [
  { provide: StorageDatabasePort, useClass: StorageService, multi: false },
  { provide: SecurityApiPort, useClass: SecurityService, multi: false },
  { provide: LoginUIPort, useClass: LoginDomain, multi: false },
  { provide: UserUIPort, useClass: UserDomain, multi: false }
];