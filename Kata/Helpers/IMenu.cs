using System.Collections;

namespace Helpers
{
    public interface IMenu : IEnumerable
    {
        void Display();
        MenuSelectionItemBase SelectionItem { get; }
    }
}