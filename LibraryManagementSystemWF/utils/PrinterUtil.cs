using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.utils
{
    internal class PrinterUtil
    {
        private Form form;
        private PrintDocument printDoc;
        private Bitmap bmp;
        private int yCut;

        public PrinterUtil(Form form, int yCut = 0)
        {
            this.form = form;
            this.printDoc = new();
            this.printDoc.PrintPage += PrintDocument_PrintPage;
            this.yCut = yCut;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(this.bmp, 0, 0);
        }

        public void Print()
        {
            PrintPreviewDialog prev = new();
            prev.Document = this.printDoc;

            Graphics g = this.form.CreateGraphics();
            this.bmp = new(this.form.Size.Width, this.form.Size.Height - yCut, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.form.Location.X, this.form.Location.Y, 0, 0, this.form.Size);

            prev.ShowDialog();
        }
    }
}
