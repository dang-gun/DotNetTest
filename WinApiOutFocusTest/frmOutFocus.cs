using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApiOutFocusTest.Global;

namespace WinApiOutFocusTest
{
    public partial class frmOutFocus : Form
    {
        /// <summary>
        /// 전달받은 메인폼<br />
        /// passed window
        /// </summary>
        private frmMian m_frmMian;

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


        public frmOutFocus(frmMian frmMian)
        {
            InitializeComponent();

            this.m_frmMian = frmMian;
        }

        private void frmOutFocus_Load(object sender, EventArgs e)
        {
            this.ImageClear();
        }

        /// <summary>
        /// 눌릴 마우스 키<br />
        /// mouse key to be pressed
        /// </summary>
        private MouseButtons MouseDownKey = MouseButtons.None;


        private void labMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (true == this.m_frmMian.MouseEventEnable)
            {
                this.MouseDownKey = e.Button;
                this.m_pointLast = e.Location;
                this.m_bMouseDown = true;
                //클릭할때 색변경
                this.m_pen = GlobalStatic.ColorGet();

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

        private void labMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (true == this.m_frmMian.MouseEventEnable)
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

        private void labMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (true == this.m_frmMian.MouseEventEnable)
            {
                this.MouseDownKey = MouseButtons.None;
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
