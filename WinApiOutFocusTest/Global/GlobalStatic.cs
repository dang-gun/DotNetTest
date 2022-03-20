using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApiOutFocusTest.Global
{
	public static class GlobalStatic
	{
        #region Win32 Find
        /// <summary>
        /// 전체윈도우를 검색한다.
        /// http://blog.naver.com/PostView.nhn?blogId=tipsware&logNo=221005783620
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("User32", EntryPoint = "FindWindow")]
		public static extern IntPtr FindWindow(string? lpClassName, string lpWindowName);

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
		public static extern IntPtr FindWindowEx(IntPtr Parent, IntPtr Child, string? lpszClass, string? lpszWindows);
        #endregion

        /// <summary>
        /// 사용할 랜덤 함수
        /// </summary>
        public static Random rand = new Random();

		/// <summary>
		/// 랜덤한 색으로 팬을 만들어 리턴한다.
		/// </summary>
		/// <returns></returns>
		public static Pen ColorGet()
		{
			//칼라를 랜덤하게 추출한다.
			Byte[] b = new Byte[3];
			GlobalStatic.rand.NextBytes(b);
			return new Pen(Color.FromArgb(255, (int)b[0], (int)b[1], (int)b[2]), 2);
		}

		/// <summary>
		/// Main Window Handle
		/// </summary>
		public static IntPtr MainWndHandle = IntPtr.Zero;
		/// <summary>
		/// Main Window Target Child Handle
		/// </summary>
		public static IntPtr MainWndHandle_Child = IntPtr.Zero;

		/// <summary>
		/// Out Focus Window Handle
		/// </summary>
		public static IntPtr OutFocusWndHandle = IntPtr.Zero;
		/// <summary>
		/// Out Focus Window Target Child Handle
		/// </summary>
		public static IntPtr OutFocusWndHandle_Child = IntPtr.Zero;
	}
}
