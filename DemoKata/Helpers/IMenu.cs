using System.Collections.Generic;

namespace Helpers
{
    public interface IMenu
    {
        void Display();
        List<KeyStep> Steps { get; }
    }
}