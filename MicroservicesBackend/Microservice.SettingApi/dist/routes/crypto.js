"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express = require("express");
const encrypter_1 = __importDefault(require("../core/encrypter"));
const router = express.Router();
// ENDPOINT - ENCRYPT
router.get('/encrypt', (req, res) => {
    res.json({ ok: true, data: encrypter_1.default.encrypt(req.query.key) });
});
// ENDPOINT - DECRYPT
router.get('/decrypt', (req, res) => {
    res.json({ ok: true, data: encrypter_1.default.decrypt(req.query.key) });
});
exports.default = router;
//# sourceMappingURL=crypto.js.map