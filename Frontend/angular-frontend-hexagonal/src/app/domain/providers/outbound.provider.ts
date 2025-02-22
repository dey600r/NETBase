import { SecurityApiPort, StorageDatabasePort } from '@ports/index';
import { StorageService } from '@database/index';
import { SecurityService } from '@api/index';

export const ProviderOutboundApp = [
  { provide: StorageDatabasePort, useClass: StorageService, multi: false },
  { provide: SecurityApiPort, useClass: SecurityService, multi: false }
];