using NfcTest.CardInfo;
using NfcTest.DeviceInfo;
using NfcTest.PcscSharpAssists;
using PCSC;
using PCSC.Exceptions;
using PCSC.Iso7816;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NfcTest
{
	public class NfcReaderTest : IDisposable
	{
		/// <summary>
		/// 사용할 디바이스의 정보
		/// </summary>
		public DeviceInfoInterface DeviceInfo { get; private set; }

		/// <summary>
		/// 작성에 사용 할 카드의 정보
		/// </summary>
		public CardInfoInterface CardInfo { get; private set; }

		/// <summary>
		/// 선택된 이름
		/// </summary>
		public string ReaderName { get; private set; } = string.Empty;

		/// <summary>
		/// 카드 리더기를 초기화 한다.
		/// </summary>
		/// <param name="deviceInfoInterface">초기화에 사용할 디바이스 정보</param>
		/// <param name="cardInfoInterface">초기화에 사용할 카드 정보</param>
		public NfcReaderTest(
				DeviceInfoInterface deviceInfoInterface
				, CardInfoInterface cardInfoInterface)
		{
			this.DeviceInfo = deviceInfoInterface;
			this.CardInfo = cardInfoInterface;
		}

		/// <summary>
		/// 파괴자
		/// </summary>
		public void Dispose()
		{
			
		}

		/// <summary>
		/// 사용할 리더기의 이름을 저장한다.
		/// </summary>
		/// <param name="sReaderName"></param>
		public void ReaderNameSet(string sReaderName)
		{
			this.ReaderName = sReaderName;
		}

		/// <summary>
		/// 미리 설정된 IsoReader개체를 만들어 리턴한다.
		/// </summary>
		/// <returns></returns>
		private IsoReader IsoReaderThis(ISCardContext scardContext)
		{
			return new IsoReader(context: scardContext
									, readerName: this.ReaderName
									, mode: SCardShareMode.Shared
									, protocol: SCardProtocol.Any
									, releaseContextOnDispose: false);
		}

		/// <summary>
		/// 카드가 들어있는지 여부.
		/// 강제로 오류를 일으켜 카드를 확인한다.
		/// </summary>
		/// <returns></returns>
		public bool CardIn()
		{
			bool bReturn = true;

			if (string.Empty == this.ReaderName)
			{
				bReturn = false;
			}
			else
			{
				try
				{
					using (ISCardContext Context1
							= ContextFactory.Instance.Establish(SCardScope.System))
					{
						using (IsoReader isoReader = this.IsoReaderThis(Context1))
						{
						}
					}
						
				}
				catch (PCSCException exPcsc)
				{
					bReturn = false;
					Debug.WriteLine(exPcsc.Message);
				}
			}

			return bReturn;
		}


		#region 상태 정보 확인
		/// <summary>
		/// NFC 리더기의 리스트를 불러온다.
		/// </summary>
		/// <returns></returns>
		public string[] ReaderList()
		{
			string[] listReaderName;

			using (ISCardContext Context1
						= ContextFactory.Instance.Establish(SCardScope.System))
			{
				listReaderName = Context1.GetReaders();
			}//end using context

			return listReaderName.ToArray();
		}


		/// <summary>
		/// 카드의 속성을 가지고 온다.
		/// </summary>
		/// <param name="typeCardAttribute">가지고올 속성 타입</param>
		/// <returns></returns>
		public byte[]? CardAttributeGet(SCardAttribute typeCardAttribute)
		{
			byte[]? byteReturn = null;

			using (ISCardContext Context1 
						= ContextFactory.Instance.Establish(SCardScope.System))
			{
				using (var reader = Context1.ConnectReader(
										this.ReaderName
										, SCardShareMode.Shared
										, SCardProtocol.Any))
				{
					var cardAtr = reader.GetAttrib(typeCardAttribute);
					byteReturn = cardAtr;
				}
			}

			return byteReturn;
		}
		#endregion

		

		/// <summary>
		/// 인증키 요청
		/// </summary>
		/// <param name="byteLoadKeyData">불러온 인증키 데이터</param>
		/// <returns></returns>
		public bool LoadKey(out byte[] byteLoadKeyData)
		{
			bool bReturn = false;

			using (ISCardContext context = ContextFactory.Instance.Establish(SCardScope.System))
			{
				using (IsoReader isoReader = this.IsoReaderThis(context))
				{
					CommandApdu cmdloadKey = this.DeviceInfo.Apdu_LoadKey;

					byteLoadKeyData = cmdloadKey.ToArray();
					Response response = isoReader.Transmit(cmdloadKey);
					//성공여부
					bReturn = PcscSharpAssist.IsSuccess(response);
				}//end using isoReader
			}//end using context

			return bReturn;
		}

		/// <summary>
		/// 블록인증을 받는다.
		/// </summary>
		/// <param name="byteBlock">사용할 블록 번호</param>
		/// <returns></returns>
		public bool AuthBlock(byte byteBlock)
		{
			bool bReturn = false;

			//들어온 블록번호가 사용가능한 번호인지 확인한다.
			bool bUseBlock = false;
			foreach (byte itemBlock in this.CardInfo.DataBlocks)
			{
				if (itemBlock == byteBlock)
				{
					bUseBlock = true;
				}
			}

			if (true == bUseBlock)
			{//사용 가능한 블럭이다

				//진행
				GeneralAuthenticate tempGA = this.DeviceInfo.GeneralAuthBlock;
				tempGA.Lsb = byteBlock;
				CommandApdu cmdAuthBlock = this.DeviceInfo.Apdu_AuthBlock;
				cmdAuthBlock.Data = tempGA.ToArray();

				using (ISCardContext context
					= ContextFactory.Instance.Establish(SCardScope.System))
				{
					using (IsoReader isoReader = this.IsoReaderThis(context))
					{
						Response response = isoReader.Transmit(cmdAuthBlock);
						//성공여부
						bReturn = PcscSharpAssist.IsSuccess(response);
					}//end using isoReader
				}//end using context
			}
			

			return bReturn;
		}

		/// <summary>
		/// 지정된 블록의 데이터를 읽는다.
		/// </summary>
		/// <param name="byteBlock">읽을 블록 번호</param>
		/// <param name="byteBinaryBlocksData">읽어들인 데이터</param>
		/// <returns></returns>
		public bool ReadBinaryBlocks(
			byte byteBlock
			, out byte[] byteBinaryBlocksData)
		{
			bool bReturn = false;

			//들어온 블록번호가 사용가능한 번호인지 확인한다.
			bool bUseBlock = false;
			foreach (byte itemBlock in this.CardInfo.DataBlocks)
			{
				if (itemBlock == byteBlock)
				{
					bUseBlock = true;
				}
			}

			if (true == bUseBlock)
			{//사용 가능한 블럭이다

				//진행
				CommandApdu cmdReadBinaryBlocksCmd = this.DeviceInfo.Apdu_ReadBinaryBlocks;
				cmdReadBinaryBlocksCmd.P2 = byteBlock;
				cmdReadBinaryBlocksCmd.Le = this.CardInfo.BlockSize;

				
				using (ISCardContext context
						= ContextFactory.Instance.Establish(SCardScope.System))
				{
					using (IsoReader isoReader = this.IsoReaderThis(context))
					{
						Response response = isoReader.Transmit(cmdReadBinaryBlocksCmd);
						//성공여부
						bReturn = PcscSharpAssist.IsSuccess(response);

						byteBinaryBlocksData = response.GetData();
					}//end using isoReader
				}//end using context
				
				
			}
			else
			{
				byteBinaryBlocksData = new byte[] { };
			}


			return bReturn;
		}


		/// <summary>
		/// 지정된 블록에 데이터를 쓴다.
		/// </summary>
		/// <param name="byteBlock">읽을 블록 번호</param>
		/// <param name="byteBinaryBlocksData">쓸 데이터 데이터</param>
		/// <returns></returns>
		public bool UpdateBinaryBlocks(
			byte byteBlock
			, byte[] byteBinaryBlocksData)
		{
			bool bReturn = false;

			//들어온 블록번호가 사용가능한 번호인지 확인한다.
			bool bUseBlock = false;
			foreach (byte itemBlock in this.CardInfo.DataBlocks)
			{
				if (itemBlock == byteBlock)
				{
					bUseBlock = true;
				}
			}

			if (true == bUseBlock)
			{//사용 가능한 블럭이다

				//진행
				CommandApdu cmdReadBinaryBlocksCmd = this.DeviceInfo.Apdu_UpdateBinaryBlocks;
				cmdReadBinaryBlocksCmd.P2 = byteBlock;
				cmdReadBinaryBlocksCmd.Data 
					= byteBinaryBlocksData;


				using (ISCardContext context
						= ContextFactory.Instance.Establish(SCardScope.System))
				{
					using (IsoReader isoReader = this.IsoReaderThis(context))
					{
						Response response = isoReader.Transmit(cmdReadBinaryBlocksCmd);
						//성공여부
						bReturn = PcscSharpAssist.IsSuccess(response);

						byteBinaryBlocksData = response.GetData();
					}//end using isoReader
				}//end using context


			}
			
			return bReturn;
		}


		private const byte MSB = 0x00;
		private const byte LSB = 0x08;

		/// <summary>
		/// 특정기능(읽기, 쓰기 등등)을 위해 권한을 요청을 한다.
		/// </summary>
		/// <returns></returns>
		public bool Block_Auth()
		{
			using (var context = ContextFactory.Instance.Establish(SCardScope.System))
			{
				using (var isoReader
						= new IsoReader(context: context
										, readerName: this.ReaderName
										, mode: SCardShareMode.Shared
										, protocol: SCardProtocol.Any
										, releaseContextOnDispose: false))
				{
					var card = new MifareCard(isoReader);



					var authSuccessful
						= card.Authenticate(
							MSB
							, LSB
							, KeyType.KeyA
							, 0x00);
					if (false == authSuccessful)
					{
						//this.LogAdd(string.Format("- Error - AUTHENTICATE failed."));
					}
					else
					{//인증 성공
						//this.labInfo.Text = "Authentication : success";
						//this.labInfo.BackColor = Color.FromArgb(255, 80, 240, 180);
						//this.LogAdd(string.Format("AUTHENTICATE success."));
					}


				}
			}
			
			return true;
		}

		
	}
}
