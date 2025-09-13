//const ModuleFederationPlugin = require('webpack/lib/container/ModuleFederationPlugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const ModuleFederationPlugin = require('webpack').container.ModuleFederationPlugin;

module.exports = {
    mode: 'development',
    entry: './src/index',
    output: {
        publicPath: 'http://localhost:4204/',
        clean: true
    },
    devServer: {
        port: 4204,
        hot: false,
        liveReload: true,
        headers: {
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Methods": "GET, POST, PUT, DELETE, PATCH, OPTIONS",
            "Access-Control-Allow-Headers": "X-Requested-With, content-type, Authorization"
        }
    },
    module: {
        rules: [
            {
                test: /\.m?js$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/preset-env', '@babel/preset-react'],
                    },
                },
            },
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader'],
            },
            {
                test: /\.(png|jpe?g|gif|svg)$/i,
                type: 'asset/resource',
            },
        ],
    },
    plugins: [
        new ModuleFederationPlugin({
            name: 'setting_module',
            filename: 'remoteEntry.js',
            exposes: {
                './component': './src/App',
            },
            shared: { 
                react: { singleton: true }, 
                'react-dom': { singleton: true } 
            }
        }),
        new HtmlWebpackPlugin({
            template: './public/index.html',
        }),
    ],
};