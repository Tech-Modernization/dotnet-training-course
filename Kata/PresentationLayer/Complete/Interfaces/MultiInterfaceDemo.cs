using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class MultiInterfaceDemo : DemoBase
    {
        public override void Run()
        {
            AddPart(Part1, "Show implementation of multiple interfaces");
        }

        public void Part1()
        {

        }
    }

    public interface ICatcher
    {
        bool CatchBall(BallBase ball);
    }

    public interface IThrower
    {
        bool ThrowBall(BallBase ball);
    }

    public interface IHitter
    {
        int HitBall(BallBase ball);
    }

    public abstract class BallBase
    {
        public string Name;
    }
    public class BaseBall : BallBase
    { }
    public class CricketBall : BallBase
    {

    }
    public class TennisBall : BallBase
    {

    }

    public class RugbyBall : BallBase
    { }

    public class Bowler : IThrower
    {
        public bool ThrowBall(BallBase ball)
        {
            throw new NotImplementedException();
        }
    }

    public class Pitcher : IThrower
    {
        public bool ThrowBall(BallBase ball)
        {
            throw new NotImplementedException();
        }
    }

    public class WicketKeeper : ICatcher
    {
        public bool CatchBall(BallBase ball)
        {
            throw new NotImplementedException();
        }
    }

    public class Catcher : ICatcher
    {
        public bool CatchBall(BallBase ball)
        {
            throw new NotImplementedException();
        }
    }

    public class FirstBase : ICatcher, IThrower
    {
        public bool ThrowBall(BallBase ball)
        {
            throw new NotImplementedException();
        }

        public bool CatchBall(BallBase ball)
        {
            throw new NotImplementedException();
        }
    }
    public class RugbyPlayer : ICatcher, IThrower
    {
        private bool hasBall;
        public bool ThrowBall(BallBase ball)
        {
            throw new NotImplementedException();
        }

        public bool CatchBall(BallBase ball)
        {
            throw new NotImplementedException();
        }
    }

}
