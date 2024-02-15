using CefSharp;
using CefSharp.Handler;
using System;
using System.Net;
using System.Web;

namespace FIPA_Admin.App.CefSharpAssist
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestHandlerExt : RequestHandler
    {
        #region 외부로 노출할 이벤트
        /// <summary>
        /// 자바스크립트로 부터 명령이 넘어왔음을 알리는 대리자
        /// </summary>
        public delegate void CommandMessageDelegate(Uri uri);
        /// <summary>
        /// 자바스크립트로 부터 명령이 넘어왔음다.
        /// </summary>
        public event CommandMessageDelegate? OnCommandMessage;

        /// <summary>
        /// 자바스크립트로 부터 명령이 넘어왔음을 알림
        /// </summary>
        /// <param name="uri"></param>
        private void CommandMessageCall(Uri uri)
        {
            if (this.OnCommandMessage != null)
            {
                this.OnCommandMessage(uri);
            }
        }

        #endregion

        private string userAgent;


        /// <summary>
        /// 
        /// </summary>
        public RequestHandlerExt()
        {
            this.userAgent = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAgent"></param>
        public RequestHandlerExt(string userAgent)
        {
            this.userAgent = userAgent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chromiumWebBrowser"></param>
        /// <param name="browser"></param>
        /// <param name="frame"></param>
        /// <param name="request"></param>
        /// <param name="isNavigation"></param>
        /// <param name="isDownload"></param>
        /// <param name="requestInitiator"></param>
        /// <param name="disableDefaultHandling"></param>
        /// <returns></returns>
        protected override IResourceRequestHandler GetResourceRequestHandler(
            IWebBrowser chromiumWebBrowser
            , IBrowser browser
            , IFrame frame
            , IRequest request
            , bool isNavigation
            , bool isDownload
            , string requestInitiator
            , ref bool disableDefaultHandling)
        {

            int a = 0;
            if (a == 0)
            {
                disableDefaultHandling = false;
            }


            if (true == string.IsNullOrEmpty(userAgent))
            {
                return new ResourceRequestHandlerExt(userAgent);
            }
            else
            { 
                return base.GetResourceRequestHandler(
                                chromiumWebBrowser
                                , browser
                                , frame
                                , request
                                , isNavigation
                                , isDownload
                                , requestInitiator
                                , ref disableDefaultHandling); 
            }
        }

        /// <summary>
        /// 브라우저 주소가 변경되기 전에 발생하는 이벤트<br />
        /// 여기서 이벤트 취소가 가능하다.
        /// https://stackoverflow.com/questions/61659146/can-cefsharp-browser-navigation-be-avoided-after-custom-protocol-handling
        /// </summary>
        protected override bool OnBeforeBrowse(
            IWebBrowser chromiumWebBrowser
            , IBrowser browser
            , IFrame frame
            , IRequest request
            , bool userGesture
            , bool isRedirect)
        {
            
            Uri uri = new Uri(request.Url);

            if ("CSCommand".ToLower() == uri.Host)
            {
                this.CommandMessageCall(uri);

                return true; // cancel navigation
            }

            return false; // allows navigation
        }
    }
}
