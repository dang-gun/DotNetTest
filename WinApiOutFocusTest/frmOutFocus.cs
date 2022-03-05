using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApiOutFocusTest
{
    public partial class frmOutFocus : Form
    {
        /// <summary>
        /// 전달받은 메인폼<br />
        /// passed window
        /// </summary>
        private frmMian m_frmMian;

        public frmOutFocus(frmMian frmMian)
        {
            InitializeComponent();

            this.m_frmMian = frmMian;
        }

        private void frmOutFocus_Load(object sender, EventArgs e)
        {

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

        
    }
}
