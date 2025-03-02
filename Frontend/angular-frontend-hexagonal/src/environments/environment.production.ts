export const environment = {
  production: true,
  apiUrl: 'http://localhost:3400',
  keycloak: {
    enable: true,
    url: 'http://localhost:8180',
    realm: 'microservices',
    clientId: 'frontend',
    onLoad: 'login-required',
  }    
};