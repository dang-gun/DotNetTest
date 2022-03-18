
using System.Text;
using WinApiOutFocusTest.Global;

namespace WinApiOutFocusTest
{
    public partial class frmMian : Form
    {
        /// <summary>
        /// 마우스 이벤트 받을지 여부<br />
        /// Whether to receive mouse events
        /// </summary>
        public bool MouseEventEnable = true;

        /// <summary>
        /// 마우스 다운 여부
        /// </summary>
        public bool m_bMouseDown = false;
        /// <summary>
        /// 마지막 포인트
        /// </summary>
        private Point m_pointLast = Point.Empty;
        /// <summary>
        /// 그리기에 사용될 팬 개체
        /// </summary>
        private Pen m_pen = Pens.Black;

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
        /// 눌릴 마우스 키<br />
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
                //클릭할때 색변경
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

                        //새로고침
                        labMove.Invalidate();

                        //마지막 위치 저장
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
        /// 드레그 영역 초기화
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
                //새로 생성
                Bitmap bmp = new Bitmap(this.labMove.Width, this.labMove.Height);
                this.labMove.Image = bmp;
                Invalidate();
            }
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

		private void btnImageClear_Click(object sender, EventArgs e)
		{
            this.ImageClear();
        }
	}


}