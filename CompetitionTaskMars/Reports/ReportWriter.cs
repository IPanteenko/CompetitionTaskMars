using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace CompetitionTaskMars.Reports
{
    internal class ReportWriter
    {
        readonly ExtentReports reports;
        protected ScreenshotTaker screenshotTaker;
        protected ExtentTest test { get; set; }


        public ReportWriter()
        {
            reports = new ExtentReports();
            reports.AttachReporter(new DefaultReporter().GetDefaultReporter());
        }

        public void FinaliseReport()
        {
            reports.Flush();
        }

        public void AddScreenshotTaker(IWebDriver driver)
        {
            screenshotTaker = new ScreenshotTaker(driver);
        }

        public void InitialiseTestRun(string reportName)
        {
            test = reports.CreateTest(reportName);
        }

        public void RecordTestRunData(TestContext context)
        {
            var status = context.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(context.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", context.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);

            if (screenshotTaker != null)
            {
                var screenshotPath = screenshotTaker.TakeScreenshot();
                test.AddScreenCaptureFromPath(screenshotPath);
            }

            FinaliseReport();
        }
    }
}
