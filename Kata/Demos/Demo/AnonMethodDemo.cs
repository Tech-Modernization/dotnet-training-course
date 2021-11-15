using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Demos
{
    public class AnonMethodDemo : DemoBase
    {
        public void DoSomething()
        {
            dbg("doing something");
        }

        public string Do2()
        {
            return "doing something";
        }

        public string Do3(string source)
        {
            return source.ToUpper();
        }
        public override void Run()
        {
            // methods
            // 1. a method is a section of code enclosed in { } and given a name.
            //    this section of code is called the method body.
            // e.g. see DoSomething() above
            DoSomething();

            // 2. a method can return a value.  see Do2 above
            var returnValue = Do2();
            dbg(returnValue);

            // 3. a method can have parameters.  see do3 above
            returnValue = Do3("all lower case");
            dbg(returnValue);

            // variables
            // 1. a variable is declared in 3 sections.
            //   a. the type
            //   b. the name 
            //   c. the value
            //
         //  a.    b.     c.
            int number = 12;

            // 2. a variable declaration always ends with a semi-colon;
            string name = "paul";
            List<string> names = new List<string>() { "Paul", "Ross", "Lewis" }; // <<< semi colon after curly bracket

            // anonymous methods
            //
            // 1. anonymous methods are a TYPE.  you declare variables to hold the body of the method.
            
            Action anonDoSomething;         
            // note there is no part (c)  - no value assigned.
            // but the declaration still ends with a semi-colon;
            Func<bool> anonDoSomethingElse;

            // 2. anonymous methods are just like formal methods in that:
            // 2.1. they enclose a section of code (or method body) between curly brackets
            Action voidNoParams = () => 
            {
                Console.WriteLine("Did something");
            };

            // 2.2 notice the "=>" above.   there is an extra part to the variable declaration 
            //     when the type is "method".
            // a.  the type
            // b.  the name
            // c.  the parameters
            // d.  the value (i.e. the method body)

            //a.              b.               c.
            Action<string> voidStringParam = (stringArg) =>
            // d.
            {
                Console.WriteLine(stringArg);
            };

            // 2.3 just as the initialiser for a normal variable is separated or indicated by an equals sign
            //
            //        var x = 12;
            //    
            //     so the body of an anonymous method is separated from/indicated by the arrow operator (=>)
            // 
            // e.g. the following anonymous method has not been initialised
            Action<int> voidIntParam;
            // this one has...
            Action<int> voidMethodwithIntParam = (intParam) =>
            {
                for (var i = 0; i < intParam; i++)
                    dbg(i);
            };

            // 3. anonymous methods are called in exactly the same way as normal methods
            // compare this formal method call to the method at the top.

            DoSomething();
            // ...with its anonymous version voidNoParams, which also takes no parameters, returns nothing 
            // and simple writes a message to the console.
            voidNoParams();

            // 4. anonymous methods can take parameters (see above and also...)
            Action<int, string, List<decimal>> voidWith3Params = (number, name, listOfPrices) => 
            {
                dbg($"Item {number} - Our {name}s \n    {string.Join("\n    ", listOfPrices.Select(d => d.ToString("C")))}");
            };

            voidWith3Params(22, "beer", new List<decimal> { 2.3M, 3.3M, 4.5M, 9.5M });

            // 5. anonymous methods can return values.  they do that with the Func keyword
            //a.            b.             c.
            Func<string> returnSomething = () =>
            // d.
            {
                return "returned something";
            };

            // Func is performing the same function as Action in that it is declaring a Method type.
            //
            // 5.1  the type of the return value is specified as the last generic type parameter.
            //
            Func<int> returnsIntNoParams = () =>
            {
                return 42;
            };
            var forty2 = returnsIntNoParams();

            Func<string, int> returnsIntWithStringParam = stringArg =>
            {
                return int.Parse(stringArg);
            };
            var str42 = returnsIntWithStringParam("42");

            Func<int, int, string> returnsStringwith2IntParams = (intArg1, intArg2) =>
            {
                return $"{intArg1} + {intArg2} = {intArg1 + intArg2}";
            };
            var sum42 = returnsStringwith2IntParams(20, 22);

            // 6. anonymous methods can be arguments to other methods
            //
            // 6.1 normal methods have variable declarations as their parameters.
            //
            // e.g.
            //                         a.      b.           c.      a.      b.        c.
            //        void MethodName(Type  variableName = value, Type2  variable2 = value2);
            //                          a.    b.     c.    a.    b.     c.      a.      b.      c.
            //         void DoSomething(int number = 12, string name = "paul", decimal price = 3.4M);
            //
            // 6.2. so if an anonymous method is a Type, then it can be passed as a parameter to another method.
            //
            VoidNoParams(() =>
            {
                Console.WriteLine("I'm in voidMethodWithNoParams");
                Console.WriteLine("Whoopee!");
            });

            // 6.3.  it's the same with Func
            var sumAnon = ReturnsStringWith2IntParams((intArg1, intArg2) =>
            {
                return $"{intArg1} + {intArg2} = {intArg1 + intArg2}";
            });

            // 7. Actions and Funcs with only one line can be abbreviated so that you can miss out the { }
            // 7.1. in the case of Func, that also means you can omit "return".
            // 
            // e.g.
            voidWith3Params = (number, name, listOfPrices) => dbg($"Item {number} - Our {name}s \n    {string.Join("\n    ", listOfPrices.Select(d => d.ToString("C")))}");
            voidWith3Params(78, "eddie", new List<decimal> { 222M, 44.4M, 349834589.33M });

            returnsStringwith2IntParams = (intArg1, intArg2) => $"{intArg1} + {intArg2} = {intArg1 + intArg2}";
            var v110 = returnsStringwith2IntParams(43, 67);

            List<Func<int>> steps;
        }

        public string ReturnsStringWith2IntParams(Func<int, int, string> returnsStringwith2IntParams)
        {
            Console.WriteLine("Calling the method...");
            return returnsStringwith2IntParams(20, 22);
        }

        public void VoidNoParams(Action voidMethodWithNoParams)
        {
            Console.WriteLine("Calling the method...");
            voidMethodWithNoParams();
        }

        public void ListOfAction(params Action<string>[] actions)
        {
            var actionNumber = 1;
            foreach (var a in actions)
            {
                a($"Doing action number {actionNumber}");
                    
            }
        }
    }
}
