using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Demo.Distractions
{
    public interface IDistractor
    {
        DistractionResult Distract(int currentTask, TimeSpan taskStartTime);
    }
}
