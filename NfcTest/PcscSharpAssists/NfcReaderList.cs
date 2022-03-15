using PCSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcscSharpAssists
{
	/// <summary>
	/// 연결된 모든 디바이스의 정보 처리를 지원한다.
	/// </summary>
	public static class NfcListInfo
	{
		/// <summary>
		/// NFC 리더기의 리스트를 불러온다.
		/// </summary>
		/// <returns></returns>
		public static string[] ReaderList()
		{
			string[] listReaderName;

			using (ISCardContext Context1
						= ContextFactory.Instance.Establish(SCardScope.System))
			{
				listReaderName = Context1.GetReaders();
			}//end using context

			return listReaderName.ToArray();
		}
	}
}
