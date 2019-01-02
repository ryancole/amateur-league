const path = require("path");
const webpack = require("webpack");

module.exports = {
  mode: "development",
  entry: path.resolve(__dirname, "src/index.tsx"),
  output: {
    path: path.resolve(__dirname, "dist"),
    filename: "bundle.js",
    publicPath: "/scripts/"
  },
  module: {
    rules: [
      {
        use: "ts-loader",
        test: /\.tsx?$/,
        include: path.resolve(__dirname, "src")
      }
    ]
  },
  resolve: {
    extensions: [".tsx", ".ts", ".js"]
  },
  devServer: {
    hot: true,
    open: true,
    port: 8000,
    https: true,
    publicPath: "/scripts/",
    contentBase: path.resolve(__dirname, "public"),
    historyApiFallback: true
  },
  plugins: [new webpack.HotModuleReplacementPlugin()]
};
