using System.Drawing;
using VKAPI.TestingData;

namespace VKAPI.Utilities
{
    public static class CustomImageComparator
    {
        public static List<bool> GetHash(Bitmap bitmapSource)
        {
            List<bool> result = new();
            Bitmap bitmapMin = new(bitmapSource, new Size(TestData.BitmapWidth, TestData.BitmapHeight));
            for (int j = 0; j < bitmapMin.Height; j++)
            {
                for (int i = 0; i < bitmapMin.Width; i++)
                {
                    result.Add(bitmapMin.GetPixel(i, j).GetBrightness() < TestData.BitmapBrightness);
                }
            }
            return result;
        }

        public static bool AreImagesEqual(string firstImagePath, string secondImagePath)
        {
            List<bool> firstImageHash = GetHash(new Bitmap(firstImagePath));
            List<bool> secondImageHash = GetHash(new Bitmap(secondImagePath));
            return firstImageHash.Zip(secondImageHash, (i, j) => i == j).Count(eq => eq) == TestData.PixelEquality;
        }
    }
}
