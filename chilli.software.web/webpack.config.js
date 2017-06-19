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
            './_app/style/shared/vendor.scss',
            './_app/style/shared/style.scss',
            'bootstrap',
            'jquery.easing',
            './_app/script/shared/script.ts'
        ],
        home: './_app/style/home/style.scss'
    },
    output: {
        filename: '_app/script/[name]/script.bundle.js',
        path: path.resolve(__dirname, 'wwwroot'),
        publicPath: ""
    },
    module: {
        rules: [
            {
                test: /\.woff($|\?)|\.woff2($|\?)|\.ttf($|\?)|\.eot($|\?)|\.svg($|\?)/,
                loader: 'file-loader',
                options: {
                    name: "_app/style/shared/[name].[ext]",
                    publicPath: function (url) {
                        return url.replace("_app/style/shared/", "");
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
        new ExtractTextPlugin("_app/style/[name]/style.bundle.css"),
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