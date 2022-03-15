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
		/// </summary>
		public byte[] DataBlocks { get; set; }
				= new byte[] { 
					0x00, 0x01, 0x02,//sector 0
					0x04, 0x05, 0x06,//sector 1
					0x08, 0x09, 0x0A,//sector 3
					0x0C, 0x0D, 0x0E,//sector 4
					0x10, 0x11, 0x12,//sector 5

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
					0x0B,//sector 3
					0x0F,//sector 4
					0x13,//sector 5

					0x3B,//sector 14
					0x3F,//sector 15
				};

		/// <summary>
		/// 블록하나가 가지고 있는 바이트(byte) 개수
		/// </summary>
		public int BlockSize { get; set; } = 16;

	}
}
