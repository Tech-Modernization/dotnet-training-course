using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.OfficeDistractions
{
    public interface IDistractor
    {
        DistractionResult Distract(int taskId, TimeSpan timeOfDay);
    }
}
