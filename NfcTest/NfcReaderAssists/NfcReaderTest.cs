using NfcCardInfo;
using NfcDeviceCommandAssists;
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
	/// 'DeviceInfo'에 저장된 내용만 가지고 최소한의 작업을 하는 클래스.<br />
	/// 장비와 카드가 동작하는지 확인하는 용도로 사용된다.
	/// </summary>
	public class NfcReaderTest : NfcReaderAssistsBase, IDisposable
	{
		/// <summary>
		/// 카드 리더기를 초기화 한다.
		/// </summary>
		/// <param name="deviceInfoInterface">초기화에 사용할 디바이스 정보</param>
		/// <param name="cardInfoInterface">초기화에 사용할 카드 정보</param>
		public NfcReaderTest(
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

		/// <summary>
		/// 인증키 요청
		/// </summary>
		/// <param name="byteLoadKeyData">불러온 인증키 데이터</param>
		/// <returns></returns>
		public bool LoadKey(out byte[] byteLoadKeyData)
		{
			bool bReturn = false;

			CommandApdu cmdloadKey = this.DeviceInfo.Apdu_LoadKey;

			byteLoadKeyData = cmdloadKey.ToArray();
			Response response = base.TransmitThis(cmdloadKey);
			//성공여부
			bReturn = PcscSharpAssist.IsSuccess(response);

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
			bool bUseBlock = base.BlockUseCheck(byteBlock);

			if (true == bUseBlock)
			{//사용 가능한 블럭이다

				//진행
				GeneralAuthenticate tempGA = this.DeviceInfo.GeneralAuthBlock;
				tempGA.Lsb = byteBlock;
				CommandApdu cmdAuthBlock = this.DeviceInfo.Apdu_AuthBlock;
				cmdAuthBlock.Data = tempGA.ToArray();

				Response response = base.TransmitThis(cmdAuthBlock);
				bReturn = PcscSharpAssist.IsSuccess(response);
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
			bool bUseBlock = base.BlockUseCheck(byteBlock);

			if (true == bUseBlock)
			{//사용 가능한 블럭이다

				//진행
				CommandApdu cmdReadBinaryBlocksCmd = this.DeviceInfo.Apdu_ReadBinaryBlocks;
				cmdReadBinaryBlocksCmd.P2 = byteBlock;
				cmdReadBinaryBlocksCmd.Le = this.CardInfo.BlockSize;


				Response response = base.TransmitThis(cmdReadBinaryBlocksCmd);
				//성공여부
				bReturn = PcscSharpAssist.IsSuccess(response);
				byteBinaryBlocksData = response.GetData();
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
			bool bUseBlock = base.BlockUseCheck(byteBlock);

			if (true == bUseBlock)
			{//사용 가능한 블럭이다

				//진행
				CommandApdu cmdReadBinaryBlocksCmd = this.DeviceInfo.Apdu_UpdateBinaryBlocks;
				cmdReadBinaryBlocksCmd.P2 = byteBlock;
				cmdReadBinaryBlocksCmd.Data 
					= byteBinaryBlocksData;


				Response response = base.TransmitThis(cmdReadBinaryBlocksCmd);
				//성공여부
				bReturn = PcscSharpAssist.IsSuccess(response);
			}
			
			return bReturn;
		}

		
		
	}
}
