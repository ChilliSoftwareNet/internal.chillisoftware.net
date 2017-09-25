var webpack = require("webpack");
var path = require('path');
var ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = {
    resolve: {
        extensions: [".ts", ".js"],
        alias: {
            jquery: "jquery/src/jquery"
        }
    },
    entry: {
        shared: [
            './_app/styles/shared/vendor.scss',
            './_app/styles/shared/style.scss',
            'bootstrap',
            'jquery.easing',
            './_app/scripts/shared/script.ts'
        ],
        home: './_app/styles/home/style.scss'
    },
    output: {
        filename: '_app/scripts/[name]/script.bundle.js',
        path: path.resolve(__dirname, 'wwwroot'),
        publicPath: ""
    },
    module: {
        rules: [
            {
                test: /\.woff($|\?)|\.woff2($|\?)|\.ttf($|\?)|\.eot($|\?)|\.svg($|\?)/,
                loader: 'file-loader',
                options: {
                    name: "_app/styles/shared/[name].[ext]",
                    publicPath: function (url) {
                        return url.replace("_app/styles/shared/", "");
                    }
                }
            },
            {
                test: /\.scss$/,
                use: ExtractTextPlugin.extract({
                    use: "css-loader!sass-loader"
                })
            },
            { test: /\.tsx?$/, loader: 'ts-loader' }
        ]
    },
    plugins: [
        new ExtractTextPlugin("_app/styles/[name]/style.bundle.css"),
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery'
        })
    ],
    devServer: {
        proxy: {
            '/': {
                target: 'http://localhost:4000',
            }
        }
    }
}