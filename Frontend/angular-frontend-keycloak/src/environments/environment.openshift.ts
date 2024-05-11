export const environment = {
    production: true,
    apiUrl: 'https://microservice-gateway-api.apps-crc.testing',
    keycloak: {
      enable: false,
      url: 'http://localhost:8180',
      realm: 'microservices',
      clientId: 'frontend',
      onLoad: 'login-required',
    }    
  };