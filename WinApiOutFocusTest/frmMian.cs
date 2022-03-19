using System.Text;

namespace WinApiOutFocusTest
{
    public partial class frmMian : Form
    {

        /// <summary>
        /// 마지막으로 검색된 윈도우 아이디
        /// </summary>
        private IntPtr m_hWnd = IntPtr.Zero;
        /// <summary>
        /// 대상 클래스명
        /// </summary>
        private string sClassName = string.Empty;


        /// <summary>
        /// 아웃 포커스 창<br />
        /// Out Focus window
        /// </summary>
        private frmOutFocus m_frmOutFocus;

        public frmMian()
        {
            InitializeComponent();

            this.m_frmOutFocus = new frmOutFocus(this);
        }

        private void checkMouseEventEnable_CheckedChanged(object sender, EventArgs e)
        {
            this.MouseEventEnable = this.checkMouseEventEnable.Checked;
        }

        private void btnOpenOutFocus_Click(object sender, EventArgs e)
        {
            this.m_frmOutFocus.Show();
        }


        

        
        /// <summary>
        /// 로그 추가
        /// </summary>
        /// <param name="sMessage"></param>
        private void LogAdd(string sMessage)
        {
            ListViewItem item = new ListViewItem();
            item.Text = DateTime.Now.ToString("HH:mm:ss");
            item.SubItems.Add(sMessage);

            this.listLog.Items.Add(item);
            this.listLog.Items[this.listLog.Items.Count - 1].EnsureVisible();
        }



        #region SendMessage Constants

        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_LBUTTONDBLCLK = 0x0203;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;
        private const int WM_RBUTTONDBLCLK = 0x0206;
        private const int WM_MOUSEMOVE = 0x0200;



        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;

        const int WM_SETTEXT = 0x000C;

        #endregion SendMessage Constants

        /// <summary>
        /// 지정된 윈도우의 하위 윈도를 찾기.
        /// https://blog.naver.com/tipsware/221547634772
        /// </summary>
        /// <param name="Parent">찾을 부모 창의 핸들</param>
        /// <param name="Child">몇번째 단계에서 찾을지 한들</param>
        /// <param name="lpszClass"></param>
        /// <param name="lpszWindows"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr Parent, IntPtr Child, string lpszClass, string lpszWindows);

        /// <summary>
        /// 지정한 핸들에 포커스를 준다.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int PostMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

        private void DragMove_Focus(
            System.Drawing.Point pointStart
            , System.Drawing.Point pointEnd)
        {
            if (this.m_hWnd != IntPtr.Zero)
            {
                //플레이어를 찾았을 경우 클릭이벤트를 발생시킬 핸들을 가져옵니다.
                //IntPtr hwnd_child = FindWindowEx(this.m_hWnd, IntPtr.Zero, "RenderWindow", "TheRender");
                IntPtr hwnd_child = FindWindowEx(this.m_hWnd, IntPtr.Zero
                    , "WindowsForms10.Static.app.0.29e8405_r3_ad1", null);
                IntPtr lparamStart = new IntPtr(pointStart.X | (pointStart.Y << 16));
                IntPtr lparamEnd = new IntPtr(pointEnd.X | (pointEnd.Y << 16));

                //포커스 전달.
                SetForegroundWindow(this.m_hWnd);
                Thread.Sleep(1000);

                //플레이어 핸들에 클릭 이벤트를 전달합니다.
                //SendMessage(hwnd_child, WM_LBUTTONDOWN, 0, lparamStart);
                //SendMessage(hwnd_child, WM_MOUSEMOVE, 0, lparamEnd);
                PostMessage(hwnd_child, WM_LBUTTONDOWN, 0, lparamStart);
                //Thread.Sleep(2000);
                PostMessage(hwnd_child, WM_MOUSEMOVE, 0, lparamEnd);

                //int nMax = pointEnd.Y - pointStart.Y;

                //for (int i = 0; i < nMax; ++i)
                //{

                //}
            }
        }

        private void btnOutfocusWindowDrag_Click(object sender, EventArgs e)
        {
            DragMove_Focus(new Point(200, 100), new Point(200, 100));
        }
    }
}