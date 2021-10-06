namespace CustomTypes.RoomTidy
{
    public interface IRoomFactory
    {
        IStorageSpace CreateStorageSpace<T>() where T : IStorageSpace;
        IStorageItem CreateStorageItem<T>() where T : IStorageItem;
    }
}