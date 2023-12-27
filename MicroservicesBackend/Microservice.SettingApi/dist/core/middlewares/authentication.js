"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.validateToken = void 0;
const token_1 = __importDefault(require("../token"));
const validateToken = (req, res, next) => {
    //let token: string = req.get('x-token') || '';
    //if (token === '') res.sendStatus(401);
    let token = '';
    const bearerHeader = req.headers['authorization'];
    if (typeof bearerHeader !== undefined)
        token = bearerHeader.split(' ')[1];
    token_1.default.verifyToken(token)
        .then((decoded) => {
        console.log('Decoded', decoded);
        req.user = decoded.UserName;
        next();
    })
        .catch(err => {
        res.sendStatus(401);
    });
};
exports.validateToken = validateToken;
//# sourceMappingURL=authentication.js.map