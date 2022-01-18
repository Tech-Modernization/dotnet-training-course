using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObjectLayer.Bartender
{
    public class BarKeyStep : KeyStepBase
    {
        public BarKeyStep(int index, string promptFormat, IMenu menu, Action<ConsoleKey, int> convertKeyToData) : base(index, promptFormat, menu, convertKeyToData)
        {
        }
    }
}
