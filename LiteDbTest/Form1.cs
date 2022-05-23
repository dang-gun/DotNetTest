using LiteDB;
using System.Runtime.InteropServices;
using System.Text;

namespace LiteDbTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            mciSendString(@"open Routing_BGM_101.wav type waveaudio alias applause1", null, 0, IntPtr.Zero);
            mciSendString(@"open Routing_BGM_701.wav type waveaudio alias foghorn1", null, 0, IntPtr.Zero);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get a collection (or create, if doesn't exist)
                ILiteCollection<DataModel> col 
                    = db.GetCollection<DataModel>("customers");

                // Create your new customer instance
                var customer = new DataModel
                {
                    Name = "John Doe",
                    Phones = new string[] { "8000-0000", "9000-0000" },
                    IsActive = true
                };

                // Insert new customer document (Id will be auto-incremented)
                col.Insert(customer);

                // Update a document inside a collection
                customer.Name = "Jane Doe";

                col.Update(customer);

                // Index document using document Name property
                col.EnsureIndex(x => x.Name);

                // Use LINQ to query documents (filter, sort, transform)
                var results = col.Query()
                    .Where(x => x.Name.StartsWith("J"))
                    .OrderBy(x => x.Name)
                    .Select(x => new { x.Name, NameUpper = x.Name.ToUpper() })
                    .Limit(10)
                    .ToList();

                // Let's create an index in phone numbers (using expression). It's a multikey index
                col.EnsureIndex(x => x.Phones);

                // and now we can query phones
                //DataModel r = col.FindOne(x => x.Phones.Contains("8888-5555"));
                DataModel r = col.FindOne(x => x.Name == "John Doe");


                if (r != null)
                {
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                
        }



        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        

        private void button2_Click(object sender, EventArgs e)
		{

            
            mciSendString(@"play applause1", null, 0, IntPtr.Zero);


            
            mciSendString(@"play foghorn1", null, 0, IntPtr.Zero);
        }

		private void button3_Click(object sender, EventArgs e)
		{
            mciSendString(@"stop applause1", null, 0, IntPtr.Zero);
            mciSendString("seek applause1 to start", null, 0, IntPtr.Zero);
            mciSendString(@"stop foghorn1", null, 0, IntPtr.Zero);
            mciSendString("seek foghorn1 to start", null, 0, IntPtr.Zero);
        }
	}
}