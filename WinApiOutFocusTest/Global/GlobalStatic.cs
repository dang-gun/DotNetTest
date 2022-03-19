using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApiOutFocusTest.Global
{
	public static class GlobalStatic
	{
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
	}
}
