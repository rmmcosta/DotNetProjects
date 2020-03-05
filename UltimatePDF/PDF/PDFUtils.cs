using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutSystems.NssUltimatePDF.PDF {
    public class PDFUtils : IDisposable {

        private readonly PdfDocument document;

        public PDFUtils(byte[] pdf) {
            using (MemoryStream stream = new MemoryStream(pdf)) {
                document = PdfReader.Open(stream);
            }
        }

        public int Pages {
            get {
                return document.Pages.Count;
            }
        }

        public void Dispose() {
            document.Close();
        }
    }
}
