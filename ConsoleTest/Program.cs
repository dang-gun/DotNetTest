using System.Diagnostics;
using System.Management;
using System.Text;

namespace ConsoleTest
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			StringBuilder sb = new StringBuilder();
			sb.Append("가나다");

			string s1 = "가나다";
			string s1_2 = s1;
			string s2 = s1;

			Console.WriteLine("string s1 == s1_2 : " + Object.ReferenceEquals(s1, s1_2));
			Console.WriteLine("string s1 == s2 : " + Object.ReferenceEquals(s1, s2));
			Console.WriteLine("string s1_2 == s2 : " + Object.ReferenceEquals(s1_2, s2));
			Console.WriteLine("----------------------------------------------");

			s1 = "마바사";
			s2 = new string("마바사");
			Console.WriteLine("s1, s2 = \"마바사\"");
			Console.WriteLine("string s1 == s1_2 : " + Object.ReferenceEquals(s1, s1_2));
			Console.WriteLine("string s1 == s2 : " + Object.ReferenceEquals(s1, s2));
			Console.WriteLine("string s1_2 == s2 : " + Object.ReferenceEquals(s1_2, s2));


			Console.WriteLine("string s1_2 == \"가나다\" : " + Object.ReferenceEquals(s1_2, "가나다"));

			Console.WriteLine("----------------------------------------------");
			string s3 = "";
			string s4 = string.Empty;

			Console.WriteLine("string s3 == s4 : " + Object.ReferenceEquals(s3, s4));

			/*
//string s1 == s1_2 : True
//string s1 == s2 : True
//string s1_2 == s2 : True
//----------------------------------------------
//s1, s2 = "마바사"
//string s1 == s1_2 : False
//string s1 == s2 : False
//string s1_2 == s2 : False
//string s1_2 == "가나다" : True

			//string s3 == s4 : True
			 */
		}
	}
}