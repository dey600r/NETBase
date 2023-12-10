namespace Microservice.VehicleApi.Core.Constants
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

        public const string DATABASE_YES = "Y";
        public const string DATABASE_NO = "N";

        public const string VEHICLE_TYPE_CODE_MOTO = "M";
        public const string VEHICLE_TYPE_DESCRIPTION_MOTO = "MOTORBIKE";
		public const string VEHICLE_TYPE_CODE_CAR = "C";
		public const string VEHICLE_TYPE_DESCRIPTION_CAR = "CAR";
		public const string VEHICLE_TYPE_CODE_OTHER = "O";
		public const string VEHICLE_TYPE_DESCRIPTION_OTHER = "OTHER";

        public const string CONFIGURATION_NAME_PRODUCTION = "PRODUCTION";
        public const string CONFIGURATION_DESCRIPTION_PRODUCTION = "PRODUCTION_SETUP";

		// KEY
		public const string ENCRIPT_KEY = "05A71BE530D0CB3F";

		// AUDIT DATA
		public const string USER_UNKNOWN_AUDIT = "UserUnknown";
		public static DateTime DATE_AUDIT = new DateTime(2023, 8, 1);

		// CORS
		public const string CORS_RULE = "CorsRule";


	}
}
