using LiteDB;
using LiteDbAssist;
using StochasticScenarioGlobal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteDbTest2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDataAdd_Click(object sender, EventArgs e)
        {
            using (LiteDbContext db1 = LiteDbGlobal.Context())
            {
                // Create your new customer instance
                DataModel2 newData = new DataModel2();
                newData.Name = this.txtName.Text;

                db1.DataModel.Insert(newData);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            using (LiteDbContext db1 = LiteDbGlobal.Context())
            {
                

                var aaa = db1.DataModel.FindAll();
                List<DataModel2> bbb = aaa.ToList();

                MessageBox.Show(aaa.Count().ToString());
            }
        }

		private void btnDelete_Click(object sender, EventArgs e)
		{
            using (LiteDbContext db1 = LiteDbGlobal.Context())
            {
                
                var aaa = db1.DataModel.FindAll();
                var bbb = aaa.ToList();

                MessageBox.Show(aaa.Count().ToString());
            }
        }

		private void button1_Click(object sender, EventArgs e)
		{
            using (LiteDbContext db1 = LiteDbGlobal.Context())
            {
                long idIndex = db1.ScenarioBarItemModel.Count() + 1;

                
                ScenarioBarItemModel newData 
                    = new ScenarioBarItemModel(new GraphBarItemModel());
                //newData.idIndex = idIndex;
                newData.MoneyDivision = new MoneyDivisionModel();
                newData.MoneyDivision.DivisionList = new List<Tuple<short, long>>();
                newData.MoneyDivision.DivisionList.Add(new Tuple<short, long>(10, 1000));
                newData.MoneyDivision.DivisionList.Add(new Tuple<short, long>(20, 2000));

                db1.ScenarioBarItemModel.Insert(newData);

                db1.ScenarioBarItemModel.EnsureIndex(x => x.idIndex);
            }
        }

		private void button2_Click(object sender, EventArgs e)
		{
            using (LiteDbContext db1 = LiteDbGlobal.Context())
            {
                //db1.GraphBarItemModel.EnsureIndex(x => x.idIndex);

                ScenarioBarItemModel aaaaa
                    = db1.ScenarioBarItemModel.Query()
                        .Where(w => w.idIndex == 1)
                        .FirstOrDefault();

                aaaaa.WinMoney = 10000000;
                db1.ScenarioBarItemModel.Update(aaaaa);



                MessageBox.Show(aaaaa.ToString());
            }
        }
	}
}
