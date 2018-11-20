using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TournamentLib;
using DragonsLair;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        Controller controller;
        TournamentRepo currentRepo;
        Tournament currentTournament;
        
  

        [TestInitialize]
        public void SetupForTest()
        {
            controller = new Controller();
            currentRepo = controller.GetTournamentRepository();
            controller.CreateTournament("Daniels Turnering");
            controller.CreateTournament("Vinter Turnering");
            currentTournament = currentRepo.GetTournament("Daniels Turnering");
            currentTournament.AddTeam("Daniel");  // Setup test teams
            currentTournament.AddTeam("Muslim");  // Setup test teams
            currentTournament.AddTeam("Ricky");  // Setup test teams
            currentTournament.AddTeam("Frank");  // Setup test teams

        }

        [TestMethod]
        public void TestCreateTournament()
        {
            controller.CreateTournament("Påske Turnering");
            Assert.AreEqual(3, currentRepo.ShowTournaments().Count);
        }

        [TestMethod]
        public void TestDeleteTournament()
        {
            controller.DeleteTournament("Vinter Turnering");
            Assert.AreEqual(1, currentRepo.ShowTournaments().Count);
        }

        [TestMethod]
        public void TestAddTeamToTournament()
        {
            currentTournament.AddTeam("Pokemon");
            Assert.AreEqual(5, currentTournament.GetTeams().Count);
        }

        [TestMethod]
        public void TestDeleteTeamFromTournament()
        {
            currentTournament.RemoveTeam("Muslim");
            Assert.AreEqual(3, currentTournament.GetTeams().Count);
        }

    }
}
