using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StochasticScenarioGlobal.Models
{
	/// <summary>
	/// 화면에 그려질 or 에이전트가 사용할 데이터 모델
	/// </summary>
	public class GraphBarItemModel
	{
		
		public long idIndex;

		/// <summary>
		/// 구분용 고유번호
		/// <para>생성시 겹치지 않게 처리해야 한다.</para>
		/// </summary>
		public long idGraphBarItem { get; set; }

		/// <summary>
		/// 생성할때 사용된 부모(원본)의 고유번호
		/// </summary>
		public int idMoneyTableItem { get; set; }
		/// <summary>
		/// 화면에 표시될 순서
		/// <para>정렬에 사용된다.<br />
		/// 물고기 고유번호로 사용된다.
		/// </para>
		/// </summary>
		public int Number { get; set; }

		/// <summary>
		/// 당첨 금액
		/// <para>분할여부와 상관없이 지금 당첨금액이다.<br />
		/// </para>
		/// </summary>
		public long WinMoney { get; set; }

		/// <summary>
		/// 출현 하는 금액(세로)
		/// </summary>
		public long AppearMoney { get; set; }

		#region 긴 이벤트 미리보기(긴 예시)

		/// <summary>
		/// 긴 이벤트 미리보기 여부
		/// </summary>
		/// <remarks>
		/// 긴 이벤트는 애니메이션 지갑에 들어가지 않는다.
		/// </remarks>
		public bool LongEventPreviewIs { get; set; }

		/// <summary>
		/// 긴 이벤트 미리보기 사용시 출력될 대상번호
		/// </summary>
		/// <remarks>
		/// 긴 이벤트 미리보기로 생성된 이벤트가 사용할 애니 대상 번호<br />
		/// 0이면 부모의 값을 사용한다.
		/// </remarks>
		public int LongEventPreview_Number { get; set; }

		/// <summary>
		/// 지연 당첨 사용시 최소 범위
		/// </summary>
		public long LongEventPreview_MinMoney { get; set; } = 500;
		/// <summary>
		/// 지연 당첨 사용시 최대 범위
		/// </summary>
		public long LongEventPreview_MaxMoney { get; set; } = 1500;
		#endregion

		#region 이벤트 미리보기(가라 이벤트) 관련
		/// <summary>
		///  이벤트 미리보기 - 분할
		/// </summary>
		public int EventPreviewDivisionCount { get; set; }

		/// <summary>
		/// 이벤트 미리보기 - 범위 금액
		/// </summary>
		public long EventPreviewAreaMoney { get; set; }
		#endregion
		
		#region 지연 당첨 관련

		/// <summary>
		/// 지연 당첨 사용 여부
		/// </summary>
		/// <remarks>
		/// 지연 당첨을 사용하지 않으면 출연 금액 -1에 당첨되지 않는 이벤트를 생성한다.<br />
		/// 사용하면  설정된 범위안의 랜덤한 마이너스 금액만큼에 당첨되지 않는 이벤트를 생성한다.<br />
		/// 이 이벤트는 애니메이션만 있다.
		/// </remarks>
		public bool DelayWin { get; set; } = false;
		
		/// <summary>
		/// 지연 당첨 사용시 최소 범위
		/// </summary>
		public long DelayWin_MinMoney { get; set; } = 500;
		/// <summary>
		/// 지연 당첨 사용시 최대 범위
		/// </summary>
		public long DelayWin_MaxMoney { get; set; } = 1500;
		#endregion

		#region 분할(연타) 관련
		/// <summary>
		/// 분할(연타) 여부
		/// </summary>
		public bool DivisionIs { get; set; }

		/// <summary>
		/// 반복 여부(연타) 사용시 세부 설정.<br />
		/// 반복 여부를 사용하지 않을때는 null일수 있다.
		/// </summary>
		public MoneyDivisionModel MoneyDivision { get; set; }

		#endregion

		
		/// <summary>
		/// 오로지 UI를 위한 정보 텍스트
		/// </summary>
		public string InfoText { get; set; }

		public GraphBarItemModel()
		{
		}

		public GraphBarItemModel(long nId)
		{
			this.idGraphBarItem = nId;
		}

		public GraphBarItemModel(GraphBarItemModel toCopy)
		{
			this.idGraphBarItem = toCopy.idGraphBarItem;
			this.idMoneyTableItem = toCopy.idMoneyTableItem;
			this.Number = toCopy.Number;
			this.WinMoney = toCopy.WinMoney;
			this.AppearMoney = toCopy.AppearMoney;


			this.LongEventPreviewIs = toCopy.LongEventPreviewIs;
			this.LongEventPreview_Number = toCopy.LongEventPreview_Number;
			this.LongEventPreview_MinMoney = toCopy.LongEventPreview_MinMoney;
			this.LongEventPreview_MaxMoney = toCopy.LongEventPreview_MaxMoney;

			this.EventPreviewDivisionCount = toCopy.EventPreviewDivisionCount;
			this.EventPreviewAreaMoney = toCopy.EventPreviewAreaMoney;

			this.DelayWin = toCopy.DelayWin;
			this.DelayWin_MinMoney = toCopy.DelayWin_MinMoney;
			this.DelayWin_MaxMoney = toCopy.DelayWin_MaxMoney;

			this.DivisionIs = toCopy.DivisionIs;
			this.MoneyDivision = toCopy.MoneyDivision;


			this.InfoText = toCopy.InfoText;
		}

	}
}
