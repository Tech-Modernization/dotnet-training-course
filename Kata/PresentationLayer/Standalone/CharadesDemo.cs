using BusinessObjectLayer.Charades;

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
// 8. figure out how to approach each problem
// 
//    a. identify the relevant resources - which objects/variables are potentially
//    involved as either inputs or outputs of the solution.
//       
//       * for order of play, we are determining what order the teams are gonna be in 
//       in the loop.
//
//       * an order is basically a sequence, so we need a sequence number.
//
//       * so it follows that each team needs a sequence number.
//
//    b. check SOLID principles
//
//       * identify the responsibility of each class you create 
//
//         Player - encapsulate the player name and their role in the game
//         Clue - encapsulate the clue title and its category
//         Team - encapsulate the team name and the players in it
//         Category - encapsulate the category list
//         Scoreboard - encapsulate the score per team
//         Game - encapsulate the game play process; i.e. be the container of operations
//
//       ? ask whose responsibility it is to store/do X 
//       * whose job is it to store the sequence number?
// 
//         - Player: no - altho the order of the players in the team is a factor
//         - Clue: no - the clue is unrelated
//         - Team: no - altho this is probably where the player order should be stored
//         - Category: no - unrelated
//         - Scoreboard: no - unrelated
//         - Game: yes - as the container of operations, the game should manage the order of play
//         
//       * the Game needs a means of associating a sequence number with a team.
//
// 
//          

/*
 * objectives:
 * - the game is played with 2 or more teams of up to 4 players
 *   - need to police number of players
 *   - need to police number of teams 
 * - each team takes a turn to mime the charade for the other teams to guess
 *   - loop thru list of teams
 *     - identify the mimer in the next team
 *     - assign mimer a clue
 *     - start timer
 *     - decide at random if mimer's team guessed it
 *     - if not decide another random team and make a random decision.
 *     - assign the point if someone got it
 *     
 * - the result of each round is determined by the timer having expired 
     or a correct guess being made (decided at random)
 * - the charade is determined at random from a list of songs, films, tv shows, books, plays
 * - a point is scored to the guessing team or the performing team depending on the result
 * - the game has a time limit advanced by the duration of each round 
 *   - set an outer timer as well
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
namespace PresentationLayer.Kata
{
    public class CharadesDemo : DemoBase
    {
        private CharadesGame game;
        public override void Run()
        {
            AddPart(Part1, "set up charades db");
            AddPart(Part2, "set up teams db");
            AddPart(Part3, "establish order of play and the conclusion policy");
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

        public void Part3()
        {
            game.Setup();
        }
    }
}
