using PCSC.Iso7816;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcscSharpAssists
{
	/// <summary>
	/// PcscSharp 지원용 기능들
	/// </summary>
	public static class PcscSharpAssist
	{
		/// <summary>
		/// 리더기로부터 리턴된 코드가 성공 코드인지 확인한다.
		/// </summary>
		/// <param name="response">리더기로부터 전달된 정보</param>
		/// <returns>성공 코드 여부</returns>
		public static bool IsSuccess(Response response) =>
			(response.SW1 == (byte)SW1Code.Normal) &&
			(response.SW2 == 0x00);
	}
}
