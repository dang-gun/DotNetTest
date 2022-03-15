using PCSC;
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
	/// ARC122U Series
	/// </summary>
	internal class ARC122U_Series : DeviceCommandInterface
	{
		/// <summary>
		/// 외부로 노출시킬 제목
		/// </summary>
		public string Title { get; set; } = "ARC122U Series";

		/// <summary>
		/// ARC122U시리즈는 Volatile Memory(0x00)만 사용가능한다.
		/// </summary>
		public KeyStructure KeyStructure { get; set; } = KeyStructure.VolatileMemory;

		/// <summary>
		/// APDU 명령 - LoadKey
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

		public ARC122U_Series()
		{


			//키 불러오기 *************
			this.Apdu_LoadKey 
				= new CommandApdu(IsoCase.Case3Short, SCardProtocol.Any)
			{
				CLA = 0xFF,
				Instruction = InstructionCode.ExternalAuthenticate,
				P1 = (byte)KeyStructure,
				P2 = 0x00, // first key slot
				Data = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } // key
			};


			//블록 인증 *************
			this.GeneralAuthBlock = new GeneralAuthenticate
			{
				Msb = 0x00,
				//블록 위치
				Lsb = 0x08,
				KeyNumber = 0x00,
				KeyType = KeyType.KeyA
			};

			this.Apdu_AuthBlock 
				= new CommandApdu(IsoCase.Case3Short, SCardProtocol.Any)
			{
				CLA = 0xFF,
				Instruction = InstructionCode.InternalAuthenticate,
				P1 = 0x00,
				P2 = 0x00,
				Data = GeneralAuthBlock.ToArray(),
			};



			//블록의 데이터를 읽는다. *************
			this.Apdu_ReadBinaryBlocks 
				= new CommandApdu(IsoCase.Case2Short, SCardProtocol.Any)
			{
				CLA = 0xFF,
				Instruction = InstructionCode.ReadBinary,
				P1 = 0x00,
				//블록 위치
				P2 = 0x08,
				//블록 사이즈
				Le = 16,
			};



			//블록의 데이터를 쓴다. *************
			this.Apdu_UpdateBinaryBlocks
				= new CommandApdu(IsoCase.Case3Short, SCardProtocol.Any)
				{
					CLA = 0xFF,
					Instruction = InstructionCode.UpdateBinary,
					P1 = 0x00,
					//블록 위치
					P2 = 0x08,
					//기록할 데이터
					Data = new byte[] { 0x0F, 0x0E, 0x0D, 0x0C, 0x0B, 0x0A, 0x09, 0x08, 0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00 }
				};

		}
	}
}
