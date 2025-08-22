import express = require('express');
import Cypher from '../core/encrypter';

const router = express.Router();

// ENDPOINT - ENCRYPT
router.get('/encrypt', (req: express.Request, res: express.Response) => {
    res.json({ ok: true, data: Cypher.encrypt(req.query.key as string) });
});

// ENDPOINT - DECRYPT
router.get('/decrypt', (req: express.Request, res: express.Response) => {
    res.json({ ok: true, data: Cypher.decrypt(req.query.key as string) });
});

export default router;