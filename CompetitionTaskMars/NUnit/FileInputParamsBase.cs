using CompetitionTaskMars.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace CompetitionTaskMars.NUnit
{
    public class FileInputParamsBase<TTestCaseParams> : IEnumerable
    {
        protected virtual string DataFilesSubFolder => "Data";

        protected virtual string FileName => "";

        private string GetFilePath()
        {
            var directoryName = FileSystem.GetRootDirectory();

            return Path.Combine(directoryName, DataFilesSubFolder, $"{FileName}.json");
        }

        public IEnumerator GetEnumerator()
        {
            var jsonData = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(GetFilePath()));
            var genericItems = jsonData["testData"].ToObject<TTestCaseParams>();

            yield return new object[] { genericItems };
        }
    }
}
