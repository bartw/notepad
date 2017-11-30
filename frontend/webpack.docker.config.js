const path = require("path");
const CopyWebpackPlugin = require("copy-webpack-plugin");

module.exports = {
  devtool: "cheap-module-eval-source-map",
  entry: "./src/index.js",
  output: { filename: "bundle.js", path: path.resolve(__dirname, "dist") },
  resolve: { extensions: [".jsx", ".js"] },
  module: {
    rules: [
      { test: /\.jsx?$/, exclude: /node_modules/, use: "babel-loader" },
      { test: /\.css$/, use: ["style-loader", "css-loader"] }
    ]
  },
  watchOptions: { poll: true },
  plugins: [new CopyWebpackPlugin([{ from: "src/index.html" }])]
};
