"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SettingRepository = void 0;
const setting_model_1 = require("./models/schemas/setting.model");
class SettingRepository {
    GetAll() {
        return setting_model_1.SettingContextDB.find();
    }
    GetByKey(key) {
        return setting_model_1.SettingContextDB.findOne({ key: key });
    }
    Add(key, value, user) {
        return setting_model_1.SettingContextDB.create({ key, value, user, updated: new Date() });
    }
}
exports.SettingRepository = SettingRepository;
//# sourceMappingURL=setting-repository.js.map