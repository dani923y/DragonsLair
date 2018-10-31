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
        public List<Team> teams = new List<Team>();
        public void ShowScore(string tournamentName)
        {

            Tournament t = tournamentRepository.GetTournament(tournamentName);
            t.SetupTestRounds();
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

        public TournamentRepo GetTournamentRepository()
        {
            return tournamentRepository;
        }



        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {

            Tournament t = tournamentRepository.GetTournament(tournamentName);
            int numberOfRounds = t.GetNumberOfRounds();
            Round lastRound = new Round();
            bool isRoundFinished;
            t.SetupTestRounds();

            

            if(numberOfRounds == 0)
            {
                lastRound = null;
                isRoundFinished = true;
            }
            else
            {
                lastRound = t.GetRound(numberOfRounds - 1);
                isRoundFinished = lastRound.IsMatchesFinished();
            }

            if(isRoundFinished == true)
            {
                if(lastRound == null)
                {
                    teams = t.GetTeams();
                }
                else
                {
                    teams = lastRound.GetWinningTeams();
                    if(lastRound.FreeRider != null)
                    {
                        teams.Add(lastRound.FreeRider);
                    }
                }
                if(teams.Count >= 2)
                {
                    Round newRound = new Round();
                    Team oldFreeRider;
                    Team newFreeRider = null;
                    List<Team> scrambled = ScrambleTeamsRandomly(teams);
                    if(scrambled.Count % 2 == 1)
                    {
                        if(numberOfRounds > 0)
                        {
                             oldFreeRider = lastRound.FreeRider;
                        }
                        else
                        {
                              oldFreeRider = null;
                        }
                        foreach (Team scrambledTeam in scrambled)
                        {
                            if(scrambledTeam != oldFreeRider)
                            {
                                newFreeRider = scrambledTeam;
                                break;
                            }
                        }
                        newRound.FreeRider = newFreeRider;
                        scrambled.Remove(newFreeRider);
                    }
                    for (int i = 0; i < scrambled.Count; i+=2)
                    {
                        Match match = new Match();
                        match.FirstOpponent = scrambled[i];
                        match.SecondOpponent = scrambled[i + 1];
                        newRound.AddMatch(match);
                    }
                    t.AddRound(newRound);

                    Console.Write(
                    "0--------------------------------------------0",
                    "|           Turnering: VINTER TURNERING      |",
                    "|                   Runde 2                  |",
                    "|                  (4 kampe)                 |",
                    "|--------------------------------------------0",
                    "|             1.The Cretans - The Cnideans   |",
                    "|             2.The Valyrians - The Megareans|",
                    "|             3.The Spartans - Thereas       |",
                    "|             4.The Corinthians - The Coans  |",
                    "0--------------------------------------------0"
                        );

                }
                else
                {
                    throw new Exception("Error Tournament Is Finished!");
                }
            }
            else
            {
                throw new Exception("Error round not finished!");
            }

        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }

        private List<Team> ScrambleTeamsRandomly(List<Team> teams)
        {
            Random random = new Random();
            List<Team> t = teams.ToList();
            t = t.OrderBy(x => random.Next()).ToList();

            return t;
        }
    }
}
