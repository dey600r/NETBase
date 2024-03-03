import mongoose from 'mongoose';
import bodyParser from 'body-parser';

import Server from './core/server';

import * as config from '../assets/config.json';
import * as configProd from '../assets/config.production.json';
import { IConfigServer } from './core/models/utils/config-setting.model';
import Cypher from './core/encrypter';


let cfg: IConfigServer = config as IConfigServer;
if (process.env.NODE_ENV === 'production') {
    cfg = configProd as IConfigServer;
}

const serverApp = new Server(cfg.expressSettings.host, cfg.expressSettings.port);
// KEYCLOAK
if (cfg.keycloakEnabled) {
    const session = require('express-session');
    const Keycloak = require('keycloak-connect');

    const memoryStore = new session.MemoryStore();
    const keycloak = new Keycloak({ store: memoryStore }, cfg.keycloackSettings);
    serverApp.app.use(keycloak.middleware());

    module.exports = { keycloak: keycloak };
    console.log('Keycloak initialized');
}

// Body parser
serverApp.app.use(bodyParser.urlencoded({ extended: true }));
serverApp.app.use(bodyParser.json());


import settings from './routes/settings';
import crypto from './routes/crypto';

// ROUTES
serverApp.app.use('/api/settings', settings);
serverApp.app.use('/api/crpto', crypto);

// Connect to mongo DB
mongoose.connect(`mongodb://${cfg.mongoSettings.host}:${cfg.mongoSettings.port}/${cfg.mongoSettings.db}`, {
    user: cfg.mongoSettings.user,
    pass: Cypher.decrypt(cfg.mongoSettings.pwd)
}).then((ok: any) => {
    console.log('Connected to DB');
}).catch(err => {
    console.error('Error connecting to DB', err)
});

serverApp.start(() => {
    console.log(`Express server listening on port ${serverApp.port}`);
});

