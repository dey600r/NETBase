export class UrlConstants {
    // SECURITY
    public static readonly URL_API_LOGIN: string = '/security/login';
    public static readonly URL_API_SIGNUP: string = '/security/signup';
    public static readonly URL_API_USER: string = '/security';

    // VEHICLE
    public static readonly URL_API_CONFIGURATION_GET_ALL: string = '/configuration';
    public static readonly URL_API_VEHICLE_TYPE_GET_ALL: string = '/vehicle/type';
    public static readonly URL_API_VEHICLE_MAINTENANCE_ELEMENT_GET_ALL: string = '/vehicle/maintenance-element';

    // MAINTENANCE
    public static readonly URL_API_MAINTENANCE_CONFIGURATION_GET_ALL: string = '/maintenance/configuration';
    public static readonly URL_API_MAINTENANCE_ELEMENT_GET_ALL: string = '/maintenance/maintenance-element';

    // SETTINGS
    public static readonly URL_API_SETTING_GET_ALL: string = '/settings/get-all';
    public static readonly URL_API_SETTING_ADD: string = '/settings/add';

    // PAGES
    public static readonly URL_LOGIN: string ='login';
    public static readonly URL_SIGNUP: string ='signup';
    public static readonly URL_HOME: string ='home';
    public static readonly URL_SETTING: string ='setting';
    public static readonly URL_VEHICLE: string ='vehicle';
    public static readonly URL_MAINTENANCE: string ='maintenance';
}