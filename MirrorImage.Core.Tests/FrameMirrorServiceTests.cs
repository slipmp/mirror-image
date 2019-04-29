using System;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
namespace MirrorImage.Core.Tests
{
    [TestFixture]
    public class FrameMirrorServiceTests
    {
        private const string AllResolutionsPath = "Frame-Examples\\All-Resolutions\\";
        private const string TwentyFour4KImagesResolutionPath = "Frame-Examples\\4K-Frames\\";

        /// <summary>
        /// Algorithm should be able to process frames within all resolutions 
        /// provided above on average of **40 milliseconds** => 
        /// 24 frames* 40 milliseconds = 960 milliseconds total, under 1 second(1000 milleseconds). 
        /// </summary>
        private const long MaximumMillisecondsPerFrame = 40; 

        private readonly FrameMirrorService _frameMirrorService = new FrameMirrorService();
        
        [TestCase("1-SD-720-480.jpg")]
        [TestCase("2-HD-1280-720.jpg")]
        [TestCase("3-Full-HD-1920-1080.jpg")]
        [TestCase("4-Ultra-HD-3840-2160.jpg")]
        [TestCase("5-4k-4096-2160.jpg")]
        public void MirrorImage_AllDefinitions_Pass(string imagePath)
        {
            //ARRANGE
            var fullImagePath = GetFullPath(AllResolutionsPath + imagePath);
            //Simulating Media player parameter
            var image = ConvertToBitmap(fullImagePath);

            var stopWatch = new Stopwatch();
            //Start counting from beginning of the logic
            stopWatch.Start();
            
            //ACT
            //Media Player calling the method to Mirror image
            var result = _frameMirrorService.MirrorImage(image);

            //ASSERT
            //Stop counting until last millisecond
            stopWatch.Stop();
            Assert.IsTrue(stopWatch.ElapsedMilliseconds <= MaximumMillisecondsPerFrame,
                $"Mirror method must finish within {MaximumMillisecondsPerFrame} " +
                $"but it was {stopWatch.ElapsedMilliseconds}");
            Assert.IsNotNull(result, "Image result cannot be null");
        }

        [Test]
        public void MirrorImage_24Images4KResolution_Under1SecondPass()
        {
            //ARRANGE
            var fullPath = GetFullPath(TwentyFour4KImagesResolutionPath);
            var listOfFiles = Directory.GetFiles(fullPath);
            var listOfImages = new List<Bitmap>();

            foreach (var fileName in listOfFiles)
            {
                var image = ConvertToBitmap(fileName);
                listOfImages.Add(image);
            }

            var parallel = new ParallelOptions
            {
                MaxDegreeOfParallelism = 24
            };

            //ACT
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Parallel.ForEach(listOfImages, parallel, image =>
            {
                _frameMirrorService.MirrorImage(image);
            });
            stopWatch.Stop();

            //ASSERT
            Assert.AreEqual(24, listOfImages.Count, "24 frames must " +
                "tested");
            Assert.IsTrue(stopWatch.ElapsedMilliseconds <= 1000,
                $"All 24 frames must be mirrored under 1 second/1000 milliseconds and it was " +
                $"{stopWatch.ElapsedMilliseconds}");
        }

        /// <summary>
        /// Test if images are really being mirrored programmatically   
        /// </summary>
        [Test]
        public void MirrorImage_MirroringFunctionality_Pass()
        {
            //ARRANGE
            var imageToTestPath = GetFullPath(AllResolutionsPath + "1-SD-720-480.jpg");
            var imageExpectedResultPath = GetFullPath(AllResolutionsPath + "1-SD-720-480-Mirror.jpg");
            //Simulating Media player parameter
            var imageToTest = ConvertToBitmap(imageToTestPath);
            var imageExpectedResult = ConvertToBitmap(imageExpectedResultPath);

            //ACT
            var result = _frameMirrorService.MirrorImage(imageToTest);

            //ASSERT
            var areImagesTheSame = CompareTwoBitmap(imageExpectedResult, result);
            Assert.IsTrue(areImagesTheSame, "MirrorImage() has wrong implementation as resulting image is not perfectly mirroed");
        }

        private Bitmap ConvertToBitmap(string fullPathFileName)
        {
            Bitmap bitmap;
            using (var bmpStream = File.Open(fullPathFileName, FileMode.Open))
            {
                var image = Image.FromStream(bmpStream);
                bitmap = new Bitmap(image);
            }
            return bitmap;
        }

        private string GetFullPath(string relativePath)
        {
            var result = TestContext.CurrentContext.TestDirectory.TrimEnd('\\')
                + "\\" + relativePath.TrimStart('\\');

            return result;
        }
        
        /// <summary>
        /// Method that compare pixel by pixel images that has been already mirrored
        /// Ideally this method should be a service, with Unit tests on it
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="img2"></param>
        /// <returns></returns>
        private bool CompareTwoBitmap(Bitmap img1, Bitmap img2)
        {
            if (img1.Width != img2.Width || img1.Height != img2.Height)
                return false;
                
            for (int i = 0; i < img1.Width; i++)
            {
                for (int j = 0; j < img1.Height; j++)
                {
                    var img1_ref = img1.GetPixel(i, j).ToString();
                    var img2_ref = img2.GetPixel(i, j).ToString();
                    if (img1_ref != img2_ref)
                        return false;
                }
            }
            return true;
        }
    }
}
