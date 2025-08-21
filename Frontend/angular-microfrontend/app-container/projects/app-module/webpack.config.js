const { shareAll, withModuleFederationPlugin } = require('@angular-architects/module-federation/webpack');

module.exports = withModuleFederationPlugin({

  name: 'app-module',

  // exposes: {
  //   './AuthGuard': './projects/app-module/src/app/core/providers/guard.provider.ts',
  // },

  remotes: {
     "vehicle-module": "http://localhost:4201/remoteEntry.js",
   },

  shared: {
    ...shareAll({ singleton: true, strictVersion: true, requiredVersion: 'auto' }),
    'security-lib': { singleton: true, strictVersion: true }
  },

});
