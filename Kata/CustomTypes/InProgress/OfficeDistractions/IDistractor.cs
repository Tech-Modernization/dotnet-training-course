using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.OfficeDistractions
{
    public interface IDistractor
    {
        DistractionResult Distract(int taskId, TimeSpan timeOfDay);
    }
}
