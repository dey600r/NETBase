#MICROFRONTENDS
helm upgrade microfrontend-angular-container .\microservices\ -f .\microservices\values-microfrontend-angular-container.yaml --debug -n microservices
helm upgrade microfrontend-angular-vehicle .\microservices\ -f .\microservices\values-microfrontend-angular-vehicle.yaml --debug -n microservices
helm upgrade microfrontend-angular-maintenance .\microservices\ -f .\microservices\values-microfrontend-angular-maintenance.yaml --debug -n microservices
helm upgrade microfrontend-vue-home .\microservices\ -f .\microservices\values-microfrontend-vue-home.yaml --debug -n microservices
helm upgrade microfrontend-react-setting .\microservices\ -f .\microservices\values-microfrontend-react-setting.yaml --debug -n microservices

#MICROSERVICES
helm upgrade microservice-gateway .\microservices\ -f .\microservices\values-microservice-gateway.yaml --debug -n microservices
helm upgrade microservice-maintenance .\microservices\ -f .\microservices\values-microservice-maintenance.yaml --debug -n microservices
helm upgrade microservice-vehicle .\microservices\ -f .\microservices\values-microservice-vehicle.yaml --debug -n microservices
helm upgrade microservice-setting .\microservices\ -f .\microservices\values-microservice-setting.yaml --debug -n microservices
helm upgrade microservice-security .\microservices\ -f .\microservices\values-microservice-security.yaml --debug -n microservices

#TOOLS
helm upgrade keycloak .\tools\ -f .\tools\values-tool-keycloak.yaml --debug -n microservices
helm upgrade sql-server .\tools\ -f .\tools\values-tool-sqlserver.yaml --debug -n microservices
helm upgrade mongodb .\tools\ -f .\tools\values-tool-mongodb.yaml --debug -n microservices
helm upgrade rabbitmq .\tools\ -f .\tools\values-tool-rabbitmq.yaml --debug -n microservices
