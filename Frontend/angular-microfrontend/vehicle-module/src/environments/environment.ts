export const environment = {
    production: false,
    apiUrl: 'https://localhost:44360',
    keycloak: {
        enable: true,
        url: 'http://localhost:8180',
        realm: 'microservices',
        clientId: 'frontend',
        onLoad: 'login-required',
    },
    remotes: [
        {
            name: 'security-module',
            remoteEntry: 'http://localhost:4202/remoteEntry.js',
            exposedModule: './routes'
        },
        {
            name: 'vehicle-module',
            remoteEntry: 'http://localhost:4201/remoteEntry.js',
            exposedModule: './routes'
        }
    ]        
};
