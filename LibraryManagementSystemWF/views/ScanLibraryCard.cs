using AForge.Video;
using AForge.Video.DirectShow;
using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard.GeneralUser;
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
    public delegate void CallbackDelegate(User user);

    public partial class ScanLibraryCard : Form
    {
        FilterInfoCollection fic;
        VideoCaptureDevice vcd;
        Form form;
        CallbackDelegate cb;

        public ScanLibraryCard(Form form, CallbackDelegate cb)
        {
            InitializeComponent();

            this.form = form;
            this.cb = cb;
        }

        private void ScanLibraryCard_Load(object sender, EventArgs e)
        {
            this.fic = new(FilterCategory.VideoInputDevice);
            foreach (FilterInfo fi in this.fic)
            {
                cmbDevice.Items.Add(fi.Name);
            }
            cmbDevice.SelectedIndex = 0;

            // load default user
            this.panel1.Controls.Add(new UserContainer(new User
            {
                Username = "juan_54",
                Member = new Member
                {
                    FirstName = "Juan",
                    LastName = "Dela Cruz"
                },
                Role = new Role
                {
                    Name = "USER"
                }
            }, true));
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
            if (this.vcd != null)
            {
                if (this.vcd.IsRunning)
                {
                    this.vcd.SignalToStop();
                }
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new();
                
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                
                if (result != null)
                {
                    bool isValid = Guid.TryParse(result.ToString(), out _);
                    
                    if (isValid)
                    {
                        ControllerModifyData<User> res = await GuestController.GetUserById(result.ToString());

                        if (res.IsSuccess && res.Result != null)
                        {
                            if (res.Result.Role.Name == "USER")
                            {
                                this.panel1.Controls.Add(new UserContainer(res.Result));
                                this.cb(res.Result);
                            } else MessageBox.Show("No user found");
                        }
                        else MessageBox.Show("No user found");
                    } else
                    {
                        MessageBox.Show("Invalid QR Code");
                    }

                    timer1.Stop();
                    if (this.vcd.IsRunning)
                    {
                        this.vcd.SignalToStop();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.form.Show();
            this.Close();
        }
    }
}
