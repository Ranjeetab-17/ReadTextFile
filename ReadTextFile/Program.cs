using System;
using System.Collections.Generic;
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
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"c:\Temp\SchLog.txt");

            foreach (var item in (ReturnDetail.GetDetail(file)))
            {
                objfoliolist.Add(item);
               ///Console.WriteLine($"FolioNo :{item.Folio}        TransSourcs:{item.Trans_Source}        TransNo:{item.Trans_Number}             SmsStatus:{item.Sms_Status}  EmailStatus:{item.Email_Status}");
               // Console.WriteLine($"{item.Folio}               {item.Trans_Source}        {item.Trans_Number}                  {item.Sms_Status}  {item.Email_Status}");
               //counter++;
            }

            var status = Console.ReadLine();
            var result = status == "Y" || status == "N" ? objfoliolist.Where(m => m.Sms_Status.Trim().Equals(status)) : objfoliolist;
            foreach (var item1 in result)
            {
                Console.WriteLine($"{item1.Folio}         {item1.Trans_Source}  {item1.Trans_Number}       {item1.Sms_Status}  {item1.Email_Status}    {item1.Short_URL}");

                counter++;
            }

            //while ((line = file.ReadLine()) != null)
            //{
            //    System.Console.WriteLine(line);
            //    counter++;
            //}

            //file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
        }

        public void AddItemToList()
        {

        }
    }
}
