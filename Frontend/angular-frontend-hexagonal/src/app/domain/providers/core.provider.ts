import { LoginUIPort, SecurityApiPort, StorageDatabasePort, UserUIPort } from '@ports/index';
import { StorageService } from '@database/index';
import { SecurityService } from '@api/index';
import { LoginDomain, UserDomain } from '@core/security/index';

export const ProviderCoreApp = [
  { provide: StorageDatabasePort, useClass: StorageService, multi: false },
  { provide: SecurityApiPort, useClass: SecurityService, multi: false },
  { provide: LoginUIPort, useClass: LoginDomain, multi: false },
  { provide: UserUIPort, useClass: UserDomain, multi: false }
];