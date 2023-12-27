"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const express = require("express");
const setting_repository_1 = require("../core/setting-repository");
const authentication_1 = require("../core/middlewares/authentication");
const router = express.Router();
const db = new setting_repository_1.SettingRepository();
// ENDPOINT - GET ALL
router.get('/get-all', authentication_1.validateToken, (req, res) => {
    db.GetAll().then((data) => {
        res.json({ ok: true, data });
    }).catch(err => {
        res.sendStatus(500);
        console.error(err);
    });
});
// ENDPOINT - GET BY KEY
router.get('/get', authentication_1.validateToken, (req, res) => {
    db.GetByKey(req.query.key).then((data) => {
        if (!data)
            return res.json({ ok: false, data: 'Key not found' });
        res.json({ ok: true, data });
    }).catch(err => {
        res.sendStatus(500);
        console.error(err);
    });
});
// ENDPOINT - ADD
router.post('/add', authentication_1.validateToken, (req, res) => {
    db.Add(req.body.key, req.body.value, req.user).then(data => {
        res.json({ ok: true, data });
    }).catch(err => {
        res.sendStatus(500);
        console.error(err);
    });
});
exports.default = router;
//# sourceMappingURL=settings.js.map