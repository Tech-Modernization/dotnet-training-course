namespace DemoKata.CustomTypes
{
    public interface IValidator
    {
        void Attach<T>(ValidatorBase<T> nextValidator);

        /* Chain Of Responsibility -> ValidatorBase
         * 
         *         protected IValidator Next;
        public void Attach<T1>(ValidatorBase<T1> nextValidator)
        {
            throw new System.NotImplementedException();
        }
        */
    }
}
