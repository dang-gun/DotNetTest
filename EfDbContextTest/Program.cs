using EntityFrameworkSample.DB.Models;

namespace EfDbContextTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                TestOC1? findItem = db1.TestOC1.Where(w => w.idTestOC1 == 1).FirstOrDefault();
            }
        }
    }
}
