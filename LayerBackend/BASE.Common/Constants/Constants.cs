namespace BASE.Common.Constants
{
	public static class Constants
	{
		public const string OPERATION_TYPE_MAINTENANCE_HOME = "MH";
        public const string OPERATION_TYPE_MAINTENANCE_WORKSHOP = "MW";
        public const string OPERATION_TYPE_FAILURE_HOME = "FH";
        public const string OPERATION_TYPE_FAILURE_WORKSHOP = "FW";
        public const string OPERATION_TYPE_TOOLS = "T";
        public const string OPERATION_TYPE_OTHER = "O";
        public const string OPERATION_TYPE_ACCESSORIES = "A";
        public const string OPERATION_TYPE_CLOTHES = "C";
        public const string OPERATION_TYPE_SPARE_PARTS = "R";

        public const string MAINTENANCE_FREQ_ONCE_CODE = "O";
        public const string MAINTENANCE_FREQ_CALENDAR_CODE = "C";

        public const string OWNER_YO = "yo";
        public const string OWNER_ME = "me";
        public const string OWNER_OTHER = "other";
        public const string OWNER_OTRO = "otro";

        public const string STATE_INFO_OPERATION_EMPTY = "operation_empty";
        public const string STATE_INFO_VEHICLE_EMPTY = "vehicle_empty";
        public const string STATE_INFO_MAINTENANCE_EMPTY = "maintenance_empty";
        public const string STATE_INFO_MAINTENANCE_ELEMENT_EMPTY = "maintenance_element_empty";
        public const string STATE_INFO_NOTIFICATION_EMPTY = "notification_empty";
        public const string STATE_INFO_NOTIFICATION_WITHOUT = "notification_without";

        public const string DATABASE_YES = "Y";
        public const string DATABASE_NO = "N";

        public const string KEY_CONFIG_THEME = "configTheme";
        public const string KEY_CONFIG_DISTANCE = "configDistance";
        public const string KEY_CONFIG_MONEY = "configMoney";
        public const string KEY_LAST_UPDATE_DB = "lastUpdate";
        public const string KEY_CONFIG_PRIVACY = "configPrivacy";
        public const string KEY_CONFIG_SYNC_EMAIL = "configSyncEmail";

        public const string VEHICLE_TYPE_CODE_MOTO = "M";
        public const string VEHICLE_TYPE_DESCRIPTION_MOTO = "MOTORBIKE";
		public const string VEHICLE_TYPE_CODE_CAR = "C";
		public const string VEHICLE_TYPE_DESCRIPTION_CAR = "CAR";
		public const string VEHICLE_TYPE_CODE_OTHER = "O";
		public const string VEHICLE_TYPE_DESCRIPTION_OTHER = "OTHER";

        public const string CONFIGURATION_NAME_PRODUCTION = "PRODUCTION";
        public const string CONFIGURATION_DESCRIPTION_PRODUCTION = "PRODUCTION_SETUP";

        public const string USER_UNKNOWN_AUDIT = "UserUnknown";
        public static DateTime DATE_AUDIT = new DateTime(2023, 8, 1);
	}
}
