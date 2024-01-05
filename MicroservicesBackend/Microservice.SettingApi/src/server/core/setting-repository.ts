import { SettingContextDB } from './models/schemas/setting.model';

export class SettingRepository {

	GetAll() {
		return SettingContextDB.find();
	}

	GetByKey(key: string) {
		return SettingContextDB.findOne({ key: key });
	}

	Add(key: string, value: string, user: string) {
		return SettingContextDB.create({ key, value, user, updated: new Date() });
	}
}