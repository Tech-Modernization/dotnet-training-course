using System;

namespace CustomTypes.RoomTidy
{
    public abstract class StorageSpace : IStorageSpace
    {
        public StorageDimensions Dimensions;

        public decimal GetCapacity()
        {
            throw new NotImplementedException();
        }

        public decimal GetCapacityFor<T>() where T : IDimensions
        {
            throw new NotImplementedException();
        }

        public decimal GetSpacesFor<T>() where T : IDimensions
        {
            throw new NotImplementedException();
        }
    }
}
