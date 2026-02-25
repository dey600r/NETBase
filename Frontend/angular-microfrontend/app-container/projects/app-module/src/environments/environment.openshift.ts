export const environment = {
    production: true,
    apiUrl: 'https://microservice-gateway.apps-crc.testing',
    keycloak: {
        enable: true,
        url: 'https://keycloak-microservices.apps-crc.testing',
        realm: 'microservices',
        clientId: 'frontend',
        onLoad: 'login-required',
    },
    remotes: [
        {
            name: 'security-module',
            remoteEntry: 'https://microfrontend-angular-security.apps-crc.testing/remoteEntry.js',
            exposedModule: './routes'
        },
        {
            name: 'vehicle-module',
            remoteEntry: 'https://microfrontend-angular-vehicle.apps-crc.testing/remoteEntry.js',
            exposedModule: './routes'
        },
        {
            name: 'maintenance-module',
            remoteEntry: 'https://microfrontend-angular-maintenance.apps-crc.testing/remoteEntry.js',
            exposedModule: './routes'
        },
        {
            name: 'setting_module',
            remoteEntry: 'https://microfrontend-react-setting.apps-crc.testing/remoteEntry.js',
            exposedModule: './component'
        },
        {
            name: 'home_module',
            remoteEntry: 'https://microfrontend-vue-home.apps-crc.testing/remoteEntry.js',
            exposedModule: './component'
        }
    ]
};
