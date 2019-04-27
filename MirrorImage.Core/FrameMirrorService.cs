using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;


namespace MirrorImage.Core
{
    public interface IFrameMirrorService
    {
        MirrorImageResponse MirrorImage(Bitmap image);
    }

    public class FrameMirrorService : IFrameMirrorService
    {
        public MirrorImageResponse MirrorImage(Bitmap imgInput)
        {
            var stopWatch = new Stopwatch();
            //Start counting from beginning of the logic
            stopWatch.Start();

            var response = new MirrorImageResponse
            {
                ImageOutput = (Bitmap)imgInput.Clone()
            };

            response.ImageOutput.RotateFlip(RotateFlipType.RotateNoneFlipX);

            //Stop counting until last millisecond
            stopWatch.Stop();
            response.ElapsedMilliseconds = stopWatch.ElapsedMilliseconds;

            return response;
        }
    }
}
