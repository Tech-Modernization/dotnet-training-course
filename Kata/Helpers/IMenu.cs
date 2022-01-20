using System.Collections;
using System.Collections.Generic;

namespace Helpers
{
    public interface IMenu : IEnumerable
    {
        void Display();
        MenuSelectionItemBase SelectionItem { get; }
        List<string> ItemNames { get; }
    }
}