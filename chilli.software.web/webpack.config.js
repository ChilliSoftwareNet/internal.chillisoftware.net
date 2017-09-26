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
            './_app/shared/styles/vendor.scss',
            './_app/shared/styles/style.scss',
            'bootstrap',
            'jquery.easing',
            'jquery-validation',
            'knockout',
            './_app/shared/scripts/script.ts'
        ],
        home: [
            './_app/home/styles/style.scss',
            './_app/home/scripts/contactForm.ts'
        ]
    },
    output: {
        filename: '_app/[name]/scripts/script.bundle.js',
        path: path.resolve(__dirname, 'wwwroot'),
        publicPath: ""
    },
    module: {
        rules: [
            {
                test: /\.woff($|\?)|\.woff2($|\?)|\.ttf($|\?)|\.eot($|\?)|\.svg($|\?)/,
                loader: 'file-loader',
                options: {
                    name: "_app/shared/styles/[name].[ext]",
                    publicPath: function (url) {
                        return url.replace("_app/shared/styles/", "");
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
        new ExtractTextPlugin("_app/[name]/styles/style.bundle.css"),
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