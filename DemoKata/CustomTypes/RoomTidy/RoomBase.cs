using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.RoomTidy
{
    public abstract class RoomBase : IRoomFactory
    {
        public IStorageItem CreateStorageItem<T>() where T : IStorageItem
        {
            return (T) typeof(T).Assembly.CreateInstance(typeof(T).FullName);
        }

        public IStorageSpace CreateStorageSpace<T>() where T : IStorageSpace
        {
            return (T)typeof(T).Assembly.CreateInstance(typeof(T).FullName);
        }
    }
}
