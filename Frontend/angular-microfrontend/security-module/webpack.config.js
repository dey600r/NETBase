const { shareAll, withModuleFederationPlugin } = require('@angular-architects/module-federation/webpack');

module.exports = withModuleFederationPlugin({

  name: 'security-module',

    exposes: {
      "./routes": "./src/app/app.routes.ts",
    },
  
    shared: {
      ...shareAll({ singleton: true, strictVersion: true, requiredVersion: 'auto' }),
      'security-lib': { singleton: true, strictVersion: true }
    },

});
