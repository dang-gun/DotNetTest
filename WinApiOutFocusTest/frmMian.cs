
using System.Text;
using WinApiOutFocusTest.Global;

namespace WinApiOutFocusTest
{
    public partial class frmMian : Form
    {

        /// <summary>
        /// ���������� �˻��� ������ ���̵�
        /// </summary>
        private IntPtr m_hWnd = IntPtr.Zero;
        public bool MouseEventEnable = true;

        /// <summary>
        /// ���콺 �ٿ� ����
        /// </summary>
        public bool m_bMouseDown = false;
        /// <summary>
        /// ������ ����Ʈ
        /// </summary>
        private Point m_pointLast = Point.Empty;
        /// <summary>
        /// �׸��⿡ ���� �� ��ü
        /// </summary>
        private Pen m_pen = Pens.Black;

        /// <summary>
        /// ��� Ŭ������
        /// </summary>
        private string sClassName = string.Empty;


        /// <summary>
        /// �ƿ� ��Ŀ�� â<br />
        /// Out Focus window
        /// </summary>
        private frmOutFocus m_frmOutFocus;




        public frmMian()
        {
            InitializeComponent();

            this.m_frmOutFocus = new frmOutFocus(this);
        }

        private void frmMian_Load(object sender, EventArgs e)
        {
            this.ImageClear();
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
        /// ���� ���콺 Ű<br />
        /// mouse key to be pressed
        /// </summary>
        private MouseButtons MouseDownKey = MouseButtons.None;

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (true == MouseEventEnable)
            {
                this.MouseDownKey = e.Button;
                this.labMouseKeyShow.Text = this.MouseDownKey.ToString();
                this.m_pointLast = e.Location;
                this.m_bMouseDown = true;
                //Ŭ���Ҷ� ������
                this.m_pen = GlobalStatic.ColorGet();

                //Log
                StringBuilder sbLog = new StringBuilder();
                sbLog.Append("MouseDown Key : ");
                sbLog.Append(e.Button.ToString());
                sbLog.Append("(");
                sbLog.Append(e.X);
                sbLog.Append(",");
                sbLog.Append(e.Y);
                sbLog.Append(")");
                this.LogAdd(sbLog.ToString());
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (true == MouseEventEnable)
            {
                if (true == this.m_bMouseDown)
                {
                    if (Point.Empty != m_pointLast)
                    {
                        using (Graphics g = Graphics.FromImage(labMove.Image))
                        {
                            g.DrawLine(this.m_pen, this.m_pointLast, e.Location);
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        }

                        //���ΰ�ħ
                        labMove.Invalidate();

                        //������ ��ġ ����
                        this.m_pointLast = e.Location;
                    }
                }

                StringBuilder sbLog = new StringBuilder();
                sbLog.Append("MouseMove Key : ");
                sbLog.Append(this.MouseDownKey.ToString());
                sbLog.Append("(");
                sbLog.Append(e.X);
                sbLog.Append(",");
                sbLog.Append(e.Y);
                sbLog.Append(")");
                this.LogAdd(sbLog.ToString());
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (true == MouseEventEnable)
            {
                this.MouseDownKey = MouseButtons.None;
                this.labMouseKeyShow.Text = this.MouseDownKey.ToString();
                m_bMouseDown = false;
                m_pointLast = Point.Empty;

                StringBuilder sbLog = new StringBuilder();
                sbLog.Append("MouseUp Key : ");
                sbLog.Append(e.Button.ToString());
                sbLog.Append("(");
                sbLog.Append(e.X);
                sbLog.Append(",");
                sbLog.Append(e.Y);
                sbLog.Append(")");
                this.LogAdd(sbLog.ToString());
            }
        }

        /// <summary>
        /// �巹�� ���� �ʱ�ȭ
        /// </summary>
        private void ImageClear()
        {
            if (this.labMove.Image == null)
            {
                Bitmap bmp = new Bitmap(this.labMove.Width, this.labMove.Height);
                this.labMove.Image = bmp;
            }
            else
            {
                //���� ����
                Bitmap bmp = new Bitmap(this.labMove.Width, this.labMove.Height);
                this.labMove.Image = bmp;
                Invalidate();
            }
        }

        
        /// <summary>
        /// �α� �߰�
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
        /// ������ �������� ���� ������ ã��.
        /// https://blog.naver.com/tipsware/221547634772
        /// </summary>
        /// <param name="Parent">ã�� �θ� â�� �ڵ�</param>
        /// <param name="Child">���° �ܰ迡�� ã���� �ѵ�</param>
        /// <param name="lpszClass"></param>
        /// <param name="lpszWindows"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr Parent, IntPtr Child, string lpszClass, string lpszWindows);

        /// <summary>
        /// ������ �ڵ鿡 ��Ŀ���� �ش�.
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
                //�÷��̾ ã���� ��� Ŭ���̺�Ʈ�� �߻���ų �ڵ��� �����ɴϴ�.
                //IntPtr hwnd_child = FindWindowEx(this.m_hWnd, IntPtr.Zero, "RenderWindow", "TheRender");
                IntPtr hwnd_child = FindWindowEx(this.m_hWnd, IntPtr.Zero
                    , "WindowsForms10.Static.app.0.29e8405_r3_ad1", null);
                IntPtr lparamStart = new IntPtr(pointStart.X | (pointStart.Y << 16));
                IntPtr lparamEnd = new IntPtr(pointEnd.X | (pointEnd.Y << 16));

                //��Ŀ�� ����.
                SetForegroundWindow(this.m_hWnd);
                Thread.Sleep(1000);

                //�÷��̾� �ڵ鿡 Ŭ�� �̺�Ʈ�� �����մϴ�.
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