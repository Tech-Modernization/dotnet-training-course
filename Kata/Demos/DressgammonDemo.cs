using System;
using System.Collections.Generic;
using System.Text;

using Kata.CustomTypes.DressgammonFactory;
using Kata.Demos;
/*
Part 1 (Easy)

Use the factory pattern to create an object hierarchy for a game of draughts or backgammon. 

The creator is the game board and the sets of pieces are the product.

Draughts has 2 sets of 12 identical pieces - one white and one black.
Backgammon has 2 set of 15 identical pieces - one white, one black and a pair of dice.

--------

Part 2 (Not too bad)

Extend your design to include a second factory pattern, allowing the set of pieces to be the creator and the individual piece to be the product.

--------

Part 3 (Not so easy)

Extend your design to include chess.  

For chess you'll need a King, Queen, 2 Bishops , 2 Knights, 2 Rooks and 8 Pawns each for black and white.  

--------

Part 4 (Pushing it)

Extend your design to include the playing area.  By default this will be an 8 x 8 grid but in the case of backgammon, 
this grid is 24 x 5.  Your design should provide for using the same playing area Property to implement either board 
so that the code referring to the playing area can be reused transparently.  

Display the boards in a rough representation of their real life arrangement, with the pieces at their starting positions.

Use your google-fu to get those starting positions if you're not familiar with the game(s) :-)

--------

Part 5 (You must be joking)

(Seriously, people, I really am joking with this one.  I'm only putting this here so I don't forget.  A bit further down the road when we're focusing on Interface Segregation, this is gonna be a good exercise :-)) 

* Write an interface to manage playing each game.

* Establish the commonality between your interfaces and segregate them into their abstract functions.  

*/

namespace Kata.Demos
{
    public class DressgammonDemo : IDemo
    {
        public void Run()
        {
            var game = new DraughtsGame();
            game.Display();
        }
    }
}
