using Core.Entities;
using Services.Exceptions;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MatchService : IMatchService
    {
        public List<Match> GenerateMatches(List<Team>? teams)
        {
            int numTeams = teams.Count == null ? 0 : teams.Count;

            if (numTeams <= 1) 
            {
                throw new BadRequestException("Number of teams must be greater than 1");
            }

            if (numTeams % 2 == 1)
            {
                throw new BadRequestException("Number of teams must be an even number");
            }

            Shuffle(teams);

            // Initialize list of matches (empty for round 1)
            List<Match> matches = new List<Match>();

            for (int round = 1; round <= (int)Math.Ceiling(Math.Log2(numTeams)); round++)
            {
                // Calculate number of matches for this round
                int numMatches = (int)Math.Pow(2, (int)Math.Ceiling(Math.Log2(numTeams)) - round);

                // Generate matches for this round
                for (int match = 1; match <= numMatches; match++)
                {
                    int team1Index = (match - 1) * 2;
                    int team2Index = team1Index + 1;

                    // Check if teams exist for this match
                    Team team1 = null;
                    Team team2 = null;

                    if (team1Index < teams.Count)
                    {
                        team1 = teams[team1Index];
                    }
                    if (team2Index < teams.Count)
                    {
                        team2 = teams[team2Index];
                    }

                    matches.Add(new Match
                    {
                        Round = round,
                        Team1 = team1,
                        Team2 = team2
                    });
                }
            }

            return matches.Where(x => x.Round == 1).ToList();
        }

        private void Shuffle<T>(List<T> list)
        {
            // Implement a Fisher-Yates shuffle algorithm for randomness
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
