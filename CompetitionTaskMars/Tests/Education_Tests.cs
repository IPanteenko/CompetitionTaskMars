using CompetitionTaskMars.Models.Education;
using CompetitionTaskMars.NUnit.InputSources;
using CompetitionTaskMars.Pages;
using CompetitionTaskMars.Reports;
using CompetitionTaskMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace CompetitionTaskMars.Tests
{
    [TestFixture]
    internal class Education_Tests : CommonDriver
    {
        private EducationTabPage educationTabPageObj;
        private SignInPage signInPageObj;
        private MessagePopUpPage messagePopUpPageObj;
        private ReportWriter reportWriter;

        public void CreatePageObjects()
        {
            educationTabPageObj = new EducationTabPage(driver);
            signInPageObj = new SignInPage(driver);
            messagePopUpPageObj = new MessagePopUpPage(driver);
        }

        public void CreateReporter()
        {
            reportWriter = new ReportWriter();
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            CreateReporter();
        }

        [SetUp]
        public void SetUp()
        {
            CreateNewDriver();
            CreatePageObjects();
            reportWriter.InitialiseTestRun(TestContext.CurrentContext.Test.Name);
            reportWriter.AddScreenshotTaker(driver);

            signInPageObj.SignTheUserIn();
            educationTabPageObj.SwitchToEducationTab();
            educationTabPageObj.RemoveExistingEducation();
        }

        [TestCaseSource(typeof(EducationInputSource<Education>))]
        public void CreateNewEducationRecord(Education education)
        {
            educationTabPageObj.CreateNewEducation(education);

            educationTabPageObj.WaitUntilRecordIsVisible();

            Assert.That(educationTabPageObj.CountryNewRecord.Text == education.Country, "Actual Country and new Country don't match");
            Assert.That(educationTabPageObj.UniversityNewRecord.Text == education.University, "Actual University name and new University name don't match");
            Assert.That(educationTabPageObj.TitleNewRecord.Text == education.Title, "Actual Title and new Title don't match");
            Assert.That(educationTabPageObj.DegreeNewRecord.Text == education.Degree, "Actual Degree and new Degree don't match");
            Assert.That(educationTabPageObj.YearNewRecord.Text == education.GraduationYear, "Actual Year and new Year don't match");
        }

        [TestCaseSource(typeof(EducationParagraphInputSource<Education>))]
        public void CreateNewEducationRecordWithParagraph(Education education)
        {
            educationTabPageObj.CreateNewEducation(education);

            educationTabPageObj.WaitUntilRecordIsVisible();

            Assert.That(educationTabPageObj.CountryNewRecord.Text == education.Country, "Actual Country and new Country don't match");
            Assert.That(educationTabPageObj.UniversityNewRecord.Text == education.University, "Actual University name and new University name don't match");
            Assert.That(educationTabPageObj.TitleNewRecord.Text == education.Title, "Actual Title and new Title don't match");
            Assert.That(educationTabPageObj.DegreeNewRecord.Text == education.Degree, "Actual Degree and new Degree don't match");
            Assert.That(educationTabPageObj.YearNewRecord.Text == education.GraduationYear, "Actual Year and new Year don't match");
        }

        [TestCaseSource(typeof(CreateWithSameNameSource<DuplicatedEducation>))]
        public void DuplicateExample(DuplicatedEducation education)
        {
            educationTabPageObj.CreateNewEducation(education.Original);
            educationTabPageObj.CreateNewEducation(education.Duplicate);

            messagePopUpPageObj.WaitForErrorMessage();
            Assert.That(messagePopUpPageObj.FindErrorMessagePopUp("This information is already exist.").Displayed, "Error message is not present");

        }

        [TestCaseSource(typeof(EducationInputSource<Education>))]
        public void DeleteEducationRecord(Education education)
        {
            educationTabPageObj.CreateNewEducation(education);

            educationTabPageObj.DeleteEducation();

            Assert.That(educationTabPageObj.EducationRecord == null, "The record is present");
        }

        [TestCaseSource(typeof(EditEducationInputSource<EditEducation>))]
        public void EditEducationRecord(EditEducation education)
        {
            educationTabPageObj.CreateNewEducation(education.Original);

            educationTabPageObj.EditEducation(education.Edited);

            educationTabPageObj.WaitForUpdateButtonStale();

            Assert.That(educationTabPageObj.CountryNewRecord.Text == education.Edited.Country, "Actual Country and edited Country don't match");
            Assert.That(educationTabPageObj.UniversityNewRecord.Text == education.Edited.University, "Actual University name and edited University name don't match");
            Assert.That(educationTabPageObj.TitleNewRecord.Text == education.Edited.Title, "Actual Title and edited Title don't match");
            Assert.That(educationTabPageObj.DegreeNewRecord.Text == education.Edited.Degree, "Actual Degree and edited Degree don't match");
            Assert.That(educationTabPageObj.YearNewRecord.Text == education.Edited.GraduationYear, "Actual Year and edited Year don't match");

        }

        [TestCaseSource(typeof(EducationEmptyFieldSource<EducationEmptyField>))]
        public void AddEducationWithoutUniversity(EducationEmptyField education)
        {
            educationTabPageObj.CreateNewEducation(education.Emptyuniversity);
            var errorMessage = messagePopUpPageObj.FindErrorMessagePopUp("Please enter all the fields ");
            Assert.That(errorMessage.Displayed, "Error message is not displayed");
        }

        [TestCaseSource(typeof(EducationEmptyFieldSource<EducationEmptyField>))]
        public void AddEducationWithoutCountry(EducationEmptyField education)
        {
            educationTabPageObj.CreateNewEducation(education.Emptycountry);
            var errorMessage = messagePopUpPageObj.FindErrorMessagePopUp("Please enter all the fields ");
            Assert.That(errorMessage.Displayed, "Error message is not displayed");
        }

        [TestCaseSource(typeof(EducationEmptyFieldSource<EducationEmptyField>))]
        public void AddEducationWithoutTitle(EducationEmptyField education)
        {
            educationTabPageObj.CreateNewEducation(education.Emptytitle);
            var errorMessage = messagePopUpPageObj.FindErrorMessagePopUp("Please enter all the fields ");
            Assert.That(errorMessage.Displayed, "Error message is not displayed");
        }

        [TestCaseSource(typeof(EducationEmptyFieldSource<EducationEmptyField>))]
        public void AddEducationWithoutDegree(EducationEmptyField education)
        {
            educationTabPageObj.CreateNewEducation(education.Emptydegree);
            var errorMessage = messagePopUpPageObj.FindErrorMessagePopUp("Please enter all the fields ");
            Assert.That(errorMessage.Displayed, "Error message is not displayed");
        }

        [TestCaseSource(typeof(EducationEmptyFieldSource<EducationEmptyField>))]
        public void AddEducationWithoutYear(EducationEmptyField education)
        {
            educationTabPageObj.CreateNewEducation(education.Emptyyear);
            var errorMessage = messagePopUpPageObj.FindErrorMessagePopUp("Please enter all the fields ");
            Assert.That(errorMessage.Displayed, "Error message is not displayed");
        }

        [Test]
        public void CancelEducationAddition()
        {
            educationTabPageObj.ClickAddNewEducationButton();
            educationTabPageObj.ClickCancelAdditionButton();
            Assert.That(educationTabPageObj.EducationRecord == null, "Addition wasn't cancelled");
        }

        [TestCaseSource(typeof(EducationInputSource<Education>))]
        public void CancelEditofeducationrecord(Education education)
        {
            educationTabPageObj.CreateNewEducation(education);
            educationTabPageObj.ClickEditButton();
            educationTabPageObj.ClickCancelEditButton();
            Assert.That(educationTabPageObj.UpdateButton == null, "Add new button is present");
        }


        [Test]
        public void TryToDeleteNonExistantRecord()
        {
            Assert.That(educationTabPageObj.DeleteButton == null, "Delete button is present");
        }

        [Test]
        public void TryToEditNonExistantRecord()
        {
            Assert.That(educationTabPageObj.EditButton == null, "Edit button is present");
        }


        [TearDown]
        public void CloseTestRun()
        {
            reportWriter.RecordTestRunData(TestContext.CurrentContext);
            driver.Quit();
        }
    }
}
