using CompetitionTaskMars.Utilities;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Listener.Entity;

namespace CompetitionTaskMars.Reports
{
    internal class DefaultReporter
    {
        const string defaultReportsFolder = "Reports";
        const string defaultReportsFilename = "TestRunReort";

        public IObserver<ReportEntity> GetDefaultReporter()
        {
            FileSystem.CreateDirectory(defaultReportsFolder);
            return new ExtentSparkReporter($"{FileSystem.GetRootDirectory()}\\{defaultReportsFolder}\\{defaultReportsFilename}.html");
        }
    }
}
