﻿namespace Microservice.IoC.Utils
{
    public static class SecurityConstants
    {
        // CORS
        public const string CORS_RULE = "CorsRule";

        // ROLES
        public const string ADMIN_ROLE_NAME = "admin";
        public const string MANAGER_ROLE_NAME = "manager";
        public const string CUSTOMER_ROLE_NAME = "customer";

        // SECURITY POLICIES
        public const string SUPER_ADMIN_POLICY = "AdministratorPolicy";
        public const string READ_WRITE_POLICY = "Reader&WriterPolicy";
        public const string READ_POLICY = "ReaderPolicy";

        // KEY
        public const string ENCRIPT_KEY = "05A71BE530D0CB3F";

        // AUDIT DATA
        public const string USER_UNKNOWN_AUDIT = "UserUnknown";
        public static DateTime DATE_AUDIT = new DateTime(2023, 8, 1);
    }
}
