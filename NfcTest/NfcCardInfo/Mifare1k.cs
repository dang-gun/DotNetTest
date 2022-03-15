using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NfcCardInfo
{
	/// <summary>
	/// Mifare1k 카드의 
	/// https://www.acs.com.hk/en/products/3/acr122u-usb-nfc-reader/
	/// </summary>
	internal class Mifare1k : CardInfoInterface
	{
		/// <summary>
		/// 외부로 노출시킬 제목
		/// </summary>
		public string Title { get; set; } = "Mifare1k";

		/// <summary>
		/// 데이터로 사용가능한 블럭 주소
		/// <para>꼭 주소 순서대로 넣어야 한다.<br />
		/// 그래야 특정번호를 기준으로 데이터를 읽고/쓰고 하는
		/// 상대주소 처리가 가능하다.</para>
		/// </summary>
		public byte[] DataBlocks { get; set; }
				= new byte[] { 
					0x00, 0x01, 0x02,//sector 0
					0x04, 0x05, 0x06,//sector 1
					0x08, 0x09, 0x0A,//sector 2
					0x0C, 0x0D, 0x0E,//sector 3
					0x10, 0x11, 0x12,//sector 4
					0x14, 0x15, 0x16,//sector 5
					0x18, 0x19, 0x1A,//sector 6
					0x1C, 0x1D, 0x1E,//sector 7

					0x38, 0x39, 0x3A,//sector 14
					0x3C, 0x3D, 0x3E,//sector 15
				};

		/// <summary>
		/// 꼬리 블럭으로 사용되서 사용할수 없는 블럭 주소
		/// </summary>
		public byte[] TrailerBlocks { get; set; }
				= new byte[] {
					0x03,//sector 0
					0x07,//sector 1
					0x0B,//sector 2
					0x0F,//sector 3
					0x13,//sector 4
					0x17,//sector 5
					0x1B,//sector 6
					0x1F,//sector 7

					0x3B,//sector 14
					0x3F,//sector 15
				};

		/// <summary>
		/// 블록하나가 가지고 있는 바이트(byte) 개수
		/// </summary>
		public int BlockSize { get; set; } = 16;

	}
}
