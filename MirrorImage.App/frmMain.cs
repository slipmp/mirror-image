using MirrorImage.Core;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MirrorImage.App
{
    public partial class frmMain : Form
    {
        private const string FileNameTest= "Test-Image-33MB-12858x6534.jpg";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            picInput.ImageLocation = FileNameTest;
            picInput.Load();

            ShowImageDetails();
        }

        private void btnMirror_Click(object sender, EventArgs e)
        {
            var imgInput = new Bitmap(picInput.Image);

            var frameMirrorService = new FrameMirrorService();

            var response = frameMirrorService.MirrorImage(imgInput);

            ShowResults(response);
        }

        private void ShowResults(MirrorImageResponse response)
        {
            picOutput.Image = response.ImageOutput;
            
            var strResults = new StringBuilder();
            strResults.Append("Elapsed Milliseconds: " + response.ElapsedMilliseconds + Environment.NewLine);

            txtResults.Text = strResults.ToString();
        }

        private void ShowImageDetails()
        {
            var file = new System.IO.FileInfo(FileNameTest);
            var mibSize = ConvertBytesToMebibytes(file.Length);

            var strDetails = new StringBuilder();
            strDetails.Append("Width: " + picInput.Image.Width + " pixels" + Environment.NewLine);
            strDetails.Append("Height: " + picInput.Image.Height + " pixels" + Environment.NewLine);
            strDetails.Append("Frame Size: " + string.Format("{0:N2} MiBs", mibSize) + Environment.NewLine);


            txtDetails.Text = strDetails.ToString();
        }

        private double ConvertBytesToMebibytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}
