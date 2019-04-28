using System.Drawing;
using System.IO;

namespace MirrorImage.Core
{
    /// <summary>
    /// Created this class with sole purpose of returning Bitmap objects from frame-Examples files
    /// So I don't need to copy and past these files everywhere
    /// It is just to simulate real data
    /// </summary>
    public class FrameExamplesService
    {
        public Bitmap GetSDBitmap()
        {
            string imagePath = "1-SD-720-480.jpg";
            var result = ConvertToBitmap(imagePath);

            return result;
        }

        private Bitmap ConvertToBitmap(string fileName)
        {
            Bitmap bitmap;
            using (var bmpStream = File.Open(fileName, FileMode.Open))
            {
                var image = Image.FromStream(bmpStream);
                bitmap = new Bitmap(image);
            }
            return bitmap;
        }
    }
}
