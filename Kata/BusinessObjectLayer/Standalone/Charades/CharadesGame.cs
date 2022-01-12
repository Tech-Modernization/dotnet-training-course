using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessObjectLayer.Charades
{
    public class CharadesGame : ICharadesContainer
    {
        private List<Clue> clues;

        private List<Team> teams;

        private Scoreboard Scores = new Scoreboard();

        private Dictionary<int, Team> orderOfPlay;

        private EndOfGameSettings endOfGame;

        public CharadesGame()
        {
            var jsonText = File.ReadAllText("charades.json");
            var jobject = JObject.Parse(jsonText);
            clues = jobject["charades"].ToObject<List<Clue>>();
            teams = jobject["teams"].ToObject<List<Team>>();

            orderOfPlay = new Dictionary<int, Team>();
            endOfGame = new EndOfGameSettings();
        }

        public void ShowClues()
        {
            foreach (var clue in clues)
            {
                Console.WriteLine($"{clue.Category}: {clue.Title}");
            }
        }

        public void ShowTeams()
        {
            foreach (var team in teams)
            {
                Console.WriteLine($"{team.TeamName}: {string.Join(", ", team.Players.Select(p => p.Name))}");
            }
        }

        public void Setup()
        {
            // 1. decide how to end the game
            //    a. identify relevant resources
            //       - something to store the end of game policy
            //         - what is the end of game policy?
            //           - play as many games as we can before the timer expires
            //           - play "best of n" 
            //           - play "best of n" / time limit where if best of reached
            //           before timer then the game ends
            //         - because we have 2 related things that not exclusive, it
            //           doesn't look like an enum is the right data type.  cuz an 
            //           enum is single-answer-multiple-choice kinda thing.
            //         - 2 booleans would be the best cuz it's a question of 2
            //         switches being on or off.
            //    
            //     b. whose responsibility is it to store the end of game policy?
            //
            //        - as the container, it is the Game's job to store that.
            // 
            //           (?1) boolean - we could store the policy as a bool EndOnTimerExpired.
            //                          if false it would mean end of bestof.
            //           - what are the problems with this approach?
            //             - you need intimate knowledge of the code to know that
            //             the BestOf policy is the *absence* of the timer policy
            //            
            //     c. what the implications of each?
            // 
            //        a. best-of: need to know max games
            //        b. timer: need to the max duration.
            // 
            //        whose job is it to store these?
            //
            //     d. can related items be encapsulated?
            //
            //        - we 4 data items now all related to the end of game policy.
            //        - we should encapsulate them.
            //
            // 2. decide how to establish those values
            // 
            //    - we could decide them at random of course but let's ask the user
            //    - that means console i/o so we'll extend the ConsoleHelper cuz 
            //      we're likely to want to talk to the console a lot.
            // 
            //    - it's more convenient to just be able to enter keystrokes so we'll 
            //      write somthing that will be a wrapper around Console.ReadKey().
            // 
            //    - the method will need a prompt and a list of expected keys to be pressed.
            // 
            var keyChoice = ConsoleHelper.GetKey("How do you want to end the game?  [T=timer, B=best of]: ", ConsoleKey.T, ConsoleKey.B);
            if (keyChoice == ConsoleKey.Q)
            {
                Console.WriteLine("Game aborted");
                return;
            }

            if (keyChoice == ConsoleKey.T)
            {
                endOfGame.EndOnTimerExpired = true;
                var seconds = 0;
                if (ConsoleHelper.GetInteger("Enter time limit (ss)", out seconds, new RangeValidator(5, 30)))
                {
                    endOfGame.MaxDuration = new TimeSpan(0, 0, seconds);

                }
            }

            if (keyChoice == ConsoleKey.B)
            {
                // get an odd number for the best of 
                endOfGame.EndOnBestOfLimitReached = true;
                if (!ConsoleHelper.GetInteger("Enter time limit (ss)", out endOfGame.MaxGames, new CustomValidator<int>((a) => (int) a % 2 == 0)))
                {
                    Console.WriteLine("You have to pick an odd number of games");
                    return;
                }
            }

            // 2. decide the order of play (teams)
            foreach(var team in teams)
            {

            }

        }

        public Team Play()
        {
            throw new NotImplementedException();
        }
    }
}
