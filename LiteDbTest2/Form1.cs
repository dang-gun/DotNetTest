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
                DataModel newData = new DataModel();
                newData.Name = this.txtName.Text;

                db1.DataModel.Insert(newData);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            using (LiteDbContext db1 = LiteDbGlobal.Context())
            {
                

                var aaa = db1.DataModel.FindAll();
                var bbb = aaa.ToList();

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
                GraphBarItemModel newData = new GraphBarItemModel();
                newData.MoneyDivision = new MoneyDivisionModel();
                newData.MoneyDivision.DivisionList = new List<Tuple<short, long>>();
                newData.MoneyDivision.DivisionList.Add(new Tuple<short, long>(10, 1000));
                newData.MoneyDivision.DivisionList.Add(new Tuple<short, long>(20, 2000));

                db1.GraphBarItemModel.Insert(newData);
            }
        }

		private void button2_Click(object sender, EventArgs e)
		{
            using (LiteDbContext db1 = LiteDbGlobal.Context())
            {
                //db1.GraphBarItemModel.EnsureIndex(x => x.idIndex);

                var aaa = db1.GraphBarItemModel.FindAll();
                var bbb = aaa.ToList();

                MessageBox.Show(aaa.Count().ToString());
            }
        }
	}
}
