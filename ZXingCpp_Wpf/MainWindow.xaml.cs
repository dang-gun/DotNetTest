using System.Buffers.Text;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using CefSharp;
using CefSharp.Wpf;

namespace ZXingCpp_Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// 브라우저 개체
    /// </summary>
    private ChromiumWebBrowser m_Browser;

    public MainWindow()
    {
        InitializeComponent();

        CefSettings settings = new CefSettings() { CachePath = null };
        //ttings.RegisterScheme(new CefCustomScheme { SchemeName = "eutp" });
        settings.MultiThreadedMessageLoop = true;
        settings.CefCommandLineArgs.Add("disable-features", "BlockInsecurePrivateNetworkRequests");
        
        //CORS 끄기 설정
        settings.CefCommandLineArgs.Add("disable-web-security", "disable-web-security");
        //사용자 데이터 경로 지정
        string cache_dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\temp";
        settings.CefCommandLineArgs.Add("user-data-dir", cache_dir);
        Cef.Initialize(settings);

        string curDir = Directory.GetCurrentDirectory();
        //this.m_Browser = new ChromiumWebBrowser("https://www.google.co.kr/");
        this.m_Browser = new ChromiumWebBrowser($"file:///{curDir}/ZxingWasm/demo_reader_Custom.html");
        Grid.SetRow(this.m_Browser, 1);
        this.gridMain.Children.Add(this.m_Browser);

    }

    private void MenuItem_DevTool(object sender, RoutedEventArgs e)
    {
        this.m_Browser.ShowDevTools();
    }

    private void MenuItem_TestQr(object sender, RoutedEventArgs e)
    {
        byte[] byteImg = File.ReadAllBytes(@"TestImages\Test_MicroQR.jpg");

        string s = Convert.ToBase64String(byteImg);

        

        Task.Run(() =>
        {
            string s2 = this.Browser_EvaluateScriptAsync($"ShowData('{s}')").Result;
            if (1 == 1)
            {

            }

            Dispatcher.Invoke(DispatcherPriority.Normal
            , new Action(
                delegate
                {
                    
                }));

        });
    }

    private void CallBrowser(string sData)
    {
        
    }

    /// <summary>
    /// 브라우저 스크립트 호출
    /// </summary>
    /// <param name="sCommand"></param>
    public async Task<string> Browser_EvaluateScriptAsync(string sCommand)
    {
        DateTime dtNow = DateTime.Now;
        

        JavascriptResponse jr 
         = await this.m_Browser
                .GetMainFrame()
                .EvaluateScriptAsync(sCommand);

        List<object> s = (List<object>)jr.Result;

        Debug.WriteLine($"EvaluateScriptAsync : {DateTime.Now.Ticks - dtNow.Ticks}");

        
        if (1==1)
        {

        }

        return "aa";
    }
}