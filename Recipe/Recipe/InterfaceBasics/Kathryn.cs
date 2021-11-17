using System;


namespace Recipe.InterfaceBasics
{
    // 2. Kathryn gets the job, and this class is then created to reperesent 
    //    her "implementation" of being a policy advisor.
    //
    //    so, by using an interface, none of the required actions is missed out 
    //    and "kathryn" knows exactly what's expected of her.

    public class Kathryn : IPolicyAdvisor
    {
        public void AnswerPhone()
        {
            Console.WriteLine("Hello, Royal London, Kathryn speaking, how can i help?");
        }

        public void AddNewCustomer()
        {
            Console.WriteLine("I'll get a quote for you now.");
        }

        public void LookupPolicy()
        {
            Console.WriteLine("Can I have your policy number please");
        }
    }
}
