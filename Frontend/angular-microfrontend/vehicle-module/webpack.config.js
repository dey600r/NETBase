const { shareAll, withModuleFederationPlugin } = require('@angular-architects/module-federation/webpack');

module.exports = withModuleFederationPlugin({

  name: 'vehicle-module',

  exposes: {
    // './Component': './src/app/app.component.ts',
    "./routes": "./src/app/pages/vehicle.routes.ts",
  },

  remotes: {
     "security-module": "http://localhost:4202/remoteEntry.js",
   },

  shared: {
    ...shareAll({ singleton: true, strictVersion: true, requiredVersion: 'auto' }),
    'security-lib': { singleton: true, strictVersion: true }
  },

});
