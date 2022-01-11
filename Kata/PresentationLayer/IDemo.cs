using System;

namespace PresentationLayer
{
    public interface IDemo
    {
        void Run();
        void AddPart(Action partMethod, string title);
    }
}
