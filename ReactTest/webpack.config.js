const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CssMinimizerPlugin = require("css-minimizer-webpack-plugin");

//소스 위치
const RootPath = path.resolve(__dirname);
const SrcPath = path.resolve(RootPath, "src");

//웹서버가 사용하는 폴더 이름
const WwwRoot = "wwwroot";
//웹서버가 사용하는 폴더 위치
const WwwRootPath = path.resolve(__dirname, WwwRoot);
//리액트 템플릿 위치
//const IndexHtmlPath = path.resolve(WwwRootPath, "index.html");
const IndexHtmlPath = path.resolve(SrcPath, "index.html");
//결과물 출력 폴더 이름
const OutputFolder = "dist";
//결과물 출력 폴더 이름 - 이미지 폴더
const OutputFolder_Images = "images";
//결과물 출력 위치
const OutputPath = path.resolve(WwwRootPath, OutputFolder);
//결과물 출력 위치 - 상대 주소
const OutputPath_relative = path.resolve("/", OutputFolder);


module.exports = (env, argv) =>
{
    return {
        //서비스 모드
        mode: argv.mode === "production" ? "production" : "development",
        devtool: "eval",
        //devtool: "inline-source-map",
        resolve: {
            extensions: [".js", ".jsx"]
        },
        entry: { // 합쳐질 파일 요소들 입력
            app: [path.resolve(SrcPath, "index.js") ],
        },
        output: {// 최종적으로 만들어질 js
            //빌드 위치
            path: OutputPath, 
            //웹팩 빌드 후 최종적으로 만들어질 파일
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
            // 빌드한 결과물(예>번들파일)을 HTML에 삽입해주는 플러그인
            new HtmlWebpackPlugin({ template: IndexHtmlPath }), 
            // 성공적으로 다시 빌드 한 후 webpack의 output.path에있는 모든 빌드폴더의 내용물 제거
            new CleanWebpackPlugin(),
            // 별도로 css 파일을 만들어서 빌드하는 Plugin
            new MiniCssExtractPlugin({
                filename: "bundle.css"
            }),
            new MiniCssExtractPlugin()
        ],
        devServer: {
            //서비스 포트
            port: "9500",
            /** "static" 
             * This property tells Webpack what static file it should serve
            */
            //static: ["./public"],
            static: [path.resolve("./", WwwRoot)],
            //브라우저 열지 여부
            open: true,
            //핫리로드 사용여부
            hot: true,
            /** "liveReload"
             * disable live reload on the browser. "hot" must be set to false for this to work
            */
            liveReload: true
        },
    };
}