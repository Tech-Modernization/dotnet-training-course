using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kata.CustomTypes.Charades
{
    public class CharadesGame
    {
        private List<Clue> clues;

        private List<Team> teams;

        private Scoreboard Scores = new Scoreboard();

        public CharadesGame()
        {
            var jsonText = File.ReadAllText("charades.json");
            var jobject = JObject.Parse(jsonText);
            clues = jobject["charades"].ToObject<List<Clue>>();
            teams = jobject["teams"].ToObject<List<Team>>();
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
    }
}
