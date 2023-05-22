
using NfcAssist;
using NfcCardInfo;
using NfcDeviceCommandAssists;
using PcscSharpAssists;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6LinuxTest.NfcList
{
	internal class NfcListController
	{
		
		/// <summary>
		/// 
		/// </summary>
		public List<string> NfcNameList { get; set; }
		
		/// <summary>
		/// NFC 카드 리스트
		/// </summary>
		private List<CardInfoInterface> CardInfoList
			= new List<CardInfoInterface>();
		/// <summary>
		/// 디바이스 명령 리스트
		/// </summary>
		private List<DeviceCommandInterface> DeviceCommandList
			= new List<DeviceCommandInterface>();

		/// <summary>
		/// 
		/// </summary>
		internal NfcListController()
		{
			//json 파일 로드
			NfcInfoFile nfcInfoFile = new NfcInfoFile();
			this.CardInfoList
				= nfcInfoFile.FolderLoad_CardInfo(@"Configs\CardInfo");
			this.DeviceCommandList
				= nfcInfoFile.FolderLoad_DeviceCommand(@"Configs\DeviceCommand");

			this.NfcNameList = new List<string>();
		}

		/// <summary>
		/// NFC 카드 리스트를 다시 불러오고 읽어들인 리더기 숫자를 리턴한다.
		/// </summary>
		/// <param name="bUseSam"></param>
		/// <returns></returns>
		public int NfcListRefresh(bool bUseSam)
		{
			//기존 리스트 초기화
			this.NfcNameList.Clear();

			string[] sNameList = NfcListInfo.ReaderList();

			//새 리스트를 만든다.
			foreach (string itemName in sNameList)
			{
				if (false == bUseSam)
				{
					int nIdx = itemName.IndexOf("SAM");
					if (nIdx >= 0) 
					{ //"SAM"은 제외
						continue;
					}
				}


				//모니터링 세팅
				//newItem.CardMonitorSet( monitorFactory.Create(SCardScope.System));


				this.NfcNameList.Add(itemName);

			}

			return this.NfcNameList.Count;
		}

	}
}
