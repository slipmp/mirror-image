using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace MirrorImage.Core.Tests
{
    [TestClass]
    public class FrameMirrorServiceTests
    {
        private const string AllResolutionsPath = "Frame-Examples\\All-Resolutions\\";

        /// <summary>
        /// Algorithm should be able to process frames within all resolutions provided 
        /// on average of 16 milliseconds => 60 frames * 16 milliseconds = 960 milliseconds total, 
        /// under 1 second (1000 milleseconds).
        /// </summary>
        private const long MaximumMillisecondsPerFrame = 16; 

        private readonly FrameMirrorService _frameMirrorService = new FrameMirrorService();

        [TestMethod]
        public void MirrorImage_StandardDefinition_Pass()
        {
            //ARRANGE
            string imagePath = AllResolutionsPath + "1-SD-720-480.jpg";
            //Simulating Media player parameter
            var image = ConvertToBitmap(imagePath);

            var stopWatch = new Stopwatch();
            //Start counting from beginning of the logic
            stopWatch.Start();
            
            //ACT
            //Media Player calling the method to Mirror image
            var result = _frameMirrorService.MirrorImage(image);

            //ASSERT
            //Stop counting until last millisecond
            stopWatch.Stop();
            Assert.IsTrue(stopWatch.ElapsedMilliseconds <= 16, "Total elapsed milliseconds: " + stopWatch.ElapsedMilliseconds);
            Assert.IsNotNull(result, "Image result cannot be null");
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
