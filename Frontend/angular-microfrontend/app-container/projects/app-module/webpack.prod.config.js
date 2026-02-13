const mfConfig = require('./webpack.config');

module.exports = {
  ...mfConfig,
//   output: {
//     ...(mfConfig.output || {}),
//     publicPath: 'auto',
//   },
};