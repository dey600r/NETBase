namespace Microservice.MaintenanceApi.Core.Constants
{
	public static class Constants
	{

        public const string MAINTENANCE_FREQ_ONCE_CODE = "O";
        public const string MAINTENANCE_FREQ_CALENDAR_CODE = "C";
		public const string MAINTENANCE_FREQ_ONCE_DESC = "ONCE";
		public const string MAINTENANCE_FREQ_CALENDAR_DESC = "CALENDAR";

		public const string DATABASE_YES = "Y";
        public const string DATABASE_NO = "N";

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
