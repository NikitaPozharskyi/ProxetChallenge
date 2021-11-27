using System;
using System.Threading.Tasks;
using Moq;
using ProxNetChallenge.Repository.Interfaces;
using ProxNetChallenge.Services;
using ProxNetChallenge.Services.Interfaces;
using Xunit;

namespace ProxNetChallenge.ProjectTests
{
    public class LobbyServiceTest
    {
        private readonly Mock<IPlayerRepository> _mockPlayerRepo;
        private readonly Mock<ILobbyPlayerRepository> _mockLobbyPlayerRepo;
        private readonly ILobbyService _lobbyService;
        public LobbyServiceTest()
        {
            _mockLobbyPlayerRepo = new Mock<ILobbyPlayerRepository>();
            _mockPlayerRepo = new Mock<IPlayerRepository>();
            _lobbyService = new LobbyService(_mockPlayerRepo.Object, _mockLobbyPlayerRepo.Object);
        }


        [Fact]
        public async Task TestGetCommands()
        {
            var (firstTeam, SecondTeam) = await _lobbyService.GenerateTeams();
        }
    }
}
