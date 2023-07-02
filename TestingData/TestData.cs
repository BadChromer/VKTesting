using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace VKAPI.TestingData
{
    public static class TestData
    {
        public static ISettingsFile TestDataFile => new JsonSettingsFile("testData.json");

        public static int UserId => TestDataFile.GetValue<int>("checkPostManipulations.userId");

        public static string UserName => TestDataFile.GetValue<string>("checkPostManipulations.userName");

        public static int StringLength => TestDataFile.GetValue<int>("checkPostManipulations.stringLength");

        public static int ImageWidth => TestDataFile.GetValue<int>("checkPostManipulations.imageWidth");

        public static string FileType => TestDataFile.GetValue<string>("checkPostManipulations.fileType");

        public static string PathToUploadFile => TestDataFile.GetValue<string>("checkPostManipulations.pathToUploadFile");

        public static string PathToDownloadFile => TestDataFile.GetValue<string>("checkPostManipulations.pathToDownloadFile");

        public static string ContentType => TestDataFile.GetValue<string>("checkPostManipulations.contentType");

        public static int PixelEquality => TestDataFile.GetValue<int>("checkPostManipulations.pixelEquality");

        public static int BitmapWidth => TestDataFile.GetValue<int>("checkPostManipulations.bitmapWidth");

        public static int BitmapHeight => TestDataFile.GetValue<int>("checkPostManipulations.bitmapHeight");

        public static float BitmapBrightness => TestDataFile.GetValue<float>("checkPostManipulations.bitmapBrightness");

        public static int Timeout => TestDataFile.GetValue<int>("checkPostManipulations.timeout");

        public static int Interval => TestDataFile.GetValue<int>("checkPostManipulations.interval");
    }
}
