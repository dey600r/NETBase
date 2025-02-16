export const environment = {
    production: false,
    apiUrl: 'https://localhost:44379/api',
    keycloak: {
        enable: false,
        url: 'http://localhost:8180',
        realm: 'microservices',
        clientId: 'frontend',
        onLoad: 'login-required',
    }            
};
