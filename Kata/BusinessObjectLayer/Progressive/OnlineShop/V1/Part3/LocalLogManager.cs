using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessObjectLayer.OnlineShop.Part3
{
    public class LocalLogManager : ILogManager
    {
        private string logFilePath = "../../../online-shop.log";
        public void Create(string path)
        {
            logFilePath = path;
        }

        public void Write(params string[] messageList)
        {
            try
            {
                var messages = messageList.Select(msg => $"{DateTime.Now:G} - {msg}").ToList();
                File.AppendAllLines(logFilePath, messages);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now:G} - Problem writing to log file: {logFilePath}", messageList);
                throw;
            }
        }
    }
}
