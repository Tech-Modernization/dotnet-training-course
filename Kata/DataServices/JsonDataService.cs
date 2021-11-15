using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Newtonsoft.Json;


namespace Kata.DataServices
{
    public class JsonDataService : IDataService
    {
        public T LoadDictionary<T>(string dictionarySource)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(dictionarySource));
        }
    }
}
