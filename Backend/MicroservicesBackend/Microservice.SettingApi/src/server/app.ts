import * as config from './core/middlewares/config';
import mongoose from 'mongoose';
import bodyParser from 'body-parser';

import settings from './routes/settings';
import crypto from './routes/crypto';
import Server from './core/server';

import { IConfigServer } from './core/models/utils/config-setting.model';
import Cypher from './core/encrypter';

let cfg: IConfigServer = (config as any).config as IConfigServer;

const serverApp = new Server(cfg.expressSettings.host, cfg.expressSettings.port);
// KEYCLOAK
if (cfg.keycloakEnabled) {
    const keycloak = require('./core/middlewares/authentication-keycloak').keycloak;
    serverApp.app.use(keycloak.middleware());

    console.log('Keycloak initialized', cfg.keycloackSettings);
}

// Body parser
serverApp.app.use(bodyParser.urlencoded({ extended: true }));
serverApp.app.use(bodyParser.json());




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

