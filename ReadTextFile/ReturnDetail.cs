using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadTextFile
{
    public class ReturnDetail
    {
        public static System.Collections.Generic.IEnumerable<FolioList> GetDetail(StreamReader file)
        {
            string line;
            string Folio = string.Empty;
            string Trans_Source = string.Empty;
            string Trans_Number = string.Empty;
            string Sms_Status = string.Empty;
            string Email_Status = string.Empty;
            string Short_URL = string.Empty;

            FolioList obj = new FolioList();
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("Folio"))
                    Folio = line.Split(':')[1];
                if (line.Contains("Trans Source"))
                    Trans_Source = line.Split(':')[1];
                if (line.Contains("Trans Number"))
                    Trans_Number = line.Split(':')[1];
                if (line.Contains("Sms Status"))
                    Sms_Status = line.Split(':')[1];
                if (line.Contains("Email Status"))
                    Email_Status = line.Split(':')[1];

                if (line.Contains("Short URL")) {
                    Short_URL = line.Split(':')[2];
                    obj = new FolioList() {
                        Folio=Folio,
                        Trans_Source=Trans_Source,
                        Trans_Number=Trans_Number,
                        Email_Status=Email_Status,
                        Short_URL=Short_URL,
                        Sms_Status=Sms_Status
                    };
                    yield return obj;
                }                                    
            }

            file.Close();
        }
    }
}
