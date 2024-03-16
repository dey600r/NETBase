const session = require('express-session');
const Keycloak = require('keycloak-connect');

import { IConfigServer } from '../../core/models/utils/config-setting.model';
import * as config from './config';

let cfg: IConfigServer = (config as any).config as IConfigServer;

const memoryStore = new session.MemoryStore();
const keycloak = new Keycloak({ store: memoryStore }, cfg.keycloackSettings);

module.exports = { keycloak: keycloak };