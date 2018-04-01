using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadTextFile
{
    class Program
    {
        public static List<FolioList> objfoliolist = new List<FolioList>();
        static void Main(string[] args)
        {
            int counter = 0;
            Console.Write("Enter Path  : ");

            var getPath = Console.ReadLine();

            if (File.Exists(getPath))
            {

                System.IO.StreamReader file =
                    new System.IO.StreamReader(getPath);

                //@"c:\Temp\SchLog.txt"

                foreach (var item in (ReturnDetail.GetDetail(file)))
                {
                    objfoliolist.Add(item);
                }

                Console.Write("Enter SmsSent Status : ");
                var status = Console.ReadLine();
                var result = status == "Y" || status == "N" ? objfoliolist.Where(m => m.Sms_Status.Trim().Equals(status)) : objfoliolist;

                Console.Write("Where To Save ? : ");
                var saveIn=Console.ReadLine();
                StreamWriter str = new StreamWriter(saveIn);
                
                foreach (var item1 in result)
                {
                    str.WriteLine($"{item1.Folio}   {item1.Trans_Source}    {item1.Trans_Number}    {item1.Sms_Status}  {item1.Email_Status}");
                    Console.WriteLine($"{item1.Folio}         {item1.Trans_Source}  {item1.Trans_Number}       {item1.Sms_Status}  {item1.Email_Status}    {item1.Short_URL}");
                    counter++;
                }
                str.Close();
                System.Console.WriteLine("There were {0} lines.", counter);                
            }
            else
            {
                Console.WriteLine("File does not exists");               
            }
            Console.ReadLine();
        }
    }
}
