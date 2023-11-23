using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace CompetitionTaskMars.Utilities
{
    public class CommonDriver
    {
        protected IWebDriver driver;

        public void CreateNewDriver()
        {
            driver = new ChromeDriver();
        }
    }
}
