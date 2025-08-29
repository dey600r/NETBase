const { shareAll, withModuleFederationPlugin } = require('@angular-architects/module-federation/webpack');

module.exports = withModuleFederationPlugin({

  name: 'maintenance-module',

  exposes: {
      "./routes": "./src/app/pages/maintenance.routes.ts",
    },
  
    remotes: {
       "security-module": "http://localhost:4202/remoteEntry.js",
     },

  shared: {
    ...shareAll({ singleton: true, strictVersion: true, requiredVersion: 'auto' }),
    'security-lib': { singleton: true, strictVersion: true }
  },

});
