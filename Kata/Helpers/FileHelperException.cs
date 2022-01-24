using System;
using System.Runtime.Serialization;

namespace Helpers
{
    [Serializable]
    public class FileHelperException : Exception
    {
        private const string msgText = "FileHelper.ImportJson failed with:";
        public FileHelperException() : base(msgText)
        {
            
        }

        public FileHelperException(Exception innerException) : base(msgText, innerException)
        {
        }

        public FileHelperException(string message) : base(message)
        {
        }

        public FileHelperException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileHelperException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}