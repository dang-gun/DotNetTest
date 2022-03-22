using InheritanceTest.Parent1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InheritanceTest
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// 이 폼에서 사용할 랜덤 함수
		/// </summary>
		Random rand = new Random();

		public Form1()
		{
			InitializeComponent();
		}


		#region 부모1 리스트 테스트

		private List<Parent1Base> listParent1 = new List<Parent1Base>();

		private void btnParent1List_Click(object sender, EventArgs e)
		{
			this.listParent1.Clear();

			for (int i = 1; i < 10; ++i)
			{
				Parent1Base newP1;
				
				if (2 == rand.Next(1, 3))
				{
					newP1 = new Parent1Child1() { Job = "Car"};
				}
				else
				{
					newP1 = new Parent1Child2() { Money = 1000 };
				}

				this.listParent1.Add(newP1);
			}
		}

		private void btnParent1ListRestore_Click(object sender, EventArgs e)
		{
			int nCount = 0;

			foreach (Parent1Base itemChild in this.listParent1)
			{
				if (itemChild is Parent1Child1)
				{
					Parent1Child1 temp1 = (Parent1Child1)itemChild;
					Debug.WriteLine(String.Format("[{0}] Job : {1}"
									, nCount
									, temp1.Job));
				}
				else if (itemChild is Parent1Child2)
				{
					Parent1Child2 temp2 = (Parent1Child2)itemChild;
					Debug.WriteLine(String.Format("[{0}] Money : {1}"
									, nCount
									, temp2.Money));
				}

				++nCount;
			}
		}

		#endregion


	}
}
