"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (k !== "default" && Object.prototype.hasOwnProperty.call(mod, k)) __createBinding(result, mod, k);
    __setModuleDefault(result, mod);
    return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
const forge = __importStar(require("node-forge"));
const crypto = __importStar(require("crypto"));
class Cypher {
    //private static key = crypto.randomBytes(32);
    //private static iv = crypto.randomBytes(16);
    constructor() { }
    static encryptWithPublicKey(text) {
        const publicKey = this.keyPair.publicKey;
        const encrypted = publicKey.encrypt(text);
        return forge.util.encode64(encrypted);
    }
    static decryptWithPrivateKey(encryptedText) {
        const privateKey = this.keyPair.privateKey;
        const encrypted = forge.util.decode64(encryptedText);
        const decrypted = privateKey.decrypt(encrypted);
        return decrypted;
    }
    static encrypt(text) {
        const cipher = crypto.createCipheriv(this.algorithm, this.key, this.iv);
        let encrypted = cipher.update(text, 'utf-8', 'hex');
        encrypted += cipher.final('hex');
        return encrypted;
    }
    static decrypt(encryptedText) {
        const decipher = crypto.createDecipheriv(this.algorithm, this.key, this.iv);
        let decrypted = decipher.update(encryptedText, 'hex', 'utf-8');
        decrypted += decipher.final('utf-8');
        return decrypted;
    }
}
exports.default = Cypher;
Cypher.keyPair = forge.pki.rsa.generateKeyPair({ bits: 2048 });
Cypher.algorithm = 'aes-256-cbc';
Cypher.key = Buffer.from('aes-256-jkr-dsa-hga-d22-ds2-eds-edg-jug-wsc', 'base64url');
Cypher.iv = Buffer.from('aes-256-cbc-dsa-das-re', 'base64url');
//# sourceMappingURL=encrypter.js.map