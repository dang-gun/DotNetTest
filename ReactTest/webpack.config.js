const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CssMinimizerPlugin = require("css-minimizer-webpack-plugin");

//�ҽ� ��ġ
const RootPath = path.resolve(__dirname);
const SrcPath = path.resolve(RootPath, "src");

//�������� ����ϴ� ���� �̸�
const WwwRoot = "wwwroot";
//�������� ����ϴ� ���� ��ġ
const WwwRootPath = path.resolve(__dirname, WwwRoot);
//����Ʈ ���ø� ��ġ
//const IndexHtmlPath = path.resolve(WwwRootPath, "index.html");
const IndexHtmlPath = path.resolve(SrcPath, "index.html");
//����� ��� ���� �̸�
const OutputFolder = "dist";
//����� ��� ���� �̸� - �̹��� ����
const OutputFolder_Images = "images";
//����� ��� ��ġ
const OutputPath = path.resolve(WwwRootPath, OutputFolder);
//����� ��� ��ġ - ��� �ּ�
const OutputPath_relative = path.resolve("/", OutputFolder);


module.exports = (env, argv) =>
{
    return {
        //���� ���
        mode: argv.mode === "production" ? "production" : "development",
        devtool: "eval",
        //devtool: "inline-source-map",
        resolve: {
            extensions: [".js", ".jsx"]
        },
        entry: { // ������ ���� ��ҵ� �Է�
            app: [path.resolve(SrcPath, "index.js") ],
        },
        output: {// ���������� ������� js
            //���� ��ġ
            path: OutputPath, 
            //���� ���� �� ���������� ������� ����
            filename: "app.js"  
        },
        module: {
            rules: [
                {
                    test: /\.(js|jsx)$/,
                    exclude: /node_module/,
                    use:
                        [
                            { loader: "babel-loader" },
                        ]
                },
                {
                    test: /\.css$/i,
                    exclude: /node_module/,
                    use:
                        [
                            { loader: "style-loader" },
                            {
                                loader: MiniCssExtractPlugin.loader,
                                options: { esModule: false }
                            },
                            { loader: "css-loader" },
                            { loader: 'postcss-loader' },
                        ]
                },
                {
                    test: /\.s[c|a]ss$/,
                    use:
                        [
                            {
                                loader: MiniCssExtractPlugin.loader,
                                options: { esModule: false }
                            },
                            { loader: 'css-loader' },
                            { loader: 'postcss-loader' },
                            { loader: 'sass-loader' }
                        ]
                },
                {
                    rules: [
                        {
                            test: /\.(png|jpg|gif|svg)$/,
                            loader: "file-loader",
                            options: {
                                outputPath: OutputFolder_Images,
                                name: "[name].[ext]?[hash]",
                            }
                        },
                    ],
                }
            ]
        },
        optimization: {
            minimizer: [
                new CssMinimizerPlugin(),
            ],
        },
        plugins: [
            // ������ �����(��>��������)�� HTML�� �������ִ� �÷�����
            new HtmlWebpackPlugin({ template: IndexHtmlPath }), 
            // ���������� �ٽ� ���� �� �� webpack�� output.path���ִ� ��� ���������� ���빰 ����
            new CleanWebpackPlugin(),
            // ������ css ������ ���� �����ϴ� Plugin
            new MiniCssExtractPlugin({
                filename: "bundle.css"
            }),
            new MiniCssExtractPlugin()
        ],
        devServer: {
            //���� ��Ʈ
            port: "9500",
            /** "static" 
             * This property tells Webpack what static file it should serve
            */
            //static: ["./public"],
            static: [path.resolve("./", WwwRoot)],
            //������ ���� ����
            open: true,
            //�ָ��ε� ��뿩��
            hot: true,
            /** "liveReload"
             * disable live reload on the browser. "hot" must be set to false for this to work
            */
            liveReload: true
        },
    };
}