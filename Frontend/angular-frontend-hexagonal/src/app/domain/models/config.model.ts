export class AppConfigWithKeycloak {
    enable: boolean = false;
    url: string = '';
    realm: string = '';
    clientId: string = '';
    onLoad: string = 'login-required';
}

export class AppConfig {
    apiUrl: string = '';
    keycloak: AppConfigWithKeycloak = new AppConfigWithKeycloak();
}