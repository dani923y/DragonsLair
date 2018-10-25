﻿using System.Collections.Generic;

namespace TournamentLib
{
    public class Round
    {
        private List<Match> matches = new List<Match>();
        
        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            // TODO: Implement this method
            return null;
        }

        public bool IsMatchesFinished()
        {
            // TODO: Implement this method
            foreach (var item in matches)
            {
                if (item.Winner == null)
                {
                    return false;
                }

            }

            return true;
        }

        public List<Team> GetWinningTeams()
        {
            List<Team> WinningTeams = new List<Team>();

           
             for (int i = 0; i < matches.Count; i++)
             {
                    WinningTeams.Add(matches[i].Winner);
             }
            
            return WinningTeams;
        }

        public List<Team> GetLosingTeams()
        {
            List<Team> LosingTeams = new List<Team>();

            foreach(var item in matches)
            {
                if(item.Winner == item.FirstOpponent)
                {
                    LosingTeams.Add(item.SecondOpponent);
                }
                else
                {
                    LosingTeams.Add(item.FirstOpponent);
                }
            }
            return LosingTeams;
        }
    }
}