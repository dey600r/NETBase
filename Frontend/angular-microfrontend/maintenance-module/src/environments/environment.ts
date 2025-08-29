export const environment = {
    production: false,
    apiUrl: 'https://localhost:44320/api',
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
        }
    ]        
};
