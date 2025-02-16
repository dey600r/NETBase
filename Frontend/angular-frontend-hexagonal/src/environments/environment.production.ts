export const environment = {
  production: true,
  apiUrl: 'http://localhost:3400',
  keycloak: {
    enable: false,
    url: 'http://localhost:8180',
    realm: 'microservices',
    clientId: 'frontend',
    onLoad: 'login-required',
  }    
};