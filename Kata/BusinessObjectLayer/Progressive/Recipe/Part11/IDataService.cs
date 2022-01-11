using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part11
{
    public interface IDataService
    {
        string[] GetList(string dataSourceId);

        string GetContents(string dataSourceId);
    }
}
