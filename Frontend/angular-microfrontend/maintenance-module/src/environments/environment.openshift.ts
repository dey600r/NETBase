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
        }
    ]        
};
