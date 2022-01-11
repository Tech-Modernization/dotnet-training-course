using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part9
{
    public interface IRecipeFollower<T>
    {
        void Follow();
    }
}
