import express = require('express');
import { SettingRepository } from '../core/setting-repository';
import { validateToken } from '../core/middlewares/authentication';
import { IConfigServer } from '../core/models/utils/config-setting.model';
import * as config from '../core/middlewares/config';
import * as keycloak from '../core/middlewares/authentication-keycloak';

const router = express.Router();
const db = new SettingRepository();
let cfg: IConfigServer = (config as any).config as IConfigServer;
let keycloakConnection: any = (keycloak as any).keycloak;

const listRoles: string [] = ['admin', 'manager'];

function protectBySection(token: any, request: any) {
    console.log('Validating Token Keycloak', token);
    request.user = token.content.name;
    return listRoles.every(x => (token.content.roles as string[]).some(y => x === y));
}

// ENDPOINT - GET ALL
router.get('/get-all', (cfg.keycloakEnabled ? keycloakConnection.protect(protectBySection) : validateToken), (req: express.Request, res: express.Response) => {
    db.GetAll().then((data: any) => {
        res.json({ ok: true, data });
    }).catch(err => {
        res.sendStatus(500);
        console.error(err);
    });
});

// ENDPOINT - GET BY KEY
router.get('/get', (cfg.keycloakEnabled ? keycloakConnection.protect(protectBySection) : validateToken), (req: express.Request, res: express.Response) => {
    db.GetByKey(req.query.key as string).then((data: any) => {
        if (!data) return res.json({ ok: false, data: 'Key not found' });
        res.json({ ok: true, data });
    }).catch(err => {
        res.sendStatus(500);
        console.error(err);
    });
});

// ENDPOINT - ADD
router.post('/add', (cfg.keycloakEnabled ? keycloakConnection.protect(protectBySection) : validateToken), (req: express.Request, res: express.Response) => {
    db.Add(req.body.key, req.body.value, (req as any).user).then(data => {
        res.json({ ok: true, data });
    }).catch(err => {
        res.sendStatus(500);
        console.error(err);
    });
});

export default router;