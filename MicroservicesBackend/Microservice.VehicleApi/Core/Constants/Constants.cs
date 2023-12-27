namespace Microservice.VehicleApi.Core.Constants
{
	public static class AppConstants
	{
		public const string OPERATION_TYPE_MAINTENANCE_HOME_CODE = "MH";
		public const string OPERATION_TYPE_MAINTENANCE_HOME_DESCRIPTION = "MAINTENANCE_HOME";
		public const string OPERATION_TYPE_MAINTENANCE_WORKSHOP_CODE = "MW";
		public const string OPERATION_TYPE_MAINTENANCE_WORKSHOP_DESCRIPTION = "MAINTENANCE_WORKSHOP";
		public const string OPERATION_TYPE_FAILURE_HOME_CODE = "FH";
		public const string OPERATION_TYPE_FAILURE_HOME_DESCRIPTION = "FAILURE_HOME";
		public const string OPERATION_TYPE_FAILURE_WORKSHOP_CODE = "FW";
		public const string OPERATION_TYPE_FAILURE_WORKSHOP_DESCRIPTION = "FAILURE_WORKSHOP";
		public const string OPERATION_TYPE_TOOLS_CODE = "T";
		public const string OPERATION_TYPE_TOOLS_DESCRIPTION = "TOOLS";
		public const string OPERATION_TYPE_OTHER_CODE = "O";
		public const string OPERATION_TYPE_OTHER_DESCRIPTION = "OTHERS";
		public const string OPERATION_TYPE_ACCESSORIES_CODE = "A";
		public const string OPERATION_TYPE_ACCESSORIES_DESCRIPTION = "ACCESORIES";
		public const string OPERATION_TYPE_CLOTHES_CODE = "C";
		public const string OPERATION_TYPE_CLOTHES_DESCRIPTION = "CLOTHES";
		public const string OPERATION_TYPE_SPARE_PARTS_CODE = "R";
		public const string OPERATION_TYPE_SPARE_PARTS_DESCRIPTION = "SPARE_PARTS";

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
