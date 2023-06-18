using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zen.Barcode;

namespace LibraryManagementSystemWF.utils
{
    internal class BarcodeMaker
    {
        public static Image BuildQR(string txt)
        {
            BarcodeDraw barcodeDraw = BarcodeDrawFactory.CodeQr;

            return barcodeDraw.Draw(txt, 70);
        }

        public static Image BuildISBN(string isbn)
        {
            BarcodeDraw barcodeDraw = BarcodeDrawFactory.Code128WithChecksum;

            return barcodeDraw.Draw(isbn, 70);
        }
    }
}
