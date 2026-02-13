const { shareAll, withModuleFederationPlugin } = require('@angular-architects/module-federation/webpack');

module.exports = withModuleFederationPlugin({

  name: 'app-module',
  
  remotes: {
    //"setting_module": "http://localhost:4204/remoteEntry.js",
    // "vehicle-module": "http://localhost:4201/remoteEntry.js",
    // "security-module": "http://localhost:4202/remoteEntry.js", --> STATIC WEB
    // "maintenance-module": "http://localhost:4203/remoteEntry.js",
   },

  shared: {
    ...shareAll({ singleton: true, strictVersion: true, requiredVersion: 'auto' }),
    'security-lib': { singleton: true, strictVersion: true }
  },

});
