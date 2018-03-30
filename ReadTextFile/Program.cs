using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadTextFile
{
    class Program
    {
        List<FolioList> objfoliolist = new List<FolioList>();
        static void Main(string[] args)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"c:\Temp\SchLog.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
        }

        public void AddItemToList()
        {

        }
    }

    public class FolioList
    {
        public string Folio { get; set; }
        public string Trans_Source { get; set; }
        public string Trans_Number { get; set; }
        public string Sms_Status { get; set; }
        public string Email_Status { get; set; }
        public string Short_URL { get; set; }
    }
}
