using System.Collections.Generic;

namespace CustomTypes.RoomTidy
{
    public class StorageGroup
    {
        public string Name = "Wardrobe";
        public List<IStorageSpace> Spaces;
        public StorageGroup(params StorageGroupCapacity[] capacities)
        {

        }
    }
}
