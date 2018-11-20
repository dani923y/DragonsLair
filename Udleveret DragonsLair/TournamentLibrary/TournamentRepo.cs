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
                if (tournaments[i].Name == t.Name)
                {
                    return tournaments[i];
                }
            }
            return null;
        }

        public List<Tournament> ShowTournaments()
        {
            return tournaments;
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
                if (tournaments[i].Name == t.Name)
                {
                    tournaments.Remove(tournaments[i]);
                }
            }
           
        }
    }
}