const VueLoader = require("vue-loader");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const CopyWebpackPlugin = require('copy-webpack-plugin');
const FederationPlugin = require("webpack/lib/container/ModuleFederationPlugin");

module.exports = {
    mode: 'production',
    output: {
        publicPath: 'auto',
    },
    resolve: {
        extensions: ['.js', '.vue']
    },
    module: {
        rules: [
            {
                test: /\.m?js$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/preset-env'],
                    },
                },
            },
            {
                test: /\.css$/i,
                use: ['style-loader', 'css-loader'],
            },
            {
                test: /\.vue$/,
                loader: 'vue-loader',
            },
            {
                test: /\.(png|jpe?g|gif|svg)$/i,
                type: 'asset/resource',
            }
            // {
            //     test: /\.svg$/i,
            //     type: 'asset/resource',
            //     generator: {
            //         filename: 'assets/[name][ext]', // mantiene nombre
            //     },
            // },
            
        ],
    },
    plugins:[
        new VueLoader.VueLoaderPlugin(),
        new HtmlWebpackPlugin({
            template: './public/index.html',
        }),
        new FederationPlugin({
            name: 'home_module',
            filename: 'remoteEntry.js',
            exposes: {
                './component': './src/bootstrap',
            }
        }),
        new CopyWebpackPlugin({
            patterns: [
            {
                from: 'src/assets',
                to: './assets',
                globOptions: {
                    ignore: [],
                },
            },
            ],
        }),
    ]
}