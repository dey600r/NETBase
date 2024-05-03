export const environment = {
    production: true,
    apiUrl: 'https://dey-backend-microservices.apps-crc.testing:3400',
    keycloak: {
      enable: false,
      url: 'http://localhost:8180',
      realm: 'microservices',
      clientId: 'frontend',
      onLoad: 'login-required',
    }    
  };