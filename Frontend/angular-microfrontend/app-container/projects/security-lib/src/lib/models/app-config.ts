export class AppConfigWithKeycloak {
    enable: boolean = false;
    url: string = '';
    realm: string = '';
    clientId: string = '';
    onLoad: string = 'login-required';
}

export class AppConfig {
    production: boolean = false;
    apiUrl: string = '';
    keycloak: AppConfigWithKeycloak = new AppConfigWithKeycloak();
}