using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NfcCardInfo
{
	/// <summary>
	/// 사용하는 카드의 문서상 스팩 정보이다.
	/// </summary>
	public interface CardInfoInterface
	{
		/// <summary>
		/// 외부로 노출시킬 제목
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// 데이터로 사용가능한 블럭 주소
		/// </summary>
		public byte[] DataBlocks { get; set; }
		/// <summary>
		/// 꼬리 블럭으로 사용되서 사용할수 없는 블럭 주소
		/// </summary>
		public byte[] TrailerBlocks { get; set; }

		/// <summary>
		/// 블록하나가 가지고 있는 바이트(byte) 개수
		/// </summary>
		public int BlockSize { get; set; }
	}
}
