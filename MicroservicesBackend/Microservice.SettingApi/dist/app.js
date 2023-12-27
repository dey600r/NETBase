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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const mongoose_1 = __importDefault(require("mongoose"));
const body_parser_1 = __importDefault(require("body-parser"));
const server_1 = __importDefault(require("./core/server"));
const settings_1 = __importDefault(require("./routes/settings"));
const crypto_1 = __importDefault(require("./routes/crypto"));
const config = __importStar(require("./assets/config.json"));
const encrypter_1 = __importDefault(require("./core/encrypter"));
const cfg = config;
const serverApp = new server_1.default(cfg.expressSettings.host, cfg.expressSettings.port);
// Body parser
serverApp.app.use(body_parser_1.default.urlencoded({ extended: true }));
serverApp.app.use(body_parser_1.default.json());
// ROUTES
serverApp.app.use('/api/settings', settings_1.default);
serverApp.app.use('/api/crpto', crypto_1.default);
// Connect to mongo DB
mongoose_1.default.connect(`mongodb://${cfg.mongoSettings.host}:${cfg.mongoSettings.port}/${cfg.mongoSettings.db}`, {
    user: cfg.mongoSettings.user,
    pass: encrypter_1.default.decrypt(cfg.mongoSettings.pwd)
}).then((ok) => {
    console.log('Connected to DB');
}).catch(err => {
    console.error('Error connecting to DB', err);
});
serverApp.start(() => {
    console.log(`Express server listening on port ${serverApp.port}`);
});
//# sourceMappingURL=app.js.map