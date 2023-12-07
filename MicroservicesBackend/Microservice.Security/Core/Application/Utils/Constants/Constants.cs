namespace Microservice.Security.Core.Application.Utils
{
	public class Constants
	{
		// AUDIT DATA
		public const string USER_UNKNOWN_AUDIT = "UserUnknown";
		public static DateTime DATE_AUDIT = new DateTime(2023, 8, 1);

		// KEY
		public const string ENCRIPT_KEY = "05A71BE530D0CB3F";

		// ROLES
		public const string ADMIN_ROLE_NAME = "admin";
		public const string CUSTOMER_ROLE_NAME = "customer";
		public const string ADMIN_ROLE_COUNTRY = "Spain";

		// USER
		public const string ADMIN_USER_NAME = "admin";
		public const string ADMIN_USER_EMAIL = "admin@example.com";
		public const string ADMIN_USER_PWD = "xLTL5lzoqQxoeSCo9X1xWNL1YIRZSfQRxzvDYQfW2y0=";
	}
}
