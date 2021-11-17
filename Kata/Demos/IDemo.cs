using System;

namespace Kata.Demos
{
    public interface IDemo
    {
        void Run();
        void AddPart(Action partMethod, string title);
    }
}
