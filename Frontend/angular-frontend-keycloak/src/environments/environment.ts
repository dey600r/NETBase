export const environment = {
    production: false,
    apiUrl: 'https://localhost:44365/api',
    keycloak: {
        enable: true,
        url: 'http://localhost:8180',
        realm: 'test',
        clientId: 'frontend',
        onLoad: 'login-required',
    }            
};
