using LiteDB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StochasticScenarioGlobal.Models
{
	/// <summary>
	/// 최종 시나리오에 사용되는 아이템 모델
	/// </summary>
	public class ScenarioBarItemModel : GraphBarItemModel
	{
		[BsonId]
		public long idIndex { get; set; }

		/// <summary>
		/// 같은 원본을 사용하는 그룹의 아이디.
		/// </summary>
		/// <remarks>
		/// 원본의 아이디를 그룹 아이디로 사용한다.<br />
		/// </remarks>
		public long GroupId { get; set; } = 0;

		/// <summary>
		/// 최종 당첨 금액(실제 들어오는 돈)
		/// </summary>
		/// <remarks>분할(연타)라면 이번 타이밍에 당첨된 금액이다.<br />
		/// 이벤트 미리보기와 같이 당첨금이 없는 이벤트는 0이 들어가야 한다.</remarks>
		public long WinMoney_Complete { get; set; } = 0;

		/// <summary>
		/// 화면에 표시할 그래프의 금액
		/// </summary>
		/// <remarks>실제 화면에 출력되는 그래프의 금액이다.</remarks>
		public long WinMoney_View { get; set; } = 0;


		/// <summary>
		/// 분할(연타) 영역의 금액
		/// <remarks>이 금액의 분할 영역의 금액이다.(세로)<br />
		/// 이 금액은 분할영역의 시작일때만 입력되고 나머지는 0이다.</remarks>
		/// </summary>
		public long DivisionAreaMoney { get; set; } = 0;


		/// <summary>
		/// 이벤트 미리보기 여부
		/// <remarks>
		/// 이 당첨이 이벤트 미리보기에 포함된건지 여부<br />
		/// 이벤트 미리보기로 설정된 진짜 당첨도 이값을 true로 줘야한다.<br />
		/// 그래야 이벤트 영역이 끝났는지 확인이 가능하기 때문
		/// </remarks>
		/// </summary>
		public bool EventPreview { get; set; } = false;
		/// <summary>
		/// 이벤트 미리보기 영역의 시작지점
		/// </summary>
		public bool EventPreviewStart { get; set; } = false;
		/// <summary>
		/// 이벤트 미리보기 영역의 끝지점
		/// </summary>
		/// <remarks>
		/// 이벤트 미리보기가 없어도 이벤트 미리보기 영역의 끝을 알릴필요가 있다.<br />
		/// 그때사용하는 것이 이것이다.
		/// </remarks>
		public bool EventPreviewEnd { get; set; } = false;
		/// <summary>
		/// 최종적으로 계산된 이벤트 미리보기 범위 금액
		/// </summary>
		public long EventPreviewAreaMoney_Complete { get; set; } = 0;

		/// <summary>
		/// 이벤트 미리보기 번호
		/// </summary>
		/// <remarks>
		/// 어떤 애니메이션을 사용할지 번호이다.<br />
		/// 이 프로젝트에서 번호는 물고기 애니메이션 번호와 일치해야 한다.
		/// </remarks>
		public int EventPreview_Number { get; set; } = 0;

		/// <summary>
		/// 찾은 모터 패턴
		/// </summary>
		public string MotorPattern { get; set; } = string.Empty;



		/// <summary>
		/// 이 애니메이션이 진행되는 동안 돈을 따로 쌓을지 여부
		/// <para>헬기나 유람선 같이 배경으로만 등장하는 애니는 돈을 따로 쌓으면 안된다.</para>
		/// </summary>
		/// <remarks>
		/// 해당 애니가 재생되고 있는동안 확률장이 애니 저장소에 돈을 저장할지 여부이다.<br/>
		/// 이값이 true이면 애니가 진행되는 동안 별도의 저장소에 돈이 쌓인다.<br/>
		/// 헬기나 유람선 같이 배경으로 등장하는 예시는 이값이 false여야 한다.
		/// </remarks>
		public bool AniMoneyCountIs { get; set; } = true;


		/// <summary>
		/// 지연 당첨 사용시 지연된 당첨금 범위
		/// </summary>
		public long DelayWinMoney { get; set; } = 0;


		/// <summary>
		/// 분할 영역 시작 지점
		/// </summary>
		public bool DivisionAreaStart { get; set; } = false;

		/// <summary>
		/// UI에서만 사용되는 개체
		/// </summary>
		public bool UiOnly { get; set; } = false;

		/// <summary>
		/// 서버로 명령을 전달할지여부
		/// </summary>
		/// <remarks>
		/// 이벤트 범위알림과 같이 에이전트는 알아야 하지만
		/// 서버는 몰라도 되는 정보(당첨)일때 false로 해준다.
		/// </remarks>
		public bool SendServer { get; set; } = true;


		/// <summary>
		/// 최종 사용됐는지 여부
		/// </summary>
		/// <remarks>
		/// 서버에 완료 요청에 가서 뱅크에 쌓인경우 true가 된다.<br />
		/// 생성할때부터 이것을 true로 해주면 ui상으로만 표시되는 확률장 아이템이된다.<br />
		/// (확률장 UI에서 사용할때는 이것을 활용하자.)
		/// </remarks>
		public bool Used { get; set; } = false;

		public ScenarioBarItemModel()
		{
		}

		public ScenarioBarItemModel(GraphBarItemModel graphBarBaseModel)
			: base(graphBarBaseModel)
		{

			//그룹아이디 입력
			this.GroupId = graphBarBaseModel.idGraphBarItem;
		}

		//public ScenarioBarItemModel(GraphBarItemModel graphBarItemModel)
		//	: base(graphBarItemModel)
		//{
		//	this.WinMoney_Complete = 0;
		//	this.Used = false;
		//}

	}
}
