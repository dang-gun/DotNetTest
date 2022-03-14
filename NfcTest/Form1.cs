using NfcTest.DeviceInfo;
using NfcTest.PcscSharpAssists;
using PCSC;
using PCSC.Iso7816;
using PCSC.Monitoring;
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
		NfcReader m_nfc;
		NfcReaderTest m_nfcTest;

		IMonitorFactory monitorFactory;
		ISCardMonitor monitor;

		private const byte MSB = 0x00;
		private const byte LSB = 0x08;


		public Form1()
		{
			InitializeComponent();

			//장비를 설정한다.
			this.m_nfc 
				= new NfcReader(
						new ARC122U_Series()
						, new Mifare1k());
			//
			this.m_nfcTest
				= new NfcReaderTest(
						new ARC122U_Series()
						, new Mifare1k());

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

		#region Device Test
		
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
			byte byteBlockNumber = 0x08;

			if (true == this.m_nfcTest.CardIn())
			{
				if (true == this.m_nfcTest.AuthBlock(byteBlockNumber))
				{
					this.LogAdd(String.Format("블록 권한 얻기 성공 : {0:X2}", byteBlockNumber));
				}
				else
				{
					this.LogAdd(">>> 블록 권한 얻기 실패");
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
			byte byteBlockNumber = 0x08;

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
			byte byteBlockNumber = 0x08;

			if (true == this.m_nfcTest.CardIn())
			{
				byte[] byteLoadKeyData = new byte[] { 0xFF, 0x0E, 0x0D, 0x0C, 0x0B, 0x0A, 0x09, 0x08, 0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00 };

				if (true == this.m_nfcTest.UpdateBinaryBlocks(byteBlockNumber, byteLoadKeyData))
				{
					this.LogAdd(String.Format("--- 블록 쓰기({0:X2}) --- 성공", byteBlockNumber));					
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
			string[] sNameList = this.m_nfc.ReaderList();
			IContextFactory contextFactory = ContextFactory.Instance;

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
		/// ATR 정보 출력
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReadReaderAttr_Click(object? sender, EventArgs? e)
		{

			byte[]? byteAtr = this.m_nfc.CardAttributeGet(SCardAttribute.AtrString);
			string sData = string.Empty;

			if (null != byteAtr)
			{
				sData = BitConverter.ToString(byteAtr);
				this.LogAdd(string.Format("ATR: {0}", sData));
			}
			else
			{
				this.LogAdd(string.Format("ATR: Failure"));
			}
		}

		/// <summary>
		/// 임의의 Apdu명령을 날려본다
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSendApdu_Click(object sender, EventArgs e)
		{
			var contextFactory = ContextFactory.Instance;
			using (var ctx = contextFactory.Establish(SCardScope.System))
			{
				using (var isoReader = new IsoReader(ctx
											, this.m_nfc.ReaderName
											, SCardShareMode.Shared
											, SCardProtocol.Any
											, false))
				{

					var apdu = new CommandApdu(IsoCase.Case2Short
									, isoReader.ActiveProtocol)
					{
						CLA = 0x00, // Class
						Instruction = InstructionCode.GetChallenge,
						P1 = 0x00, // Parameter 1
						P2 = 0x00, // Parameter 2
						Le = 0x08 // Expected length of the returned data
					};

					var response = isoReader.Transmit(apdu);
					Console.WriteLine("SW1 SW2 = {0:X2} {1:X2}", response.SW1, response.SW2);
					// ..
				}
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


		#region Custom Command - Block 0

		/// <summary>
		/// 권한 요청
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAuthBlock1_Click(object sender, EventArgs e)
		{
			using (var context = ContextFactory.Instance.Establish(SCardScope.System))
			{
				using (var isoReader 
						= new IsoReader(context: context
										, readerName: this.m_nfc.ReaderName
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
						this.LogAdd(string.Format("- Error - AUTHENTICATE failed."));
					}
					else
					{//인증 성공
						this.labInfo.Text = "Authentication : success";
						this.labInfo.BackColor = Color.FromArgb(255, 80, 240, 180);
						this.LogAdd(string.Format("AUTHENTICATE success."));
					}


				}
			}
		}

		private void btnBlock0ReadBinary_Click(object sender, EventArgs e)
		{
			using (var context = ContextFactory.Instance.Establish(SCardScope.System))
			{
				using (var isoReader
						= new IsoReader(context: context
										, readerName: this.m_nfc.ReaderName
										, mode: SCardShareMode.Shared
										, protocol: SCardProtocol.Any
										, releaseContextOnDispose: false))
				{
					MifareCard card = new MifareCard(isoReader);

					byte[]? result = card.ReadBinary(MSB, LSB, 16);
					if (null != result)
					{
						this.LogAdd(
							string.Format("Result (before BINARY UPDATE): {0}"
											, BitConverter.ToString(result)));
					}
					else
					{
						this.labInfo.Text = "Authentication : none";
						this.labInfo.BackColor = Color.FromArgb(255, 160, 0, 184);
						this.LogAdd(string.Format("- Error - Read Binary failed. - 인증을 다시 받으면 해결 될 수 있음."));
					}
				}
			}//end using context

		}

		private void btnBlock0UpdateBinary_Click(object sender, EventArgs e)
		{
			string sData = this.txtUpdateBinary.Text;
			//a타입 기준 1블럭은 16bytes 이다.(ACR122U 기준)
			byte[] byteData_Write 
				= Get_Left(ASCIIEncoding.Default.GetBytes(sData), 16);

			

			using (var context = ContextFactory.Instance.Establish(SCardScope.System))
			{
				using (var isoReader
						= new IsoReader(context: context
										, readerName: this.m_nfc.ReaderName
										, mode: SCardShareMode.Shared
										, protocol: SCardProtocol.Any
										, releaseContextOnDispose: false))
				{
					var card = new MifareCard(isoReader);

					var updateSuccessful = card.UpdateBinary(MSB, LSB, byteData_Write);

					if (true == updateSuccessful)
					{//
						this.LogAdd(string.Format("Update Binary : success "));
					}
					else
					{
						this.labInfo.Text = "Authentication : none";
						this.labInfo.BackColor = Color.FromArgb(255, 160, 0, 184);
						this.LogAdd(string.Format("- Error - Update Binary : failed. - 인증을 다시 받으면 해결 될 수 있음."));
					}
				}
			}//end using context
		}
		#endregion

		/// <summary>
		/// 왼쪽부터 지정한 길이만큼 데이터를 가지고 온다.
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




		#region Block Command

		#endregion

		
	}
}
