namespace CustomTypes.OnlineShop.Part3
{
    public interface ILogManager
    {
        void Create(string path);
        void Write(params string[] message);
    }
}