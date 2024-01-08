using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using Application = Microsoft.Office.Interop.PowerPoint.Application;
using MSO = Microsoft.Office.Core.MsoTriState;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;

namespace LibraryManagementSystemWF.utils
{
    internal class PowerpointBuilder
    {
        private Application pptApp;
        private Presentation presentation;
        private int targetSlide = 1;
        private string path, basePath;

        public PowerpointBuilder(string filePath)
        {
            this.pptApp = new();
            this.presentation = pptApp.Presentations.Open(filePath, MSO.msoFalse, MSO.msoFalse, MSO.msoFalse);
        }

        public void Modify(Image qr, string studentNo, string userId, string name, string year, string course, string profile, bool saveCopy = false)
        {
            foreach (Slide slide in this.presentation.Slides)
            {
                foreach (Shape shape in slide.Shapes)
                {
                    if (shape.HasTextFrame == MSO.msoTrue && shape.TextFrame.HasText == MSO.msoTrue)
                    {
                        string text = shape.TextFrame.TextRange.Text;

                        if (text.Contains("@student_no")) shape.TextFrame.TextRange.Text = studentNo;
                        if (text.Contains("@student_name")) shape.TextFrame.TextRange.Text = name;
                        if (text.Contains("@course_year")) shape.TextFrame.TextRange.Text = year;
                        if (text.Contains("@course_name")) shape.TextFrame.TextRange.Text = course;
                        if (text.Contains("@valid_until")) shape.TextFrame.TextRange.Text = DateTime.Now.AddMonths(6).ToString("dd MMMM yyyy");
                    }

                    if (shape.Type == MsoShapeType.msoAutoShape && shape.Name.Contains("@profile"))
                    {
                        this.basePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                        this.path = Path.Combine(this.basePath, profile.Replace("../../../", ""));
                        this.path = this.path.Replace("/", "\\");
                        shape.Fill.UserPicture(this.path);
                    }

                    if (shape.Type == MsoShapeType.msoAutoShape && shape.Name.Contains("@qr"))
                    {
                        shape.Fill.UserPicture(QRMaker.SaveQr(qr, userId));
                    }
                }
            }

            string basePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = Path.Combine(basePath, "resources", "library_id", $"{new Random().Next()}.pptx");

            if (saveCopy) this.presentation.SaveAs(path, PpSaveAsFileType.ppSaveAsDefault, MSO.msoFalse);

            this.presentation.PrintOut();
            Thread.Sleep(5000);

            this.presentation.Close();
            this.pptApp.Quit();
        }
    }
}
