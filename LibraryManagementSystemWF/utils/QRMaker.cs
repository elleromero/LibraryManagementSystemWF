using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zen.Barcode;

namespace LibraryManagementSystemWF.utils
{
    internal class QRMaker
    {
        public static Image GenerateQR(string dataToEncode, int size)
        {
            BarcodeSymbology symbology = BarcodeSymbology.CodeQr;
            BarcodeDraw drawObj = BarcodeDrawFactory.GetSymbology(symbology);

            return drawObj.Draw(dataToEncode, size);
        }

        public static string SaveQr(Image img, string fileName)
        {
            string basePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = Path.Combine(basePath, "resources", "temp_qr", $"{fileName}.png");
            img.Save(path, System.Drawing.Imaging.ImageFormat.Png);

            return path;
        }
    }
}
