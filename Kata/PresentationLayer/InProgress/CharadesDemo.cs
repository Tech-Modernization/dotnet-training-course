using Kata.CustomTypes.Charades;

using System;
using System.Collections.Generic;
using System.Text;

// Part A - Analysis
//
// 1. think about each concept in turn and tell its story
// 2. identify abstract ideas to combine details 
// 3. assess impact of events in story (always ask "what if")
// 4. evaluate ideas in ascending order of complexity
// 5. identify all the possible implications of each objective 
//
// Part B - Enrichment
// 
// 6. identify the data items for each concept
// 7. identify the process for resolving the unknowns
// 

/*
 * objectives:
 * - the game is played with 2 or more teams of up to 4 players
 * - each team takes a turn to mime the charade for the other teams to guess
 * - the result of each round is determined by the timer having expired 
     or a correct guess being made (decided at random)
 * - the charade is determined at random from a list of songs, films, tv shows, books, plays
 * - a point is scored to the guessing team or the performing team depending on the result
 * - the game has a time limit advanced by the duration of each round 
 * - the winner is the one with the most points (duh)
 */

/* 1. concepts
 *    - game thing
 *      - team order 
 *    - team thing
 *      - player thing
 *        - player role thing
 *      - player order
 *    - category thing
 *      - title thing
 *    - scoreboard thing
 *      - points per team
 *    - time thing
 *    - round thing
 *      - category/title
 *      - time limit
 *      - performer 
 *      
 * 2. abstract ideas
 * 
 *    see 1.
 * 
 * 3. problem order
 *      - category/title 
 *      - player
 *      - team
 *      - scoreboard
 *      - order of play
 *      - game
 *        - timer
 *        - round 
 *          - timer
 *      
 * Z. possible extensions
 *    - point stealing 
 *      (only the performing team can guess and if timer expires, other teams can guess)
 *    - give the players a choice of whether to timebox the game or play to a max or "best of" point limit
 *      
 */
namespace Kata.Demos.Kata
{
    public class CharadesDemo : DemoBase
    {
        private CharadesGame game;
        public override void Run()
        {
            AddPart(Part1, "set up charades db");
            AddPart(Part2, "set up teams db");
            base.Run();
        }
           
        public void Part1()
        {
            game = new CharadesGame();
            game.ShowClues();
        }
        public void Part2()
        {
            game.ShowTeams();
        }
    }
}
