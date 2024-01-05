import express = require('express');
import { SettingRepository } from '../core/setting-repository';
import { validateToken } from '../core/middlewares/authentication';

const router = express.Router();
const db = new SettingRepository();

// ENDPOINT - GET ALL
router.get('/get-all', validateToken, (req: express.Request, res: express.Response) => {
    db.GetAll().then((data: any) => {
        res.json({ ok: true, data });
    }).catch(err => {
        res.sendStatus(500);
        console.error(err);
    });
});

// ENDPOINT - GET BY KEY
router.get('/get', validateToken, (req: express.Request, res: express.Response) => {
    db.GetByKey(req.query.key as string).then((data: any) => {
        if (!data) return res.json({ ok: false, data: 'Key not found' });
        res.json({ ok: true, data });
    }).catch(err => {
        res.sendStatus(500);
        console.error(err);
    });
});

// ENDPOINT - ADD
router.post('/add', validateToken, (req: express.Request, res: express.Response) => {
    db.Add(req.body.key, req.body.value, (req as any).user).then(data => {
        res.json({ ok: true, data });
    }).catch(err => {
        res.sendStatus(500);
        console.error(err);
    });
});

export default router;