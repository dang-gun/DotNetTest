using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StochasticScenarioGlobal.Models
{
	/// <summary>
	/// 금액 분할 데이터
	/// </summary>
	public class MoneyDivisionModel
	{
		/// <summary>
		/// 이 분할이 얼마만큼의 누적금액 안에 끝날지 금액
		/// <para>이 금액만큼 전체 투입 누적 금액이 늘어나는 샘이다. </para>
		/// </summary>
		public long MaxSumMoney { get; set; }

		/// <summary>
		/// 이 금액을 몇개로 나눌지.
		/// </summary>
		public short DivisionCount { get; set; }

		/// <summary>
		/// 이 분할을 배치할때 이웃간 최소 간격.
		/// <para>이 금액 안쪽으로는 배치되지 않는다.
		/// == 이 금액 이상 투입 누적되야 발생한다.</para>
		/// </summary>
		/// <remarks>
		/// 분할은 바로 전 당첨을 기준이다.<br />
		/// 바로 전 당첨에서 최소 이 값만큼 떨어지게 된다.<br />
		/// 단, 최대값을 벗어나지 않는 경우에만,
		/// 최대값이 넘어가면 최대값을 사용한다.
		/// </remarks>
		public long NeighborMinMoney { get; set; }
		/// <summary>
		/// 이 반복을 배치할때 이웃간 최대 간격.
		/// <para>이 금액 바깠쪽으로는 배치되지 않는다.</para>
		/// </summary>
		/// <remarks>
		/// 분할은 바로 전 당첨을 기준이다.<br />
		/// 바로 전 당첨에서 최대 이 값 만큼 떨어지게 된다.<br />
		/// 단, 최대값을 벗어나지 않는 경우에만,
		/// 최대값이 넘어가면 최대값을 사용한다.
		/// </remarks>
		public long NeighborMaxMoney { get; set; }

		
		/// <summary>
		/// 분할된 금액 리스트<br />
		/// DivisionCount에서 설정된 수만큼 생성된다.<br />
		/// <순번, 금액> 구조로 되어 있다.
		/// </summary>
		public List<Tuple<short, long>> DivisionList { get; set; }
	}
}
