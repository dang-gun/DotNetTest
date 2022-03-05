using System.Text;

namespace WinApiOutFocusTest
{
    public partial class frmMian : Form
    {
        /// <summary>
        /// ���콺 �̺�Ʈ ������ ����<br />
        /// Whether to receive mouse events
        /// </summary>
        public bool MouseEventEnable = true;
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

        
    }


}