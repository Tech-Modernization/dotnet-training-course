using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part12
{
    public interface IDataService
    {
        string[] GetList(string dataSourceId);

        string GetContents(string dataSourceId);
    }
}
