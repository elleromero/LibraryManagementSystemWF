using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Windows.Compatibility;

namespace LibraryManagementSystemWF.views
{
    public partial class ScanLibraryCard : Form
    {
        FilterInfoCollection fic;
        VideoCaptureDevice vcd;

        public ScanLibraryCard()
        {
            InitializeComponent();
        }

        private void ScanLibraryCard_Load(object sender, EventArgs e)
        {
            this.fic = new(FilterCategory.VideoInputDevice);
            foreach (FilterInfo fi in this.fic)
            {
                cmbDevice.Items.Add(fi.Name);
            }
            cmbDevice.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.vcd = new(this.fic[cmbDevice.SelectedIndex].MonikerString);
            this.vcd.NewFrame += CaptureDevice_NewFrame;
            this.vcd.Start();
            timer1.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        private void ScanLibraryCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.vcd.IsRunning)
            {
                this.vcd.SignalToStop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new();
                
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                
                if (result != null)
                {
                    MessageBox.Show(result.ToString());
                    timer1.Stop();
                    if (this.vcd.IsRunning)
                    {
                        this.vcd.SignalToStop();
                    }
                }
            }
        }
    }
}
