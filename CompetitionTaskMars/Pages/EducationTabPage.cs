using CompetitionTaskMars.Models.Education;
using CompetitionTaskMars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CompetitionTaskMars.Pages
{
    public class EducationTabPage
    {
        public readonly IWebDriver driver;
        public IWebElement EducationButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        public IWebElement AddNewEducationButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        public IWebElement CollegeUniNameTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input"));
        public IWebElement CountryDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));
        public IWebElement TitleDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));
        public IWebElement DegreeTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
        public IWebElement YearOfGraduationDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));
        public IWebElement AddEducationButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));
        public IWebElement CancelAdditionButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[2]"));
        public IWebElement DeleteButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]")).FirstOrDefault();
        public IWebElement EditButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[1]")).FirstOrDefault();
        public IWebElement EditCollegeNameTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td/div[1]/div[1]/input"));
        public IWebElement EditCountryDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td/div[1]/div[2]/select"));
        public IWebElement EditTitleDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td/div[2]/div[1]/select"));
        public IWebElement EditDegreeTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td/div[2]/div[2]/input"));
        public IWebElement EditYearDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td/div[2]/div[3]/select"));
        public IWebElement UpdateButton => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td/div[3]/input[1]")).FirstOrDefault();
        public IWebElement CancelEditButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td/div[3]/input[2]"));
        public IWebElement CountryNewRecord => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
        public IWebElement UniversityNewRecord => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[2]"));
        public IWebElement TitleNewRecord => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[3]"));
        public IWebElement DegreeNewRecord => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[4]"));
        public IWebElement YearNewRecord => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[5]"));
        public IWebElement EducationRecord => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody")).FirstOrDefault();

        public EducationTabPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchToEducationTab()
        {
            Utilities.Wait.WaitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 5);
            EducationButton.Click();
        }

        public void RemoveExistingEducation()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            while (DeleteButton != null)
            {
                var rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody")).Count;
                DeleteButton.Click();
                wait.Until ((driver) =>
                {
                    var updatedRowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody")).Count;
                    return updatedRowCount == rowCount - 1;
                });
            }
        }

        public void CreateNewEducation(Education education)
        {
            Wait.WaitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div", 5);
            AddNewEducationButton.Click();

            if (education.University != null)
            {
                CollegeUniNameTextbox.SendKeys(education.University);
            }

            if (education.Country != null)
            {
                SelectElement countryDropDown = new SelectElement(CountryDropDown);
                countryDropDown.SelectByValue(education.Country);
            }

            if (education.Title != null)
            {
                SelectElement titleDropDown  = new SelectElement(TitleDropDown);
                titleDropDown.SelectByValue(education.Title);
            }

            if (education.Degree != null)
            {
                DegreeTextbox.SendKeys(education.Degree);
            }

            if(education.GraduationYear != null) 
            {
                SelectElement yearOfGraduationTextbox = new SelectElement(YearOfGraduationDropDown);
                yearOfGraduationTextbox.SelectByValue(education.GraduationYear);
            }

            AddEducationButton.Click();   
        }

        public void DeleteEducation()
        {
            Wait.WaitToBEClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]", 5);
            DeleteButton.Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(DeleteButton));
        }

        

        public void EditEducation(Education education)
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[1]", 10);
            EditButton.Click();

            if (education.University != null)
            {
                EditCollegeNameTextbox.Clear();
                EditCollegeNameTextbox.SendKeys(education.University);
            }

            if (education.Country != null)
            {
                SelectElement editCountryDropDown = new SelectElement(EditCountryDropDown);
                editCountryDropDown.SelectByValue(education.Country);
            }

            if (education.Title != null)
            {
                SelectElement editTitleDropDown = new SelectElement(EditTitleDropDown);
                editTitleDropDown.SelectByValue(education.Title);
            }

            if (education.Degree != null)
            {
                EditDegreeTextbox.Clear();
                EditDegreeTextbox.SendKeys(education.Degree);
            }

            if (education.GraduationYear != null)
            {
                SelectElement editYearOfGraduationTextbox = new SelectElement(EditYearDropDown);
                editYearOfGraduationTextbox.SelectByValue(education.GraduationYear);
            }

           UpdateButton.Click();
        }

        public void ClickAddNewEducationButton()
        {
            AddNewEducationButton.Click();
        }

        public void ClickCancelAdditionButton()
        {
            CancelAdditionButton.Click();
        }

        public void ClickEditButton()
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[1]", 10);

            EditButton.Click();
        }

        public void ClickCancelEditButton() 
        {
            CancelEditButton.Click();
        }

        public void WaitUntilRecordIsVisible()
        {
            Wait.WaitIsVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody", 5);
        }

        public void WaitForUpdateButtonStale()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(UpdateButton));
        }
    }
}
