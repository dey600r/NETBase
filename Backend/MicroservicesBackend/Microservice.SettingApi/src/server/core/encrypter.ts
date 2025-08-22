import * as forge from 'node-forge';
import * as crypto from 'crypto';

export default class Cypher {

    private static keyPair = forge.pki.rsa.generateKeyPair({ bits: 2048 });
    private static algorithm = 'aes-256-cbc';
    private static key = Buffer.from('aes-256-jkr-dsa-hga-d22-ds2-eds-edg-jug-wsc', 'base64url');
    private static iv = Buffer.from('aes-256-cbc-dsa-das-re', 'base64url');
    //private static key = crypto.randomBytes(32);
    //private static iv = crypto.randomBytes(16);

    constructor() { }

    static encryptWithPublicKey(text: string): string {
        const publicKey = this.keyPair.publicKey;
        const encrypted = publicKey.encrypt(text);
        return forge.util.encode64(encrypted);
    }

    static decryptWithPrivateKey(encryptedText: string): string {
        const privateKey = this.keyPair.privateKey;
        const encrypted = forge.util.decode64(encryptedText);
        const decrypted = privateKey.decrypt(encrypted);
        return decrypted;
    }

    static encrypt(text: string): string {
        const cipher = crypto.createCipheriv(this.algorithm, this.key, this.iv);
        let encrypted = cipher.update(text, 'utf-8', 'hex');
        encrypted += cipher.final('hex');
        return encrypted;
    }

    static decrypt(encryptedText: string): string {
        const decipher = crypto.createDecipheriv(this.algorithm, this.key, this.iv);
        let decrypted = decipher.update(encryptedText, 'hex', 'utf-8');
        decrypted += decipher.final('utf-8');
        return decrypted;
    }
}