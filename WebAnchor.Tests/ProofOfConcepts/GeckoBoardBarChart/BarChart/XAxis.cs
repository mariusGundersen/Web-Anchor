using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WebAnchor.Tests.ProofOfConcepts.GeckoBoardBarChart.BarChart
{
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Because we want to test that web anchor works with inconsistent naming.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Because we want to test that web anchor works with inconsistent naming.")]
    public class XAxis
    {
        public List<string> labels { get; set; }
        public string type { get; set; }
    }
}