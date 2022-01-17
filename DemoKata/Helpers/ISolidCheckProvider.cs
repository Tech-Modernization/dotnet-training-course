using System.Collections;

namespace Helpers
{
    public interface ISolidCheckProvider : IEnumerable
    {
        SolidCheck this[SolidCheckItem item] { get; }
    }
}