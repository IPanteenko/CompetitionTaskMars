using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskMars.NUnit.InputSources
{
    internal class EducationEmptyFieldSource<T> : FileInputParamsBase<T>
    {
        protected override string FileName => "EducationInvalid";
    }
}