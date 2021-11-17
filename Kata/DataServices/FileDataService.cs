using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kata.DataServices
{
    public class FileDataService : IFileDataService
    {
        public FileDataService()
        {

        }
        public List<string> GetLines(string path)
        {
            try
            {
                return File.ReadAllLines(path).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"FileDataService.ReadAllLines({path})", ex);
            }
        }

        public string GetContents(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                throw new Exception($"FileDataService.GetContents({path})", ex);
            }
        }
    }
}
