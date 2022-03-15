using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NfcCardInfo;
using NfcDeviceCommandAssists;
using PCSC;
using PCSC.Exceptions;
using PCSC.Iso7816;

namespace NfcReaderAssists
{
	public class NfcReaderAssistsBase : IDisposable
	{
		/// <summary>
		/// 사용할 디바이스의 정보
		/// </summary>
		public DeviceCommandInterface DeviceInfo { get; protected set; }

		/// <summary>
		/// 작성에 사용 할 카드의 정보
		/// </summary>
		public CardInfoInterface CardInfo { get; protected set; }

		/// <summary>
		/// 선택된 이름
		/// </summary>
		public string ReaderName { get; protected set; } = string.Empty;

		/// <summary>
		/// 카드 리더기를 초기화 한다.
		/// </summary>
		/// <param name="deviceInfoInterface">초기화에 사용할 디바이스 정보</param>
		/// <param name="cardInfoInterface">초기화에 사용할 카드 정보</param>
		public NfcReaderAssistsBase(
				DeviceCommandInterface deviceInfoInterface
				, CardInfoInterface cardInfoInterface)
		{
			this.DeviceInfo = deviceInfoInterface;
			this.CardInfo = cardInfoInterface;
		}

		/// <summary>
		/// 파괴자
		/// </summary>
		public virtual void Dispose()
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
		/// 카드가 들어있는지 여부.<br />
		/// 강제로 오류를 일으켜 카드를 확인한다.
		/// <para>오류 정보없이 성공여부만 준다.</para>
		/// </summary>
		/// <returns></returns>
		public bool CardIn()
		{
			SCardError tempSCardError = new SCardError();
			return this.CardIn(out tempSCardError);
		}

		/// <summary>
		/// 카드가 들어있는지 여부.<br />
		/// 강제로 오류를 일으켜 카드를 확인한다.
		/// </summary>
		/// <param name="scardError">전달받을 SCardError정보</param>
		/// <returns></returns>
		public bool CardIn(out SCardError scardError)
		{
			bool bReturn = true;

			if (string.Empty == this.ReaderName)
			{
				bReturn = false;
				scardError = SCardError.UnknownReader;
				Debug.WriteLine("'ReaderName' is empty");
			}
			else
			{
				try
				{
					//컨택스트 개체를 만들고 카드에 접근해본다.
					using (ISCardContext Context1
							= ContextFactory.Instance.Establish(SCardScope.System))
					{
						using (IsoReader isoReader = this.IsoReaderThis(Context1))
						{
						}
					}

					//에러가 없다면 이곳에 도착한다.
					scardError = SCardError.Success;
				}
				catch (PCSCException exPcsc)
				{
					bReturn = false;
					scardError = exPcsc.SCardError;
					Debug.WriteLine(exPcsc.Message);
				}
			}

			return bReturn;
		}

		/// <summary>
		/// 미리 설정된 IsoReader개체를 만들어 리턴한다.
		/// </summary>
		/// <returns></returns>
		protected IsoReader IsoReaderThis(ISCardContext scardContext)
		{
			return new IsoReader(context: scardContext
									, readerName: this.ReaderName
									, mode: SCardShareMode.Shared
									, protocol: SCardProtocol.Any
									, releaseContextOnDispose: false);
		}

		/// <summary>
		/// 전달받은 APDU 명령을 가지고 있는 리더기에게 전달하여 결과를 받는다.
		/// </summary>
		/// <param name="cmdApdu"></param>
		/// <returns></returns>
		protected Response TransmitThis(CommandApdu cmdApdu)
		{
			Response response;

			using (ISCardContext context
					= ContextFactory.Instance.Establish(SCardScope.System))
			{
				using (IsoReader isoReader = this.IsoReaderThis(context))
				{
					response = isoReader.Transmit(cmdApdu);
				}
			}

			return response;
		}//end TransmitThis

		/// <summary>
		/// 들어온 블록번호가 사용가능한 번호인지 확인한다.
		/// </summary>
		/// <param name="byteBlock">확인할 블록 번호</param>
		/// <returns>사용 가능여부</returns>
		public bool BlockUseCheck(byte byteBlock)
		{
			bool bUseBlock = false;
			foreach (byte itemBlock in this.CardInfo.DataBlocks)
			{
				if (itemBlock == byteBlock)
				{
					bUseBlock = true;
				}
			}

			return bUseBlock;
		}
	}
}
