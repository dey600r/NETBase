export const environment = {
    production: false,
    apiUrl: 'http://localhost:3400',
    keycloak: {
        enable: true,
        url: 'http://localhost:8180',
        realm: 'microservices',
        clientId: 'backend',
        onLoad: 'login-required',
    }    
};
