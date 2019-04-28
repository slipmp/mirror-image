using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MirrorImage.Core
{
    public interface IFrameMirrorService
    {
        Bitmap MirrorImage(Bitmap image);
    }

    public class FrameMirrorService : IFrameMirrorService
    {
        public Bitmap MirrorImage(Bitmap imgInput)
        {
            //Test if image is null among other things

            var imageOutput = (Bitmap)imgInput.Clone();

            //.NET Framework provides a rotate flip out of the box
            imageOutput.RotateFlip(RotateFlipType.RotateNoneFlipX);

            return imageOutput;
        }
    }
}
