namespace DemoKata.CustomTypes
{
    public class ParityValidator : NumberValidator
    {
        private bool testForEven;

        public ParityValidator(bool argTestForEven)
        {
            testForEven = argTestForEven;
        }
        public override bool IsValid(int arg)
        {
            var isEven = arg % 2 == 0;
            // return testForEven ? isEven : !isEven;
            return (testForEven && isEven) || (!testForEven && !isEven);
        }
    }
}