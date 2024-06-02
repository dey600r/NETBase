export const environment = {
    production: true,
    apiUrl: 'https://microservice-gateway-api.apps-crc.testing',
    keycloak: {
      enable: true,
      url: 'https://keycloak-microservices.apps-crc.testing',
      realm: 'microservices',
      clientId: 'frontend',
      onLoad: 'login-required',
    }    
  };