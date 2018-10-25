using System;
using System.Collections.Generic;
using System.Linq;
using TournamentLib;

namespace DragonsLair
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();
        private Round round = new Round();
        public List<Team> ShowWinner = new List<Team>();
        public void ShowScore(string tournamentName)
        {
            Tournament t = tournamentRepository.GetTournament(tournamentName);
            Team[] teams = t.GetTeams().ToArray();
            int[] scores = new int[teams.Length];       

            for (int i = 0; i < t.GetNumberOfRounds(); i++)
            {
                Round currentRound = t.GetRound(i);
                List<Team> winningTeams = currentRound.GetWinningTeams();
                for (int teami = 0; teami < teams.Length; teami++)
                {
                    for (int winningTeami = 0; winningTeami < winningTeams.Count; winningTeami++)
                    {
                        if (teams[teami].Name == winningTeams[winningTeami].Name)
                        {
                            scores[teami]++;
                        }
                    }
                }
            }

            for (int number = scores.Max(); number >= 0; number--)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    if (scores[i] == number)
                    {
                        Console.WriteLine("Team: " + teams[i].Name + " Has: " + scores[i] + " Points");
                    }
                }
            }

           
            Console.ReadLine();
        }

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            // Do not implement this method
        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }
    }
}
