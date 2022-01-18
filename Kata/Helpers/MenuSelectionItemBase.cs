using System;

namespace Helpers
{
    // resp: encapsulate the app-specific data represented by the menu choices
    public abstract class MenuSelectionItemBase 
    {
        public abstract bool IsComplete { get; }
    }
}