using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.OnlineShop.Part6
{
    public interface IFileDataService
    {
        List<string> GetLines(string path);
        string GetContents(string path);
        
    }
}
