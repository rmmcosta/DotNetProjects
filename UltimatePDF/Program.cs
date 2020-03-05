using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimatePDF
{
    class Program
    {
        static void Main(string[] args)
        {
            UltimatePDF ultimatePDF = new UltimatePDF();

            string URL = "https://kymabank-dev-ui.todo-1.com/UltimatePDFServiceDemo/";
            byte[] pdf;

            bool ssReuseSession = true;

            ultimatePDF.MssPrintPDF(URL, 0, ssReuseSession, out pdf);
            string path = @"C:\Users\rco\Downloads\sample.pdf";

            Console.WriteLine(ByteArrayToFile(path, pdf));

        }
        public static bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }
    }
}
