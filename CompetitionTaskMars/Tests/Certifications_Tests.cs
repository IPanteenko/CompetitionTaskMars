using CompetitionTaskMars.Models.Certifications;
using CompetitionTaskMars.NUnit.InputSources;
using CompetitionTaskMars.Pages;
using CompetitionTaskMars.Reports;
using CompetitionTaskMars.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskMars.Tests
{
    [TestFixture]
    internal class Certifications_Tests : CommonDriver
    {
        private CertificationsTabPage certificationsTabPageObj;
        private SignInPage signInPageObj;
        private MessagePopUpPage messagePopUpPageObj;
        private ReportWriter reportWriter;

        public void CreatePageObjects()
        {
            certificationsTabPageObj = new CertificationsTabPage(driver);
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
            certificationsTabPageObj.SwitchToCertificationsTab();
            certificationsTabPageObj.RemoveExistingCertifications();
        }

        [TestCaseSource(typeof(AddCertificationInputSource<Certifications>))]
        public void CreateNewRecord(Certifications certifications)
        {
            certificationsTabPageObj.CreateNewCerticationRecord(certifications);
            certificationsTabPageObj.WaitForRecordIsVisible();

            Assert.That(certificationsTabPageObj.CertificateName.Text == certifications.Certificate, "Actual certification name and new name don't match");
            Assert.That(certificationsTabPageObj.CertificateFrom.Text == certifications.From, "Actual certification provider name and new name don't match");
            Assert.That(certificationsTabPageObj.CertificateYear.Text == certifications.Year, "Actual year and new year don't match");
        }

        [TestCaseSource(typeof(CertificationWithParagraphInputSource<Certifications>))]
        public void CreateNewRecordWithParagraph(Certifications certifications)
        {
            certificationsTabPageObj.CreateNewCerticationRecord(certifications);
            certificationsTabPageObj.WaitForRecordIsVisible();

            Assert.That(certificationsTabPageObj.CertificateName.Text == certifications.Certificate, "Actual certification name and new name don't match");
            Assert.That(certificationsTabPageObj.CertificateFrom.Text == certifications.From, "Actual certification provider name and new name don't match");
            Assert.That(certificationsTabPageObj.CertificateYear.Text == certifications.Year, "Actual year and new year don't match");
        }

        [TestCaseSource(typeof(AddCertificationInputSource<Certifications>))]
        public void CreateDuplicateRecord(Certifications certifications)
        {
            certificationsTabPageObj.CreateNewCerticationRecord(certifications);
            certificationsTabPageObj.CreateNewCerticationRecord(certifications);

            messagePopUpPageObj.WaitForErrorMessage();
            Assert.That(messagePopUpPageObj.FindErrorMessagePopUp("This information is already exist.").Displayed, "Error message is not present");
        }

        [TestCaseSource(typeof(AddCertificationInputSource<Certifications>))]
        public void DeleteCertificateRecord(Certifications certifications)
        {
            certificationsTabPageObj.CreateNewCerticationRecord(certifications);
            certificationsTabPageObj.DeleteRecord();      
            Assert.That(certificationsTabPageObj.CertificationsRecord == null, "The record is present");
        }
        [TestCaseSource(typeof(EditCertificateInputSource<EditCertificate>))]
        public void EditCertificateRecord(EditCertificate certification)
        {
            certificationsTabPageObj.CreateNewCerticationRecord(certification.Original);
            certificationsTabPageObj.EditRecord(certification.Edited);

            certificationsTabPageObj.WaitForUpdateButtonStail();

            Assert.That(certificationsTabPageObj.CertificateName.Text == certification.Edited.Certificate, "Actual certification name and new name don't match");
            Assert.That(certificationsTabPageObj.CertificateFrom.Text == certification.Edited.From, "Actual certification provider name and new name don't match");
            Assert.That(certificationsTabPageObj.CertificateYear.Text == certification.Edited.Year, "Actual year and new year don't match");
        }

        [TestCaseSource(typeof(CertificationEmptyFieldSourse<CertificationEmptyField>))]
        public void AddCertificateWithoutName(CertificationEmptyField certification)
        {
            certificationsTabPageObj.CreateNewCerticationRecord(certification.Emptyname);
            var errorMessage = messagePopUpPageObj.FindErrorMessagePopUp("Please enter Certification Name, Certification From and Certification Year");
            Assert.That(errorMessage.Displayed, "Error message is not displayed");
        }

        [TestCaseSource(typeof(CertificationEmptyFieldSourse<CertificationEmptyField>))]
        public void AddCertificateWithoutProvider(CertificationEmptyField certification)
        {
            certificationsTabPageObj.CreateNewCerticationRecord(certification.Emptyprovider);
            var errorMessage = messagePopUpPageObj.FindErrorMessagePopUp("Please enter Certification Name, Certification From and Certification Year");
            Assert.That(errorMessage.Displayed, "Error message is not displayed");
        }

        [TestCaseSource(typeof(CertificationEmptyFieldSourse<CertificationEmptyField>))]
        public void AddCertificateWithoutYear(CertificationEmptyField certification)
        {
            certificationsTabPageObj.CreateNewCerticationRecord(certification.Emptyyear);
            var errorMessage = messagePopUpPageObj.FindErrorMessagePopUp("Please enter Certification Name, Certification From and Certification Year");
            Assert.That(errorMessage.Displayed, "Error message is not displayed");
        }

        [Test]
        public void CancelAddCertification()
        {
            certificationsTabPageObj.ClickAddButton();
            certificationsTabPageObj.ClickCancelAdditionButton();
            Assert.That(certificationsTabPageObj.CertificationsRecord == null, "Addition wasn't cancelled");
        }

        [TestCaseSource(typeof(AddCertificationInputSource<Certifications>))]
        public void CancelEditCertification(Certifications certification)
        {
            certificationsTabPageObj.CreateNewCerticationRecord(certification);
            certificationsTabPageObj.ClickEditButton();
            certificationsTabPageObj.ClickCuncelEditButton();
            Assert.That(certificationsTabPageObj.UpdateButton == null, "Add new button is present");
        }

        [Test]
        public void TryToDeleteNonExistantCertificateRecord()
        {
            Assert.That(certificationsTabPageObj.DeleteButton == null, "Delete button is present");
        }

        [Test]
        public void TryToEditNonExistantCertificateRecord()
        {
            Assert.That(certificationsTabPageObj.EditButton == null, "Edit button is present");
        }


        [TearDown]
        public void CloseTestRun()
        {
            reportWriter.RecordTestRunData(TestContext.CurrentContext);
            driver.Quit();
        }
    }
}

