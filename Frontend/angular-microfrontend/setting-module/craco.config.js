const { ModuleFederationPlugin } = require('webpack').container;

module.exports = {
  webpack: {
    configure: (config, { env }) => {
      config.output.publicPath = 'auto';

      config.optimization = {
          minimize: true,
          splitChunks: false,
          runtimeChunk: false,
      };
      // 🔹 Equivalente a optimization
      // config.optimization = {
      //   ...config.optimization,
        // minimize: env === 'production',
        // splitChunks: {
        //   chunks: 'all',
        // },
        // runtimeChunk: 'single',
      // };

      config.plugins.push(
        new ModuleFederationPlugin({
          name: 'setting_module',
          filename: 'remoteEntry.js',
          exposes: {
            './component': './src/App',
          },
          shared: {
            react: {
              singleton: true,
              requiredVersion: false,
            },
            'react-dom': {
              singleton: true,
              requiredVersion: false,
            },
          },
        })
      );

      return config;
    },
  },

  // 🔹 Equivalente a devServer
  // devServer: {
  //   port: 2004,
  //   headers: {
  //     'Access-Control-Allow-Origin': '*',
  //     'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, PATCH, OPTIONS',
  //     'Access-Control-Allow-Headers': 'X-Requested-With, content-type, Authorization',
  //   },
  // },
};
