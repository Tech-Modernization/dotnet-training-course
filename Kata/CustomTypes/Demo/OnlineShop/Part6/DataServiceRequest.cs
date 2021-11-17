using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.OnlineShop.Part6
{
    public class DataServiceRequest<T>
    {
        public string FileName;
        public string ConnectionString;
        public string ApiUrl;
        public Action<T, List<string>> Populate;
    }
}
