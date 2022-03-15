using NfcCardInfo;
using NfcDeviceCommandAssists;
using NfcTest;
using PCSC;
using PCSC.Exceptions;
using PCSC.Iso7816;
using PcscSharpAssists;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NfcReaderAssists
{
	/// <summary>
	/// 간단하게 Nfc Reader를 사용하기 위해 
	/// </summary>
	public class NfcReader : NfcReaderAssistsBase, IDisposable
	{
		/// <summary>
		/// 카드 리더기를 초기화 한다.
		/// </summary>
		/// <param name="deviceInfoInterface">초기화에 사용할 디바이스 정보</param>
		/// <param name="cardInfoInterface">초기화에 사용할 카드 정보</param>
		public NfcReader(
				DeviceCommandInterface deviceInfoInterface
				, CardInfoInterface cardInfoInterface)
			: base(deviceInfoInterface
				  , cardInfoInterface)
		{
		}

		/// <summary>
		/// 파괴자
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
		}

		#region 상태 정보 확인

		/// <summary>
		/// 카드의 상태정보를 받아온다.
		/// </summary>
		/// <returns></returns>
		public byte[]? GetStatus()
		{
			byte[]? byteReturn = null;

			using (ISCardContext Context1
						= ContextFactory.Instance.Establish(SCardScope.System))
			{
				using (ICardReader reader = Context1.ConnectReader(
										this.ReaderName
										, SCardShareMode.Shared
										, SCardProtocol.Any))
				{
					var status = reader.GetStatus();
					Debug.WriteLine("Reader {0} connected with protocol {1} in state {2}",
						status.GetReaderNames().FirstOrDefault(),
						status.Protocol,
						status.State);
				}
			}

			return byteReturn;
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
				using (ICardReader reader = Context1.ConnectReader(
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

		
	}
}
