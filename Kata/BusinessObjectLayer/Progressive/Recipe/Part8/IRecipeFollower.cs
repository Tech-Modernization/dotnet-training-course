using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part8
{
    public interface IRecipeFollower<T>
    {
        void Follow();
    }
}
