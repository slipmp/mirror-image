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
        /// <summary>
        /// Stefano, I was able to find another way of performing the job by using pointers in c#
        /// everything is done on memory and it is faster than original implementation by using 
        /// imageOutput.RotateFlip(RotateFlipType.RotateNoneFlipX);
        /// </summary>
        /// <param name="imgInput"></param>
        /// <returns></returns>
        public Bitmap MirrorImage(Bitmap imgInput)
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
                        //This is genius :) 
                        int destinationPosition = (y * width + newWidthMinusOne - x);
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
