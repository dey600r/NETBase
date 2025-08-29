const { shareAll, withModuleFederationPlugin } = require('@angular-architects/module-federation/webpack');

module.exports = withModuleFederationPlugin({

  name: 'app-module',

  remotes: {
      // "vehicle-module": "http://localhost:4201/remoteEntry.js",
      // "security-module": "http://localhost:4202/remoteEntry.js", --> STATIC WEB
   },

  shared: {
    ...shareAll({ singleton: true, strictVersion: true, requiredVersion: 'auto' }),
    'security-lib': { singleton: true, strictVersion: true }
  },

});
