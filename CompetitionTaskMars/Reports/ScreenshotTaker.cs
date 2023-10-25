using CompetitionTaskMars.Utilities;
using OpenQA.Selenium;

namespace CompetitionTaskMars.Reports
{
    internal class ScreenshotTaker
    {
        readonly IWebDriver driver;

        const string defaultScreenshotsFolder = "Screenshots";
        readonly string defaultScreenshotFilename = "Screenshot_";

        public ScreenshotTaker(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string TakeScreenshot()
        {
            var screenshotPath = $"{FileSystem.GetRootDirectory()}\\{defaultScreenshotsFolder}\\{defaultScreenshotFilename}{DateTime.Now.ToString("h_mm_ss")}.png";

            ITakesScreenshot takeScreenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = takeScreenshotDriver.GetScreenshot();

            FileSystem.CreateDirectory(defaultScreenshotsFolder); 
            screenshot.SaveAsFile(new Uri(screenshotPath).LocalPath, ScreenshotImageFormat.Png);
            return screenshotPath;
        }
    }
}
