using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementationLayer
{
    public interface IFileDataService
    {
        List<string> GetLines(string path);
        string GetContents(string path);
        
    }
}
