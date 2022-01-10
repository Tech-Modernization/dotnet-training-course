using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part15
{
    public class FileDataService : IDataService
    {
        public string[] GetList(string dataSourceId)
        {
            try
            {
                return File.ReadAllLines(dataSourceId);
            }
            catch (Exception ex)
            {
                throw new Exception($"FileDataService.ReadAllLines({dataSourceId})", ex);
            }
        }

        public string GetContents(string dataSourceId)
        {
            try
            {
                return File.ReadAllText(dataSourceId);
            }
            catch (Exception ex)
            {
                throw new Exception($"FileDataService.GetContents({dataSourceId})", ex);
            }
        }
    }
}
