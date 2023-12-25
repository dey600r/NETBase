namespace Microservice.MaintenanceApi.Core.Constants
{
	public static class AppConstants
	{

        public const string MAINTENANCE_FREQ_ONCE_CODE = "O";
        public const string MAINTENANCE_FREQ_CALENDAR_CODE = "C";
		public const string MAINTENANCE_FREQ_ONCE_DESC = "ONCE";
		public const string MAINTENANCE_FREQ_CALENDAR_DESC = "CALENDAR";

		public const string DATABASE_YES = "Y";
        public const string DATABASE_NO = "N";

        public const string CONFIGURATION_NAME_PRODUCTION = "PRODUCTION";
        public const string CONFIGURATION_DESCRIPTION_PRODUCTION = "PRODUCTION_SETUP";

		public const string MAINTENANCE_FIRST_REVIEW_DESCRIPTION = "FIRST_REVIEW";
		public const string MAINTENANCE_CHANGE_WHEEL_DESCRIPTION = "CHANGE_WHEEL";

		public const string MAINTENANCE_ELEMENT_FRONT_WHEEL_NAME = "FRONT_WHEEL";
		public const string MAINTENANCE_ELEMENT_FRONT_WHEEL_DESCRIPTION = "CHANGE_FRONT_WHEEL";
		public const string MAINTENANCE_ELEMENT_BACK_WHEEL_NAME = "BACK_WHEEL";
		public const string MAINTENANCE_ELEMENT_BACK_WHEEL_DESCRIPTION = "CHANGE_BACK_WHEEL";
		public const string MAINTENANCE_ELEMENT_ENGINE_OIL_NAME = "ENGINE_OIL";
		public const string MAINTENANCE_ELEMENT_ENGINE_OIL_DESCRIPTION = "CHANGE_ENGINE_OIL";

		// KEY
		public const string ENCRIPT_KEY = "05A71BE530D0CB3F";

		// AUDIT DATA
		public const string USER_UNKNOWN_AUDIT = "UserUnknown";
		public static DateTime DATE_AUDIT = new DateTime(2023, 8, 1);

		// CORS
		public const string CORS_RULE = "CorsRule";


	}
}
