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
        private frmMain m_frmMian;


        /// <summary>
        /// 픽쳐박스 공통화
        /// </summary>
        private PictureAssist m_PA;


        public frmOutFocus(frmMain frmMian)
        {
            InitializeComponent();

            this.m_PA = new PictureAssist(this, this.pictureDraw);
            this.m_PA.OnLog += M_PA_OnLog;

            this.m_frmMian = frmMian;
        }

        private void frmOutFocus_Load(object sender, EventArgs e)
        {
            this.m_PA.ImageClear();

            GlobalStatic.OutFocusWndHandle
                = GlobalStatic.FindWindow(null, "Win32 Drag Test - Out Focus");

            //플레이어를 찾았을 경우 클릭이벤트를 발생시킬 핸들을 가져옵니다.
            GlobalStatic.OutFocusWndHandle_Child
                = GlobalStatic.FindWindowEx(
                    GlobalStatic.OutFocusWndHandle, IntPtr.Zero
                    , "WindowsForms10.Window.8.app.0.29e8405_r3_ad1", null);

        }



        #region 로그
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
	}
}
