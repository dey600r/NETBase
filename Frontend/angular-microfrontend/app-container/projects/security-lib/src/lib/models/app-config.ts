export class AppConfigWithKeycloak {
    enable: boolean = false;
    url: string = '';
    realm: string = '';
    clientId: string = '';
    onLoad: string = 'login-required';
}

export class AppConfigWithRemotes {
    name: string = '';
    remoteEntry: string = '';
    exposedModule: string = '';
}

export class EnvConfig {
    production: boolean = false;
    configPath: string = '';
}

export class AppConfig {
    apiUrl: string = '';
    keycloak: AppConfigWithKeycloak = new AppConfigWithKeycloak();
    remotes: AppConfigWithRemotes[] = [];
}