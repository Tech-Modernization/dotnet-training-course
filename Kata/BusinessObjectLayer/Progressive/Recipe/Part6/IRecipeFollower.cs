using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part6
{
    public interface IRecipeFollower<T>
    {
        void Follow();
    }
}
