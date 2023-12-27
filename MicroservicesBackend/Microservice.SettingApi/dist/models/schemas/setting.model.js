"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SettingContextDB = void 0;
const mongoose_1 = require("mongoose");
const settingSchema = new mongoose_1.Schema({
    key: {
        type: String,
        required: [true, 'The key is required']
    },
    value: {
        type: String,
        required: [true, 'The value is required']
    },
    updated: {
        type: Date,
        required: [true, 'The updated is required']
    }
});
exports.SettingContextDB = (0, mongoose_1.model)('Settings', settingSchema);
//# sourceMappingURL=setting.model.js.map