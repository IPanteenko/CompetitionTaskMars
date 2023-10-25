using CompetitionTaskMars.Models.Certifications;
using CompetitionTaskMars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskMars.Pages
{
    public class CertificationsTabPage
    {
        public readonly IWebDriver driver;

        public IWebElement CertificationsTabButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        public IWebElement AddNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        public IWebElement CertificationNameTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));
        public IWebElement CertificationFromTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div/input"));                                                                        
        public IWebElement YearDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        public IWebElement CancelAdditionBUtton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[2]"));
        public IWebElement DeleteButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]")).FirstOrDefault();
        public IWebElement EditButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[1]")).FirstOrDefault();
        public IWebElement EditCertificationNameTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/div/div[1]/input"));
        public IWebElement EditCertificationFromTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/div/div[2]/input"));
        public IWebElement EditYearDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/div/div[3]/select"));
        public IWebElement UpdateButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]")).FirstOrDefault();
        public IWebElement CancelEditButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/span/input[2]"));
        public IWebElement CertificateName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[1]"));
        public IWebElement CertificateFrom => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[2]"));
        public IWebElement CertificateYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[3]"));
        public IWebElement CertificationsRecord => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody")).FirstOrDefault();

        public CertificationsTabPage (IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchToCertificationsTab()
        {
            Wait.WaitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 5);
            CertificationsTabButton.Click();
        }

        public void RemoveExistingCertifications()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            while (DeleteButton != null)
            {
                var rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody")).Count;
                                                                              
                DeleteButton.Click();
                wait.Until((driver) =>
                {
                    var updatedRowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody")).Count;
                    return updatedRowCount == rowCount - 1;
                });
            }
        }

        public void CreateNewCerticationRecord(Certifications certification)
        {
            Wait.WaitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 5);
            AddNewButton.Click();

            if (certification.Certificate != null)
            {
                CertificationNameTextbox.SendKeys(certification.Certificate);
            }

            if (certification.From != null)
            {
                CertificationFromTextbox.SendKeys(certification.From);
            }

            if (certification.Year != null)
            {
                SelectElement yearOfGraduationTextbox = new SelectElement(YearDropDown);
                yearOfGraduationTextbox.SelectByValue(certification.Year);
            }

            AddButton.Click();
        }
        public void WaitForRecordIsVisible()
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody", 5);
        }
        public void DeleteRecord()
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody", 5);
            DeleteButton.Click();

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(DeleteButton));
        }

        public void EditRecord(Certifications certificate)
        {
            Wait.WaitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span", 5);

            EditButton.Click();

            EditCertificationNameTextbox.Clear();
            EditCertificationNameTextbox.SendKeys(certificate.Certificate);

            EditCertificationFromTextbox.Clear();
            EditCertificationFromTextbox.SendKeys(certificate.From);

            SelectElement editYearDropDown = new SelectElement(EditYearDropDown);
            editYearDropDown.SelectByValue(certificate.Year);

            UpdateButton.Click();
        }

        public void WaitForUpdateButtonStail()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(UpdateButton));
        }

        public void ClickAddButton()
        {
            Wait.WaitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 5);

            AddNewButton.Click();
        }

        public void ClickCancelAdditionButton()
        {
            CancelAdditionBUtton.Click();
        }

        public void ClickEditButton()
        {
            Wait.WaitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span", 5);

            EditButton.Click();
        }

        public void ClickCuncelEditButton()
        {
            CancelEditButton.Click();
        }

    }
}
