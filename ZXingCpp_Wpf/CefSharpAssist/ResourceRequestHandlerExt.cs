using CefSharp;
using CefSharp.Handler;

namespace FIPA_Admin.App.CefSharpAssist
{
    /// <summary>
    /// https://stackoverflow.com/questions/58196230/in-there-a-replacement-for-onbeforeresourceload-in-irequesthandler
    /// </summary>
    public class ResourceRequestHandlerExt : ResourceRequestHandler
    {
        private string userAgent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAgent"></param>
        public ResourceRequestHandlerExt(string userAgent)
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
        /// <param name="callback"></param>
        /// <returns></returns>
        protected override CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            //var headers = request.Headers;
            //headers["User-Agent"] = userAgent;
            //request.Headers = headers;


            return base.OnBeforeResourceLoad(chromiumWebBrowser, browser, frame, request, callback);
        }
    }
}
