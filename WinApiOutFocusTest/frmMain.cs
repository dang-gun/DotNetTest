
using System.Diagnostics;
using System.Text;
using WinApiOutFocusTest.Global;

namespace WinApiOutFocusTest
{
    public partial class frmMain : Form
    {

        /// <summary>
        /// 아웃 포커스 창<br />
        /// Out Focus window
        /// </summary>
        private frmOutFocus m_frmOutFocus;

        /// <summary>
        /// 픽쳐박스 공통화
        /// </summary>
        private PictureAssist m_PA;


        public frmMain()
        {
            InitializeComponent();

            this.m_PA = new PictureAssist(this, this.pictureDraw);
            this.m_PA.OnLog += M_PA_OnLog;

            this.m_PA.OnMouseDownEvent += M_PA_OnMouseDownEvent;
            this.m_PA.OnMouseMoveEvent += M_PA_OnMouseMoveEvent;
            this.m_PA.OnMouseUpEvent += M_PA_OnMouseUpEvent;

            this.m_frmOutFocus = new frmOutFocus(this);


        }





        private void frmMian_Load(object sender, EventArgs e)
        {
            this.m_PA.ImageClear();

            GlobalStatic.MainWndHandle
                = GlobalStatic.FindWindow(null, "Win32 Drag Test");

            //플레이어를 찾았을 경우 클릭이벤트를 발생시킬 핸들을 가져옵니다.
            GlobalStatic.MainWndHandle_Child
                = GlobalStatic.FindWindowEx(
                    GlobalStatic.MainWndHandle, IntPtr.Zero
                    , "WindowsForms10.Window.8.app.0.29e8405_r3_ad1", null);
        }

        #region log
        private void M_PA_OnLog(string sLog, MouseEventArgs e)
        {
            this.LogAdd(sLog);
        }

        /// <summary>
		/// 로그 추가
		/// </summary>
		/// <param name="sMessage"></param>
		private void LogAdd(string sMessage)
        {
            if (true == InvokeRequired)
            {//다른 쓰래드다.
                this.Invoke(new Action(
                    delegate ()
                    {
                        this.LogAddNotInvoke(sMessage);
                    }));
            }
            else
            {//같은 쓰래드다.
                this.LogAddNotInvoke(sMessage);
            }
        }
        /// <summary>
        /// 로그 추가(인보크 없음)
        /// </summary>
        /// <param name="sMessage"></param>
        private void LogAddNotInvoke(string sMessage)
        {
            ListViewItem item = new ListViewItem();
            item.Text = DateTime.Now.ToString("HH:mm:ss");
            item.SubItems.Add(sMessage);

            this.listLog.Items.Add(item);
            this.listLog.Items[this.listLog.Items.Count - 1].EnsureVisible();
        }
        #endregion

        private void btnImageClear_Click(object sender, EventArgs e)
        {
            this.m_PA.ImageClear();
        }



        private void checkMouseEventEnable_CheckedChanged(object sender, EventArgs e)
        {
            this.m_PA.MouseEventEnable = this.checkMouseEventEnable.Checked;
        }

        private void btnOpenOutFocus_Click(object sender, EventArgs e)
        {
            this.m_frmOutFocus.Show();
            //this.m_hWnd = FindWindow(null, "Win32 Drag Test");
        }




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
        //static extern int PostMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        /// <summary>
        /// frmMain Drag
        /// </summary>
        /// <param name="pointStart"></param>
        /// <param name="pointEnd"></param>
        private void DragMove_frmMain(
            System.Drawing.Point pointStart
            , System.Drawing.Point pointEnd)
        {
            if (GlobalStatic.MainWndHandle != IntPtr.Zero
                && GlobalStatic.MainWndHandle_Child != IntPtr.Zero)
            {

                int lparamStart = MakeLParam(pointStart);
                int lparamEnd = MakeLParam(pointEnd);

                //포커스 전달.
                SetForegroundWindow(GlobalStatic.MainWndHandle_Child);
                //Thread.Sleep(1000);

                //Mouse left button down
                //-> Mouse move
                //-> Mouse left button up
                PostMessage(GlobalStatic.MainWndHandle_Child
                                    , GlobalStatic.WM_LBUTTONDOWN, 0, lparamStart);

                //Thread.Sleep(2000);
                PostMessage(GlobalStatic.MainWndHandle_Child
                    , GlobalStatic.WM_MOUSEMOVE, 0, lparamEnd);

                PostMessage(GlobalStatic.MainWndHandle_Child
                    , GlobalStatic.WM_LBUTTONUP, 0, lparamEnd);
            }
        }

        private void btnOutFocus_Drag_Click(object sender, EventArgs e)
        {
            this.DragMove_frmOutFocus(
                new Point(100, 100)
                , new Point(200, 200)
                , true);
        }

        private void btnOutFocus_Drag2_Click(object sender, EventArgs e)
        {
            this.DragMove_frmOutFocus(
                new Point(100, 100)
                , new Point(200, 200)
                , false);
        }

        private void btnOutFocus_Drag3_Click(object sender, EventArgs e)
        {
            Task task = new Task(new Action(() => { 
                Thread.Sleep(3000);

                this.DragMove_frmOutFocus(
                    new Point(100, 100)
                    , new Point(200, 200)
                    , true);
            }));

            task.Start();
        }

