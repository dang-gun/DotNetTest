using LiteDB;

namespace LiteDbTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            using (LiteDatabase db1 = LiteDbSupport.Context())
            {
                
            }
                
        }
    }
}