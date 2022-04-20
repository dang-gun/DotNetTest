internal class Program
{
    private double[] myArray =
            {
                1245.67,
                1189.55,
                1089.72,
                1456.88,
                2109.34,
                1987.55,
                1872.36
            };


    static void Main(string[] args)
	{
		Console.WriteLine("Hello World!");

        string salesValue;
        Double[] sales = new double[8];
        int count = 0;
        double maxSales = Double.MinValue;
        double minSales = Double.MaxValue;
        double totalSales = 0;

        try
        {
//StringReader dataStream = new StringReader("TextFile1.txt");
StreamReader dataStream = new StreamReader("TextFile1.txt");

            salesValue = dataStream.ReadLine();

            var total = sales.Sum();
            var average = sales.Average();
            var high = sales.Max();
            var low = sales.Min();

            while (salesValue != null)
            {
                try
                {
                    sales[count] = Convert.ToDouble(salesValue);

                    totalSales += sales[count];

                    if (sales[count] > maxSales)
                        maxSales = sales[count];

                    if (sales[count] < minSales)
                        minSales = sales[count];

                    count++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\tException: '" + salesValue + "'");

                    salesValue = dataStream.ReadLine();
                }

                dataStream.Close();



                for (int item = 0; item < 7; item++)
                {
                    Console.WriteLine("데이터" + sales[item]);
                }
                    

                string listItems = string.Join(",\n", sales);


                Console.WriteLine(listItems);
                Console.WriteLine(totalSales);
                Console.WriteLine(maxSales);
                Console.WriteLine(minSales);

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }


        Console.ReadLine();
	}
}