using PCSC.Iso7816;
using PcscSharpAssists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NfcDeviceCommandAssists
{
	/// <summary>
	/// 코드와 해당 디바이스를 가지고 마지막으로 성공했던 정보를 기록하기위한 인터페이스.
	/// </summary>
	public interface DeviceCommandInterface
	{
		/// <summary>
		/// 외부로 노출시킬 제목
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Key Structure
		/// </summary>
		public KeyStructure KeyStructure { get; set; }

		/// <summary>
		/// APDU 명령 - LoadKey
		/// <para>인증키를 불러온다.</para>
		/// </summary>
		public CommandApdu Apdu_LoadKey { get; set; }

		/// <summary>
		/// APDU 명령 - Authentication Block
		/// <para>사용할 블록을 인증한다.</para>
		/// </summary>
		public CommandApdu Apdu_AuthBlock { get; set; }

		/// <summary>
		/// APDU 블록 인증에 사용될 정보
		/// </summary>
		public GeneralAuthenticate GeneralAuthBlock { get; set; }


		/// <summary>
		/// APDU 명령 - Read Binary Blocks
		/// <para>인증 받은 블록의 내용을 읽는다.</para>
		/// </summary>
		public CommandApdu Apdu_ReadBinaryBlocks { get; set; }

		/// <summary>
		/// APDU 명령 - Update Binary Blocks
		/// <para>인증 받은 블록의 내용을 읽는다.</para>
		/// </summary>
		public CommandApdu Apdu_UpdateBinaryBlocks { get; set; }
	}
}
