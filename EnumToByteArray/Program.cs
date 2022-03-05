using System;
using System.Globalization;
using System.Text;

namespace EnumToByteArray // Note: actual namespace depends on the project name.
{
    /// <summary>
    /// ascii string, 2 Byte Type
    /// </summary>
    enum ByteArrayType
    {
        None = 0x0000,

        OK = 0x4F4B,
        NK = 0x4E4B,
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] byteOri = { 0x4F, 0x4B };
            ByteArrayType typeSelect = ByteArrayType.OK;
            ByteArrayType typeTemp = ByteArrayType.None;

            //Byet data
            Console.WriteLine("---- [0-1] Original ----");
            Console.Write("byteOri : ");
            Console.WriteLine(byteOri[0] + " " + byteOri[1]);
            Console.WriteLine(" ");


            //my imagination
            Console.WriteLine("---- [0-2] my imagination ----");
            Console.WriteLine("typeSelect == (ByteArrayType)byteOri : Exception");
            Console.Write("(short)typeSelect == BitConverter.ToInt16(byteOri) : ");
            Console.WriteLine((short)typeSelect == BitConverter.ToInt16(byteOri));
            Console.Write("byteOri.Equals(BitConverter.GetBytes((short)typeSelect)) : ");
            Console.WriteLine(byteOri.Equals(BitConverter.GetBytes((short)typeSelect)));
            Console.WriteLine(" ");
            Console.WriteLine();
            

            //want result
            Console.WriteLine("---- [0-3] want result ----");
            typeTemp = ByteArrayType.None;
            if (typeSelect.ToString() == ASCIIEncoding.Default.GetString(byteOri))
            {
                typeTemp = ByteArrayType.OK;
            }
            Console.Write("typeSelect == typeTemp : ");
            Console.WriteLine(typeSelect == typeTemp);
            Console.WriteLine(" ");
            Console.WriteLine(" ");


            Console.WriteLine("---- [1] Enum.Parse ----");
            typeTemp = ByteArrayType.None;
            //https://stackoverflow.com/questions/29482/how-can-i-cast-int-to-enum
            typeTemp = (ByteArrayType)Enum
                            .Parse(typeof(ByteArrayType)
                                , ASCIIEncoding.Default.GetString(byteOri));
            Console.Write("typeSelect == typeTemp : ");
            Console.WriteLine(typeSelect == typeTemp);
            Console.WriteLine(" ");


            //BitConverter.ToInt
            Console.WriteLine("---- [2] BitConverter.ToInt ----");
            typeTemp = ByteArrayType.None;
            typeTemp = (ByteArrayType)BitConverter.ToInt16(byteOri);
            Console.Write("typeSelect == typeTemp : ");
            //Console.WriteLine((Int16)typeSelect.GetHashCode() == BitConverter.ToInt16(byteOri));
            Console.WriteLine(typeSelect == typeTemp);
            Console.WriteLine(" ");


            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/1f87b2c5-36c4-4d0c-bea7-c2a54ee1e628/enum-to-byte-array?forum=csharpgeneral
            Console.WriteLine("---- [3-1] BitConverter.GetBytes ----");
            typeTemp = ByteArrayType.None;
            byte[] byteSelect1 = BitConverter.GetBytes((Int16)typeSelect).Take(2).ToArray();
            Console.Write("byteSelect1 : ");
            Console.WriteLine(byteSelect1[0] + " " + byteSelect1[1]);
            Console.Write("byteOri == byteSelect : ");
            Console.WriteLine(byteOri == byteSelect1);
            Console.WriteLine(" ");

            Console.WriteLine("---- [3-2] BitConverter.GetBytes ----");
            typeTemp = ByteArrayType.None;
            byte[] byteSelect2 = new byte[] { byteSelect1[1], byteSelect1[0] };
            Console.Write("byteSelect2 : ");
            Console.WriteLine(byteSelect2[0] + " " + byteSelect2[1]);
            Console.Write("byteOri == byteSelect2 : ");
            Console.WriteLine(byteOri == byteSelect2);
            Console.WriteLine(" ");

            Console.WriteLine("---- [3-3] BitConverter.GetBytes ----");
            typeTemp = ByteArrayType.None;
            Console.Write("byteSelect2 : ");
            Console.WriteLine(byteSelect2[0] + " " + byteSelect2[1]);
            Console.Write("byteOri.Equals(byteSelect2) : ");
            Console.WriteLine(byteOri.Equals(byteSelect2));
            Console.WriteLine(" ");

            


            Console.ReadLine();
        }

    }
}