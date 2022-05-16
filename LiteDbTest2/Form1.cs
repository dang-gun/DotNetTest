using LiteDB;
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
            using (LiteDatabase db1 = GlobalStatic.LiteDb.Context())
            {
                ILiteCollection<DataModel> table
                    = db1.GetCollection<DataModel>("customers");

                // Create your new customer instance
                DataModel newData = new DataModel();
                newData.Name = this.txtName.Text;

                table.Insert(newData);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            using (LiteDatabase db1 = GlobalStatic.LiteDb.Context())
            {
                ILiteCollection<DataModel> table
                    = db1.GetCollection<DataModel>("customers");

                var aaa = table.FindAll();
                var bbb = aaa.ToList();

                MessageBox.Show(aaa.Count().ToString());
            }
        }
    }
}
