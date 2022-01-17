using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    public class SolidReport : IEnumerable
    {
        public string File { get; }
        public List<SolidResult> Items { get; }
        private ISolidCheckProvider checkProvider;
        public SolidReport(ISolidCheckProvider checkProvider)
        {
            this.checkProvider = checkProvider;
            Items = new List<SolidResult>(); 
        }

        public void AddItem(SolidResult result)
        {
            Items.Add(result);
        }

        public IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public override string ToString()
        {
            var cleanTypes = Items.Count(i => !i.Checks.Any(c => c.Status != SolidSeverity.Pass));
            var advisories = Items.Count(i => !i.Checks.Any(c => c.Status== SolidSeverity.Indicator));
            var violations = Items.Count(i => !i.Checks.Any(c => c.Status == SolidSeverity.Violation));
            var sb = new StringBuilder();
            sb.AppendLine($"Clean types: {cleanTypes} / {Items.Count} ({cleanTypes * 100 / Items.Count}%)");
            sb.AppendLine($"Advisories: {advisories} / {Items.Count} ({advisories * 100 / Items.Count}%)");
            sb.AppendLine($"Violations: {violations} / {Items.Count} ({violations * 100 / Items.Count}%)");
            return sb.ToString();
        }

    }
}