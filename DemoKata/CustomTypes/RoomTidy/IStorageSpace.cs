using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.RoomTidy
{
    public interface IStorageSpace
    {
        decimal GetCapacity();
        decimal GetCapacityFor<T>() where T : IDimensions;
        decimal GetSpacesFor<T>() where T : IDimensions;
    }
}
