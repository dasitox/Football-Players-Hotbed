using FootballPlayersHotbed.Services;
using FootballPlayersHotbed_Test.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace FootballPlayersHotbed_Test
{
    [TestClass]
    public class PlayerServiceTest
    {
        [TestMethod]
        public void Get_Player_Smoothly()
        {
            Mock<IPlayerRepository> playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup(a => a.GetPlayer(1001)).Returns(StubsForMock.player_1);
            PlayerRepository playerRepository = new PlayerRepository(playerRepo.Object);
            var result = playerRepository.GetPlayer(1001);

            Assert.AreEqual(1001, result.Id);
            playerRepo.Verify(a => a.GetPlayer(1001));
        }

        [TestMethod]
        public async Task Method_To_Show_Players()
        {
            Mock<IPlayerRepository> repoPlayer = new Mock<IPlayerRepository>();
            repoPlayer.Setup(a => a.GetPlayers()).ReturnsAsync(StubsForMock.playersExamples);
            PlayerRepository playerRepository = new PlayerRepository(repoPlayer.Object);
            var result = await playerRepository.GetPlayers();

            Assert.IsNotNull(result);
            Assert.AreEqual(StubsForMock.playersExamples, result);
            repoPlayer.Verify(a => a.GetPlayers());
        }

        [TestMethod]
        public async Task Method_Show_Representatives()
        {
            Mock<IPlayerRepository> playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup(a => a.GetRepresentatives()).ReturnsAsync(StubsForMock.representativesExamples);
            PlayerRepository playerRepository = new PlayerRepository(playerRepo.Object);
            var result = await playerRepository.GetRepresentatives();

            Assert.IsNotNull(result);
            Assert.AreEqual(StubsForMock.representativesExamples, result);
            playerRepo.Setup(a => a.GetRepresentatives());
        }

        [TestMethod]
        public async Task Method_Show_Representative()
        {
            Mock<IPlayerRepository> playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup((x) => x.SearchRepresentative(It.IsAny<string>())).ReturnsAsync(StubsForMock.Representative_1);
            PlayerRepository playerRepository = new PlayerRepository(playerRepo.Object);
            var result = await playerRepository.SearchRepresentative(It.IsAny<string>());

            Assert.IsNotNull(result);
            Assert.AreEqual(StubsForMock.Representative_1, result);
            playerRepo.Verify((x) => x.SearchRepresentative(It.IsAny<string>()));
        }

        [TestMethod]
        public void Check_Remove_Player()
        {
            Mock<IPlayerRepository> playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup((a) => a.DeletePlayer(StubsForMock.player_2));
            PlayerRepository playerRepository = new PlayerRepository(playerRepo.Object);
            playerRepository.DeletePlayer(StubsForMock.player_2);            
            playerRepo.Verify((a) => a.DeletePlayer(StubsForMock.player_2));
        }

        [TestMethod]
        public void Check_Add_Player()
        {
            Mock<IPlayerRepository> playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup((a) => a.AddPlayer(StubsForMock.player_1));
            PlayerRepository playerRepository = new PlayerRepository(playerRepo.Object);
            var listPlayer = playerRepository.AddPlayer(StubsForMock.player_1);

            Assert.IsNotNull(listPlayer);
            playerRepo.Verify((a) => a.AddPlayer(StubsForMock.player_1));
        }

        [TestMethod]
        public async Task Check_Get_Team_Player()
        {
            Mock<IPlayerRepository> playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup((a) => a.GetTeamPlayer(1001)).ReturnsAsync(StubsForMock.Team);
            PlayerRepository playerRepository = new PlayerRepository(playerRepo.Object);
            var result = await playerRepository.GetTeamPlayer(1001);

            Assert.AreEqual(result.PlayerId, StubsForMock.Team.PlayerId);
            playerRepo.Verify(a => a.GetTeamPlayer(It.IsAny<int>()));
        }

        [TestMethod]
        public void Check_PlayerExist()
        {
            Mock<IPlayerRepository> playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup((a) => a.PlayerExist(1001)).Returns(true);
            PlayerRepository playerRepository = new PlayerRepository(playerRepo.Object);
            var result = playerRepository.PlayerExist(1001);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, true);
            playerRepo.Verify((a) => a.PlayerExist(1001));
        }



    }
}
