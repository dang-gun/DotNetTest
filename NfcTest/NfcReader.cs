using NfcTest.CardInfo;
using NfcTest.DeviceInfo;
using NfcTest.PcscSharpAssists;
using PCSC;
using PCSC.Exceptions;
using PCSC.Iso7816;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NfcTest
{
	public class NfcReader : IDisposable
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
		public NfcReader(
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
				try
				{

				}
				catch (PCSCException exPcsc)
				{
					switch (exPcsc.SCardError)
					{
						case SCardError.RemovedCard:
							break;
					}
					
				}
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
		/// 사용할 리더기의 이름을 저장한다.
		/// </summary>
		/// <param name="sReaderName"></param>
		public void ReaderNameSet(string sReaderName)
		{
			this.ReaderName = sReaderName;
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
