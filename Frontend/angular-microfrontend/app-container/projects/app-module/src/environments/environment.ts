export const environment = {
    production: false,
    apiUrl: 'https://localhost:44360',
    // apiUrl: 'http://localhost:3400',
    keycloak: {
        enable: true,
        url: 'https://keycloak-webapp-dpe9afcje2f9e7ad.westeurope-01.azurewebsites.net',
        //url: 'http://localhost:8180',
        realm: 'estimator-web-local',
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
        },
        {
            name: 'maintenance-module',
            remoteEntry: 'http://localhost:4203/remoteEntry.js',
            exposedModule: './routes'
        },
        {
            name: 'setting_module',
            remoteEntry: 'http://localhost:4204/remoteEntry.js',
            exposedModule: './component'
        },
        {
            name: 'home_module',
            remoteEntry: 'http://localhost:4205/remoteEntry.js',
            exposedModule: './component'
        }
    ]
};
