using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.RoomTidy
{
    public abstract class RoomTidyFactory : IRoomTidyFactory
    {
        public IRoomFactory CreateRoom<T>()
        {
            return null;
            //(T)typeof(T).Assembly.CreateInstance(typeof(T).FullName);
        }
    }
}
