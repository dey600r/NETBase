export const environment = {
    production: true,
    apiUrl: 'http://localhost:3400',
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
            remoteEntry: 'http://localhost:2002/remoteEntry.js',
            exposedModule: './routes'
        },
        {
            name: 'vehicle-module',
            remoteEntry: 'http://localhost:2001/remoteEntry.js',
            exposedModule: './routes'
        },
        {
            name: 'maintenance-module',
            remoteEntry: 'http://localhost:2003/remoteEntry.js',
            exposedModule: './routes'
        },
        {
            name: 'setting_module',
            remoteEntry: 'http://localhost:2004/remoteEntry.js',
            exposedModule: './component'
        },
        {
            name: 'home_module',
            remoteEntry: 'http://localhost:2005/remoteEntry.js',
            exposedModule: './component'
        }
    ]
};
