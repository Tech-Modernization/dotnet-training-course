using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe
{
    public interface IRecipeFollower<T>
    {
        void Follow();
        Stage Process(Func<Ingredient[], Stage> process, params Ingredient[] ingredients);
    }
}
