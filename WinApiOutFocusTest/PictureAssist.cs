using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinApiOutFocusTest.Global;

namespace WinApiOutFocusTest
{
    internal class PictureAssist
    {
        #region 외부로 노출할 이벤트
        /// <summary>
        /// 로그 전달
        /// </summary>
        /// <param name="sLog"></param>
        /// <param name="e"></param>
        public delegate void LogDelegate(string sLog, MouseEventArgs e);
        /// <summary>
        /// 로그가 전달 이벤트
        /// </summary>
        public event LogDelegate? OnLog;
        /// <summary>
        /// 로그를 외부에 알림
        /// </summary>
        private void OnLogCall(string sLog, MouseEventArgs e)
        {
            if (null != OnLog)
            {
                this.OnLog(sLog, e);
            }
        }

        /// <summary>
        /// 마우스 이벤트 전달용
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="nWM"></param>
        public delegate void MouseDelegate(
            object? sender
            , MouseEventArgs e
            , int nWM );


        /// <summary>
        /// 마우스 다운 이벤트
        /// </summary>
        public event MouseDelegate? OnMouseDownEvent;
        /// <summary>
        /// 로그를 외부에 알림
        /// </summary>
        private void OnMouseDownEventCall(
            object? sender
            , MouseEventArgs e)
        {
            if (null != OnMouseDownEvent)
            {
                this.OnMouseDownEvent(sender, e, GlobalStatic.WM_LBUTTONDOWN);
            }
        }

        /// <summary>
        /// 마우스 무브 이벤트
        /// </summary>
        public event MouseDelegate? OnMouseMoveEvent;
        /// <summary>
        /// 로그를 외부에 알림
        /// </summary>
        private void OnMouseMoveEventCall(
            object? sender
            , MouseEventArgs e)
        {
            if (null != OnMouseMoveEvent)
            {
                this.OnMouseMoveEvent(sender, e, GlobalStatic.WM_MOUSEMOVE);
            }
        }

        /// <summary>
        /// 마우스 업 이벤트
        /// </summary>
        public event MouseDelegate? OnMouseUpEvent;
        /// <summary>
        /// 로그를 외부에 알림
        /// </summary>
        private void OnMouseUpEventCall(
            object? sender
            , MouseEventArgs e)
        {
            if (null != OnMouseUpEvent)
            {
                this.OnMouseUpEvent(sender, e, GlobalStatic.WM_RBUTTONUP);
            }
        }
        #endregion

        private Form m_frmParent;

        /// <summary>
        /// 사용할 픽쳐박스
        /// </summary>
        private PictureBox m_pbThis { get; set; }

        /// <summary>
        /// 마우스 이벤트 받을지 여부<br />
        /// Whether to receive mouse events
        /// </summary>
        public bool MouseEventEnable { get; set; } = true;

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


        public PictureAssist(Form formParent, PictureBox pictureBox)
        {
            this.m_frmParent = formParent;
            this.m_pbThis = pictureBox;

            this.m_pbThis.MouseDown -= label1_MouseDown;
            this.m_pbThis.MouseDown += label1_MouseDown;
            this.m_pbThis.MouseMove -= label1_MouseMove;
            this.m_pbThis.MouseMove += label1_MouseMove;
            this.m_pbThis.MouseUp -= label1_MouseUp;
            this.m_pbThis.MouseUp += label1_MouseUp;
        }

        #region 마우스 이벤트
        /// <summary>
        /// 눌릴 마우스 키<br />
        /// mouse key to be pressed
        /// </summary>
        private MouseButtons MouseDownKey = MouseButtons.None;

        private void label1_MouseDown(object? sender, MouseEventArgs e)
        {
            Debug.WriteLine("{2} - Mouse down : {0}, {1}", e.X, e.Y, this.m_frmParent.Text);

            if (true == MouseEventEnable)
            {
                this.MouseDownKey = e.Button;
                this.m_pointLast = e.Location;
                this.m_bMouseDown = true;

                //클릭할때 색변경
                this.m_pen = GlobalStatic.ColorGet();

                //시작 점 찍기
                using (Graphics g = Graphics.FromImage(this.m_pbThis.Image))
                {
                    g.FillRectangle(this.m_pen.Brush
                        , this.m_pointLast.X - 3, this.m_pointLast.Y - 3
                        , 6, 6);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                }

                //새로고침
                this.m_pbThis.Invalidate();





                StringBuilder sbLog = new StringBuilder();
                sbLog.Append("MouseDown Key : ");
                sbLog.Append(e.Button.ToString());
                sbLog.Append("(");
                sbLog.Append(e.X);
                sbLog.Append(",");
                sbLog.Append(e.Y);
                sbLog.Append(")");
                this.OnLogCall(sbLog.ToString(), e);
            }

            this.OnMouseDownEventCall(sender, e);
        }

        private void label1_MouseMove(object? sender, MouseEventArgs e)
        {
            Debug.WriteLine("{4} - Mouse Move({0}, {1}) : {2}, {3}"
                            , e.Button, this.MouseDownKey
                            , e.X, e.Y
                            , this.m_frmParent.Text);

            if (true == MouseEventEnable)
            {
                if (true == this.m_bMouseDown)
                {
                    if (Point.Empty != m_pointLast)
                    {
                        using (Graphics g = Graphics.FromImage(this.m_pbThis.Image))
                        {
                            g.DrawLine(this.m_pen, this.m_pointLast, e.Location);
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        }

                        //새로고침
                        this.m_pbThis.Invalidate();

                        //마지막 위치 저장
                        this.m_pointLast = e.Location;
                    }
                }

                this.OnLogCall(
                    String.Format("Mouse Move({0}, {1}) : {2}, {3}"
                                    , e.Button, this.MouseDownKey
                                    , e.X, e.Y)
                    , e);
            }

            this.OnMouseMoveEventCall(sender, e);
        }

        private void label1_MouseUp(object? sender, MouseEventArgs e)
        {
            Debug.WriteLine("{2} - Mouse up : {0}, {1}", e.X, e.Y, this.m_frmParent.Text);

            if (true == MouseEventEnable)
            {
                this.MouseDownKey = MouseButtons.None;
                this.m_pointLast = e.Location;
                m_bMouseDown = false;

                //시작 점 찍기
                using (Graphics g = Graphics.FromImage(this.m_pbThis.Image))
                {
                    g.FillRectangle(this.m_pen.Brush
                        , this.m_pointLast.X - 3, this.m_pointLast.Y - 3
                        , 6, 6);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                }

                //새로고침
                this.m_pbThis.Invalidate();
                m_pointLast = Point.Empty;

                StringBuilder sbLog = new StringBuilder();
                sbLog.Append("MouseUp Key : ");
                sbLog.Append(e.Button.ToString());
                sbLog.Append("(");
                sbLog.Append(e.X);
                sbLog.Append(",");
                sbLog.Append(e.Y);
                sbLog.Append(")");
                this.OnLogCall(sbLog.ToString(), e);
            }

            this.OnMouseUpEventCall(sender, e);
        }
        #endregion

        /// <summary>
        /// 드레그 영역 초기화
        /// </summary>
        public void ImageClear()
        {
            if (this.m_pbThis.Image == null)
            {
                Bitmap bmp = new Bitmap(this.m_pbThis.Width, this.m_pbThis.Height);
                this.m_pbThis.Image = bmp;
            }
            else
            {
                //새로 생성
                Bitmap bmp = new Bitmap(this.m_pbThis.Width, this.m_pbThis.Height);
                this.m_pbThis.Image = bmp;
                m_frmParent.Invalidate();
            }
        }

    }
}
