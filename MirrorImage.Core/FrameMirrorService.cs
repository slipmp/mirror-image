using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

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

            var result = MirrorImageFasterUsingUnsafeCode(imgInput);
            
            return result;
        }

        private Bitmap MirrorImageFasterUsingUnsafeCode(Bitmap imgInput)
        {
            int width = imgInput.Width;
            int height = imgInput.Height;

            var imgMirrored = new Bitmap(imgInput.Width, imgInput.Height);

            int newWidthMinusOne = width - 1;
            
            BitmapData imgInputBitmapData = imgInput.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppRgb);

            BitmapData imgMirroredBitmapData = imgMirrored.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppRgb);

            unsafe
            {
                int* imageOriginalPointer = (int*)imgInputBitmapData.Scan0.ToPointer();
                int* mirroredPointer = (int*)imgMirroredBitmapData.Scan0.ToPointer();

                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        int sourcePosition = (x + y * width);
                        int destinationPosition = (y * width + width - x -1);
                        mirroredPointer[destinationPosition] = imageOriginalPointer[sourcePosition];
                    }
                }

                // We have to remember to unlock the bits when we're done.
                imgInput.UnlockBits(imgInputBitmapData);
                imgMirrored.UnlockBits(imgMirroredBitmapData);
            }

            return imgMirrored;
        }

    }
}
