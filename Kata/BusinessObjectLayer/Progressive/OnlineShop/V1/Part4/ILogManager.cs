namespace BusinessObjectLayer.OnlineShop.Part4
{
    public interface ILogManager
    {
        void Create(string path);
        void Write(params string[] message);
    }
}