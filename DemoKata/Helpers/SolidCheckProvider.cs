using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public class SolidCheckProvider : ISolidCheckProvider
    {
        private List<SolidCheck> checks;
        public SolidCheck this[SolidCheckItem item] => checks.SingleOrDefault(check => check.Item == item);

        public SolidCheckProvider(string path)
        {
           // checks = JsonHelper.LoadAs<List<SolidCheck>>(path, "checklist");
        }
        public IEnumerator GetEnumerator()
        {
            return checks.GetEnumerator();
        }
    }
}
