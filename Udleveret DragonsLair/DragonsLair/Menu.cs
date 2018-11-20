using System;

namespace DragonsLair
{
    public class Menu
    {
        private Controller control = new Controller();
        
        public void Show()
        {
            bool running = true;
            do
            {
                ShowMenu();
                string choice = GetUserChoice();
                switch (choice)
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        ShowScore();
                        break;
                    case "2":
                        ScheduleNewRound();
                        break;
                    case "3":
                        SaveMatch();
                        break;
                    case "4":
                        CreateTournament();
                        break;
                    case "5":
                        DeleteTournament();
                        break;
                    case "6":
                        ShowTournaments();
                        break;
                    case "7":
                        AddTeamToTournament();
                        break;
                    case "8":
                        RemoveTeamFromTournament();
                        break;
                    case "9":
                        ShowTeamsFromTournament();
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg.");
                        Console.ReadLine();
                        break;
                }
            } while (running);
        }

        private void ShowMenu()
        {
            Console.WriteLine("Dragons Lair");
            Console.WriteLine();
            Console.WriteLine("1. Præsenter turneringsstilling");
            Console.WriteLine("2. Planlæg runde i turnering");
            Console.WriteLine("3. Registrér afviklet kamp");
            Console.WriteLine("4. Opret turnering");
            Console.WriteLine("5. Slet turnering");
            Console.WriteLine("6. Vis registreret turneringer");
            Console.WriteLine("7. Tilføj hold til turnering");
            Console.WriteLine("8. Slet hold fra turnering");
            Console.WriteLine("9. Vis hold fra turnering");
            Console.WriteLine("");
            Console.WriteLine("0. Exit");
        }

        

        private string GetUserChoice()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }

        private void ShowTeamsFromTournament()
        {
            Console.WriteLine();
            Console.Write("Indtast navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Clear();
            control.ShowTeams(tournamentName);
        }

        private void AddTeamToTournament()
        {
            Console.WriteLine();
            Console.Write("Indtast navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.WriteLine("Indtast navn på hold: ");
            string teamName = Console.ReadLine();
            Console.Clear();
            control.AddTeamToTournament(tournamentName, teamName);
        }

        private void RemoveTeamFromTournament()
        {
            Console.WriteLine();
            Console.Write("Indtast navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.WriteLine("Indtast navn på hold: ");
            string teamName = Console.ReadLine();
            Console.Clear();
            control.RemoveTeamFromTournament(tournamentName, teamName);
        }

        private void ShowTournaments()
        {
            Console.Clear();
            control.ShowTournaments();
        }

        private void CreateTournament()
        {
            Console.WriteLine();
            Console.Write("Indtast navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Clear();
            control.CreateTournament(tournamentName);
        }

        private void DeleteTournament()
        {
            Console.WriteLine();
            Console.Write("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Clear();
            control.DeleteTournament(tournamentName);
        }

        private void ShowScore()
        {
            Console.Write("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Clear();
            control.ShowScore(tournamentName);
        }

        private void ScheduleNewRound()
        {
            Console.Write("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Clear();
            control.ScheduleNewRound(tournamentName);
        }

        
        private void SaveMatch()
        {
            Console.Write("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Write("Angiv runde: ");
            int round = int.Parse(Console.ReadLine());
            Console.Write("Angiv vinderhold: ");
            string winner = Console.ReadLine();
            Console.Clear();
            control.SaveMatch(tournamentName, round, winner);
        }   

        
    }
}