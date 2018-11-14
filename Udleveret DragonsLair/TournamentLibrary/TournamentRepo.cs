using System.Collections.Generic;

namespace TournamentLib
{
    public class TournamentRepo
    {
        private List<Tournament> tournaments = new List<Tournament>();

        public Tournament GetTournament(string name)
        {
            Tournament t = new Tournament(name);
            for (int i = 0; i < tournaments.Count; i++)
            {
                if (tournaments[i] == t)
                {
                    return t;
                }
            }
            return null;
        }

        public void AddTournament(string name)
        {
            Tournament t = new Tournament(name);
            tournaments.Add(t);
        }

        public void RemoveTournament(string name)
        {
            Tournament t = new Tournament(name);
            for (int i = 0; i < tournaments.Count; i++)
            {
                if (tournaments[i] == t)
                {
                    tournaments.Remove(tournaments[i]);
                }
            }
           
        }
    }
}