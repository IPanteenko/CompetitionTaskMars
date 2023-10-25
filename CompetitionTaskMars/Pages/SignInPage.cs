using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskMars.Pages
{
    public class SignInPage
    {
        private readonly IWebDriver driver;
        private const string portalAddress = "http://localhost:5000/";
        private const string userEmail = "panteenko@gmail.com";
        private const string password = "Z5t3RKM\"4K2yj~c";

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl(portalAddress);
        }

        IWebElement signInButton => driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));
        IWebElement emailTextBox => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]"));
        IWebElement passwordTextBox => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/input[1]"));
        IWebElement loginButton => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        public void SignTheUserIn()
        {
            signInButton.Click();
            emailTextBox.SendKeys(userEmail);
            passwordTextBox.SendKeys(password);
            loginButton.Click();
        }
    }
}