        /// <summary>
        /// frmOutFocus Drag
        /// </summary>
        /// <param name="pointStart"></param>
        /// <param name="pointEnd"></param>
        /// <param name="bFocus"></param>
        private void DragMove_frmOutFocus(
            Point pointStart
            , Point pointEnd
            , bool bFocus)
        {
            if (GlobalStatic.OutFocusWndHandle != IntPtr.Zero
                && GlobalStatic.OutFocusWndHandle_Child != IntPtr.Zero)
            {
                //Thread.Sleep(3000);

                int lparamStart = MakeLParam(pointStart);
                int lparamEnd = MakeLParam(pointEnd);

                if (true == bFocus)
                {
                    //포커스 전달.
                    //SetForegroundWindow(GlobalStatic.OutFocusWndHandle_Child);
                    SetForegroundWindow(GlobalStatic.OutFocusWndHandle);
                }
                else
                {
                }

                //Thread.Sleep(1000);

                //Mouse left button down
                //-> Mouse move
                //-> Mouse left button up
                PostMessage(GlobalStatic.OutFocusWndHandle_Child
                                    , GlobalStatic.WM_LBUTTONDOWN, 0, lparamStart);

                //Thread.Sleep(2000);
                PostMessage(GlobalStatic.OutFocusWndHandle_Child
                    , GlobalStatic.WM_MOUSEMOVE, 0, lparamEnd);

                PostMessage(GlobalStatic.OutFocusWndHandle_Child
                    , GlobalStatic.WM_LBUTTONUP, 0, lparamEnd);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DragMove_frmMain(new Point(100, 100), new Point(200, 200));
        }

        public static int MakeLParam(int x, int y) => (y << 16) | (x & 0xFFFF);
        public static int MakeLParam(Point pointStart)
        {
            return MakeLParam(pointStart.X, pointStart.Y);
        }

        private void btnThisDrag_Click(object sender, EventArgs e)
        {
            this.DragMove_frmMain(
                new Point(100, 100)
                , new Point(200, 200));
        }

        #region pictureDraw Mouse Action
        private bool _bPictureDraw_MouseDown = false;

        private void M_PA_OnMouseDownEvent(object? sender, MouseEventArgs e, int nWM)
        {
            //Debug.WriteLine("Mouse down : {0}, {1}", e.X, e.Y);
            this._bPictureDraw_MouseDown = true;

            //Mouse left button down
            int lparamStart = MakeLParam(new Point(e.X, e.Y));
            SendMessage(GlobalStatic.OutFocusWndHandle_Child
                                , GlobalStatic.WM_LBUTTONDOWN, 0, lparamStart);
        }

        private void M_PA_OnMouseMoveEvent(object? sender, MouseEventArgs e, int nWM)
        {
            if (true == this._bPictureDraw_MouseDown)
            {
                //-> Mouse move
                //int lparamEnd
                //	= MakeLParam(
                //		new Point(
                //			e.X + this.m_frmOutFocus.Location.X
                //			, e.Y + this.m_frmOutFocus.Location.Y));
                //SendMessage(GlobalStatic.OutFocusWndHandle_Child
                //	, GlobalStatic.WM_MOUSEMOVE, 0, lparamEnd);
            }
        }

        private void M_PA_OnMouseUpEvent(object? sender, MouseEventArgs e, int nWM)
        {
            //Debug.WriteLine("Mouse up : {0}, {1}", e.X, e.Y);
            this._bPictureDraw_MouseDown = false;

            //-> Mouse Up
            //int lparamEnd = MakeLParam(new Point(e.X, e.Y));
            //SendMessage(GlobalStatic.OutFocusWndHandle_Child
            //	, GlobalStatic.WM_LBUTTONUP, 0, lparamEnd);
        }
        #endregion

        private void btnDragDeley_Click(object sender, EventArgs e)
        {
            DragDeley();
        }



        private int nTimerCount = 0;
        private Point DragDeley_Point = new Point(0, 0);


        System.Timers.Timer timer;
        public void DragDeley()
        {
            nTimerCount = 0;
            DragDeley_Point = new Point(100, 100);

            //Mouse left button down
            int lparamStart = MakeLParam(DragDeley_Point);
            SendMessage(GlobalStatic.OutFocusWndHandle_Child
                                , GlobalStatic.WM_LBUTTONDOWN, 0, lparamStart);

            DragDeley_Point.Offset(1, 1);
            //-> Mouse move
            int lparamMove = MakeLParam(DragDeley_Point);
            SendMessage(GlobalStatic.OutFocusWndHandle_Child
                , GlobalStatic.WM_MOUSEMOVE, 0, lparamMove);


            timer = new System.Timers.Timer();
            timer.Interval = 10;
            timer.Elapsed += (a, b) => 
            {
                if (nTimerCount < 60)
                {
                    DragDeley_Point.Offset(1, 1);
                    //-> Mouse move
                    int lparamMove = MakeLParam(DragDeley_Point);
                    SendMessage(GlobalStatic.OutFocusWndHandle_Child
                        , GlobalStatic.WM_MOUSEMOVE, 0, lparamMove);
                }
                else
                {
                    //-> Mouse Up
                    int lparamEnd = MakeLParam(DragDeley_Point);
                    SendMessage(GlobalStatic.OutFocusWndHandle_Child
                        , GlobalStatic.WM_LBUTTONUP, 0, lparamEnd);
                    timer.Stop();
                }

                ++nTimerCount;
            };

            timer.Start();

        }

		
	}
}