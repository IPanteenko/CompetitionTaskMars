using CompetitionTaskMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskMars.Pages
{
    public class MessagePopUpPage
    {
        private IWebDriver driver { get; set; }

        public MessagePopUpPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindErrorMessagePopUp(string messageText)
        {
            IWebElement errorPopUp = driver.FindElement(By.XPath("/html/body/div[contains(@class,\"ns-type-error\")]/div[text()=\"" + messageText + "\"]"));
            return errorPopUp;
        }
        public IWebElement FindSuccessMassagePopUP(string messageText)
        {
            IWebElement successPopUp = driver.FindElement(By.XPath("/html/body/div[contains(@class,\"ns-type-success\")]/div[text()=\"" + messageText + "\"]"));
            return successPopUp;
        }

        public void WaitForErrorMessage()
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[contains(@class,\"ns-type-error\")]/div", 5);
        }

    
    }
}

