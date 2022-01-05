using System;
using System.Collections.Generic;
using System.Text;

/*
 * requirements:
 * - we need to gather specific ingredients from the dish to combine and achieve the "stage"
 *   e.g. for a sauce, we'd need flour, milk, butter and whatever extra bits to make the particular
 *   sauce
 *  
 * - so that means we need access to the dish
 * - we need a method to carry out that process.  Process() seems a general enough term. 
 *   "Cook", while intuitive, might be misleading in the case of a salad dressing.  
 * 
 * - we need to know what ingredients go together, we're gonna configure the stage for preparation
 * 
 */

namespace Kata.CustomTypes.Kata.Recipe.Part15
{
    public class Stage 
    {
        public string Name { get; }
        public bool Ready { get; }
        public Stage(string name, bool ready)
        {
            Name = name;
            Ready = ready;
        }

        public override string ToString()
        {
            return $"The {Name} is {(Ready ? "" : "not")}ready";
        }

        public void Build()
        {
            throw new NotImplementedException();
        }
    }
}
