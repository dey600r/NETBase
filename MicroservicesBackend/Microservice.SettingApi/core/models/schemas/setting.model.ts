import { Document, Schema, model } from "mongoose";

const settingSchema = new Schema({
	key: {
		type: String,
		required: [true, 'The key is required']
	},
	value: {
		type: String,
		required: [true, 'The value is required']
	},
	user: {
		type: String,
		required: [true, 'The user is required']
	},
	updated: {
		type: Date,
		required: [true, 'The updated is required']
	}
});

interface ISetting extends Document {
	key: string;
	value: string;
	user: string;
	updated: Date;
}

export const SettingContextDB = model<ISetting>('Settings', settingSchema);