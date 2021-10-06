namespace CustomTypes.RoomTidy
{
    public interface IRoomTidyFactory
    {
        IRoomFactory CreateRoom<T>();
    }
}