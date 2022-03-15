using NfcCardInfo;
using NfcDeviceCommandAssists;
using NfcReaderAssists;
using PCSC;
using PCSC.Iso7816;
using PCSC.Monitoring;
using PcscSharpAssists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NfcTest
{
	public partial class Form1 : Form
	{
		
		/// <summary>
		/// 디바이스와 카드정보를 이용하여 생성한 NFC 리더 지원 개체
		/// </summary>
		NfcReader m_nfc;
		/// <summary>
		/// (test)디바이스와 카드정보를 이용하여 생성한 NFC 리더 지원 개체
		/// </summary>
		NfcReaderTest m_nfcTest;

		IMonitorFactory monitorFactory;
		ISCardMonitor monitor;

		public Form1()
		{
			InitializeComponent();

			//장비를 기본값으로 설정한다.**************
			this.m_nfc
				= new NfcReader(
						new ARC122U_Series()
						, new Mifare1k());
			//
			this.m_nfcTest
				= new NfcReaderTest(
						new ARC122U_Series()
						, new Mifare1k());


			//가지고 있는 정보를 UI에 표시한다.
			//디바이스 ◇◇◇◇
			listviewDevice.Items.Add(new ARC122U_Series().Title);
			listviewDevice.Items[0].Selected = true;
			//카드 ◇◇◇◇
			listviewCard.Items.Add(new Mifare1k().Title);
			listviewCard.Items[0].Selected = true;


			//인스턴스 생성
			monitorFactory = MonitorFactory.Instance;
			monitor = monitorFactory.Create(SCardScope.System);
			//이벤트 연결
			monitor.StatusChanged += Monitor_StatusChanged;

			//카드 리스트 새로고침
			btnCardListRefresh_Click(null, null);
		}

		#region 폼 관련
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.m_nfc.Dispose();
			monitor.Cancel();
			monitor.Dispose();
		}

		/// <summary>
		/// 로그 추가
		/// </summary>
		/// <param name="sMessage"></param>
		private void LogAdd(string sMessage)
		{
			if (true == InvokeRequired)
			{//다른 쓰래드다.
				this.Invoke(new Action(
					delegate ()
					{
						this.LogAddNotInvoke(sMessage);
					}));
			}
			else
			{//같은 쓰래드다.
				this.LogAddNotInvoke(sMessage);
			}

		}

		private void LogAddNotInvoke(string sMessage)
		{
			ListViewItem item = new ListViewItem();
			item.Text = DateTime.Now.ToString("HH:mm:ss");
			item.SubItems.Add(sMessage);

			this.listLog.Items.Add(item);
			this.listLog.Items[this.listLog.Items.Count - 1].EnsureVisible();
		}

		
		#endregion

		#region UI관련
		/// <summary>
		/// 디바이스 변경
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listviewDevice_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.NfcInfoChanged();
		}
		/// <summary>
		/// 카드 변경
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listviewCard_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.NfcInfoChanged();
		}
		/// <summary>
		/// UI에 표시된 정보로 디바이스와 카드를 초기화 한다.
		/// </summary>
		private void NfcInfoChanged()
		{
			if (0 < this.listviewDevice.SelectedItems.Count
				&& 0 < this.listviewCard.SelectedItems.Count)
			{
				//디바이스 판단. ****************
				string sDeviceTitle = this.listviewDevice.SelectedItems[0].Text;
				DeviceCommandInterface? selectDeviceCmd = null;

				if (new ARC122U_Series().Title == sDeviceTitle)
				{
					selectDeviceCmd = new ARC122U_Series();
				}

				//카드 판단 *************
				string sCardTitle = this.listviewCard.SelectedItems[0].Text;
				CardInfoInterface? selectCardInfo = null;

				if (new Mifare1k().Title == sCardTitle)
				{
					selectCardInfo = new Mifare1k();
				}

				if (null == selectDeviceCmd)
				{//디바이스 정보 없다.
					this.LogAdd("NFC 리더기를 선택해 주세요.");
				}
				else if (null == selectCardInfo)
				{
					this.LogAdd("카드를 선택해 주세요.");
				}
				else
				{//성공
				 //장비 재설정
					this.m_nfc
					= new NfcReader(
							selectDeviceCmd
							, selectCardInfo);
					this.m_nfcTest
						= new NfcReaderTest(
								selectDeviceCmd
								, selectCardInfo);
				}
			}
		}
		#endregion

		#region Device Test

		/// <summary>
		/// ui의 블록 번호를 바이트로 변환해 리턴한다.
		/// </summary>
		/// <returns></returns>
		public byte BlockNumberGet()
		{
			return BitConverter.GetBytes((short)this.numericBlockNumber.Value)[0];
		}

		private void btnGetStatus_Click(object sender, EventArgs e)
		{
			

			if (true == this.m_nfcTest.CardIn())
			{
				this.m_nfcTest.GetStatus();
			}
			else
			{
				this.LogAdd("카드를 읽을 수 없습니다.");
			}
		}

		/// <summary>
		/// 카드 ATR 정보 받기
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGetArt_Click(object sender, EventArgs e)
		{
			if (true == this.m_nfcTest.CardIn())
			{
				byte[]? byteAtr
				= this.m_nfcTest.CardAttributeGet(SCardAttribute.AtrString);


				if (null != byteAtr)
				{
					string sData = string.Empty;
					sData = BitConverter.ToString(byteAtr);
					this.LogAdd(string.Format("ATR: {0}", sData));
				}
				else
				{
					this.LogAdd(string.Format("ATR: Failure"));
				}
			}
			else
			{
				this.LogAdd("카드를 읽을 수 없습니다.");
			}
		}

		/// <summary>
		/// 키 로드 테스트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoadKey_Click(object sender, EventArgs e)
		{
			if (true == this.m_nfcTest.CardIn())
			{
				byte[] byteLoadKeyData = new byte[] { };
				this.m_nfcTest.LoadKey(out byteLoadKeyData);

				if (true == this.m_nfcTest.LoadKey(out byteLoadKeyData))
				{
					this.LogAdd(BitConverter.ToString(byteLoadKeyData.ToArray()));
				}
				else
				{
					this.LogAdd("키 로드 실패");
				}
			}
			else
			{
				this.LogAdd("카드를 읽을 수 없습니다.");
			}
		}

		/// <summary>
		/// 블록 권한 테스트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAuthBlock_Click(object sender, EventArgs e)
		{
			byte byteBlockNumber = this.BlockNumberGet();

			if (true == this.m_nfcTest.CardIn())
			{
				if (true == this.m_nfcTest.AuthBlock(byteBlockNumber))
				{
					this.LogAdd(String.Format("블록 권한 얻기 성공 : {0:X2}", byteBlockNumber));
					
					this.labInfo.Text = "Authentication : success";
					this.labInfo.BackColor = Color.FromArgb(255, 80, 240, 180);
					this.LogAdd(string.Format("AUTHENTICATE success."));
				}
				else
				{
					this.LogAdd(">>> 블록 권한 얻기 실패");
					this.labInfo.Text = "Authentication : none";
					this.labInfo.BackColor = Color.FromArgb(255, 160, 0, 184);
					this.LogAdd(string.Format("- Error - Read Binary failed. - 인증을 다시 받으면 해결 될 수 있음."));
				}
			}
			else
			{
				this.LogAdd("카드를 읽을 수 없습니다.");
			}
		}

		/// <summary>
		/// 블록 읽기 테스트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReadBinaryBlocks_Click(object sender, EventArgs e)
		{
			byte byteBlockNumber = this.BlockNumberGet();

			if (true == this.m_nfcTest.CardIn())
			{
				byte[] byteLoadKeyData = new byte[] { };

				if (true == this.m_nfcTest.ReadBinaryBlocks(byteBlockNumber, out byteLoadKeyData))
				{
					this.LogAdd(String.Format("--- 블록 읽기({0:X2}) ---", byteBlockNumber));
					this.LogAdd(BitConverter.ToString(byteLoadKeyData.ToArray()));
				}
				else
				{
					this.LogAdd("블록 읽기 실패 ");
				}
			}
			else
			{
				this.LogAdd("카드를 읽을 수 없습니다.");
			}
		}


		/// <summary>
		/// 블록 쓰기 테스트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdateBinaryBlocks_Click(object sender, EventArgs e)
		{
			byte byteBlockNumber = this.BlockNumberGet();
			string sData = this.txtUpdateBinary.Text;
			//a타입 기준 1블럭은 16bytes 이다.(ACR122U 기준)
			byte[] byteData_Write
				= Get_Left(ASCIIEncoding.Default.GetBytes(sData), 16);

			if (true == this.m_nfcTest.CardIn())
			{
				if (true == this.m_nfcTest.UpdateBinaryBlocks(
											byteBlockNumber
											, byteData_Write))
				{
					this.LogAdd(String.Format("--- 블록 쓰기({0:X2}) --- 성공"
											, byteBlockNumber));					
				}
				else
				{
					this.LogAdd("블록 쓰기 실패 ");
				}
			}
			else
			{
				this.LogAdd("카드를 읽을 수 없습니다.");
			}
		}
		#endregion

		#region Nfc Reader

		private void btnUseBlockSet_Click(object sender, EventArgs e)
		{
			//시작 블록번호 변경
			//this.m_nfc.StartBlockNumberInt = (short)this.numericBlockCount.Value;

			//읽을 블럭 개수
			int nLength = (int)this.numericBlockCount.Value;
		}

		/// <summary>
		/// Nfc Reader - Read Binary
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnReadBinary_Click(object sender, EventArgs e)
		{
			this.LogAdd("-- 카드의 지정된 번호 데이터 읽기 시작");
			StringBuilder sb = new StringBuilder();
			foreach (byte itemBlockNum in this.m_nfc.UseDataBlocks)
			{
				sb.Append(", " + Convert.ToHexString(new byte[] { itemBlockNum }));
			}
			this.LogAdd("지정된 번호 : " + sb.ToString().Substring(1));

			//Task.Run(() => LongCalcAsync(10));

			byte[]? byteReturn = await this.m_nfc.ReadBinary();
			if (null == byteReturn
				|| 0 >= byteReturn.Length)
			{//데이터가 없다.
				this.LogAdd("-- 카드의 지정된 범위 데이터 읽기 실패");
			}
			else
			{
				this.LogAdd("-- 카드의 지정된 범위 데이터 읽기 성공");
				this.LogAdd(Convert.ToHexString(byteReturn));
				this.LogAdd("--  --  --  --  --  --  --  --  --");
				this.LogAdd(ASCIIEncoding.Default.GetString(byteReturn));
				this.LogAdd("--  --  --  --  --  --  --  --  --");
			}
		}


		private async void btnUpdateBinary_Click(object sender, EventArgs e)
		{
			this.LogAdd("-- 카드의 지정된 번호 데이터 쓰기 시작");
			StringBuilder sb = new StringBuilder();
			foreach (byte itemBlockNum in this.m_nfc.UseDataBlocks)
			{
				sb.Append(", " + Convert.ToHexString(new byte[] { itemBlockNum }));
			}
			this.LogAdd("지정된 번호 : " + sb.ToString().Substring(1));
			

			byte[] byteData_Write
				= ASCIIEncoding.Default.GetBytes(this.txtNfcReaderData.Text);
			

			if (false == await this.m_nfc.UpdateBinary(byteData_Write))
			{
				this.LogAdd("-- 카드의 지정된 범위 데이터 쓰기 실패");
			}
			else
			{
				this.LogAdd("-- 카드의 지정된 범위 데이터 쓰기 성공");
			}
		}

		#endregion

		private void comboCardList_SelectedIndexChanged(object sender, EventArgs e)
		{

			this.m_nfc.ReaderNameSet(comboCardList.Text);
			this.m_nfcTest.ReaderNameSet(comboCardList.Text);

			if (string.Empty != comboCardList.Text)
			{
				//모니터링 시작
				this.monitor.Start(this.m_nfc.ReaderName);
				//리더기 정보 출력
				//this.btnReadReaderAttr_Click(null, null);
			}
			else
			{
				this.m_nfc.ReaderNameSet(string.Empty);
				this.LogAdd("please Select Reader");
			}

		}


		private void Monitor_StatusChanged(object sender, StatusChangeEventArgs e)
		{
			StringBuilder sbTemp = new StringBuilder();
			StringBuilder sbTemp2 = new StringBuilder();
			sbTemp.Append(">> Status Changed : ");

			if (e.NewState.HasFlag(SCRState.Present))
			{
				sbTemp2.Append(", Card inserted(카드 들어있음)");
			}
			if (e.NewState.HasFlag(SCRState.InUse))
			{
				sbTemp2.Append(", In use(사용중, 공유 모드일 가능성 있음)");
			}
			if (e.NewState.HasFlag(SCRState.Empty))
			{
				sbTemp2.Append(", Card removed(비어 있음)");
			}

			if (0 == sbTemp2.Length)
			{
				sbTemp2.Append(e.NewState);
			}

			this.LogAdd(sbTemp.ToString() + sbTemp2.ToString());
		}

		/// <summary>
		/// 카드리스트 새로고침 버튼
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCardListRefresh_Click(object? sender, EventArgs? e)
		{
			string[] sNameList = NfcListInfo.ReaderList();

			//기존 리스트를 지우고
			comboCardList.Items.Clear();

			//새 리스트를 만든다.
			foreach (string itemName in sNameList)
			{
				comboCardList.Items.Add(itemName);
				this.LogAdd("find Reader : " + itemName);
			}
		}


		/// <summary>
		/// 리더기의 연결된 정보를 읽는다.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGetData_Click(object sender, EventArgs e)
		{
			using (var context = ContextFactory.Instance.Establish(SCardScope.System))
			{
				using (var rfidReader = context.ConnectReader(
											this.m_nfc.ReaderName
											, SCardShareMode.Shared
											, SCardProtocol.Any))
				{
					var apdu = new CommandApdu(IsoCase.Case2Short, rfidReader.Protocol)
					{
						CLA = 0xFF,
						Instruction = InstructionCode.GetData,
						P1 = 0x00,
						P2 = 0x00,
						Le = 0 // We don't know the ID tag size
					};

					using (rfidReader.Transaction(SCardReaderDisposition.Leave))
					{
						var sendPci = SCardPCI.GetPci(rfidReader.Protocol);
						var receivePci = new SCardPCI(); // IO returned protocol control information.

						var receiveBuffer = new byte[256];
						var command = apdu.ToArray();

						var bytesReceived = rfidReader.Transmit(
							sendPci, // Protocol Control Information (T0, T1 or Raw)
							command, // command APDU
							command.Length,
							receivePci, // returning Protocol Control Information
							receiveBuffer,
							receiveBuffer.Length); // data buffer

						var responseApdu =
							new ResponseApdu(receiveBuffer, bytesReceived, IsoCase.Case2Short, rfidReader.Protocol);

						this.LogAdd(string.Format("SW1: {0:X2}, SW2: {1:X2}\n Uid: {2}"
								, responseApdu.SW1,
							responseApdu.SW2,
							responseApdu.HasData 
								? BitConverter.ToString(responseApdu.GetData()) 
								: "No uid received"));
					}
				}
			}//end using context
		}

		private void btnSetData_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 왼쪽부터 지정한 길이만큼 데이터를 가지고 온다.
		/// <see href="https://github.com/dang-gun/DGUtility_DotNet/blob/main/DGU_ByteAssist/ByteArray.cs#L144">Get_Left</see>
		/// </summary>
		/// <param name="byteA"></param>
		/// <param name="nLength"></param>
		/// <returns></returns>
		public static byte[] Get_Left(byte[] byteA, int nLength)
		{
			byte[] byteCut = new byte[nLength];

			int nLeng = nLength;
			if (byteA.Length <= nLength)
			{//데이터가 입력된 길이보다 작다.

				//데이터 길이만큼만 사용한다.
				nLeng = byteA.Length;
			}

			Array.Copy(byteA, 0, byteCut, 0, nLeng);

			return byteCut;
		}

		
	}
}