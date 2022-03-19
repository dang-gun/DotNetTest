using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApiOutFocusTest
{
    internal class PictureAssist
    {
        /// <summary>
        /// 사용할 픽쳐박스
        /// </summary>
        private PictureBox m_pbThis { get; set; }

        /// <summary>
        /// 마우스 이벤트 받을지 여부<br />
        /// Whether to receive mouse events
        /// </summary>
        public bool MouseEventEnable = true;

        public PictureAssist(PictureBox pictureBox)
        {
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
            if (true == MouseEventEnable)
            {
                this.MouseDownKey = e.Button;
                this.labMouseKeyShow.Text = this.MouseDownKey.ToString();

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

        private void label1_MouseMove(object? sender, MouseEventArgs e)
        {
            if (true == MouseEventEnable)
            {
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

        private void label1_MouseUp(object? sender, MouseEventArgs e)
        {
            if (true == MouseEventEnable)
            {
                this.MouseDownKey = MouseButtons.None;
                this.labMouseKeyShow.Text = this.MouseDownKey.ToString();

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
        #endregion



    }
}
