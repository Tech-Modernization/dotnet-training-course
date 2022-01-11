using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Gamependium
{
    public abstract class GameResultBase
    {
        public GameState State { get; set; }
        public T Concrete<T>() where T : GameResultBase => this as T;
    }
}
