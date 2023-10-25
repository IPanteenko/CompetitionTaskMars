namespace CompetitionTaskMars.NUnit.InputSources
{
    internal class CreateWithSameNameSource<T> : FileInputParamsBase<T>
    {
        protected override string FileName => "CreateWithSameName";
    }
}