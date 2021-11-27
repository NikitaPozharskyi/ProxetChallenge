using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ProxNetChallenge.Entities;
using ProxNetChallenge.Entities.models;
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


        //_lobbyPlayerRepository.GetLobbyPlayersOrderebBy();
        [Fact]
        public async Task TestGetCommandsNotEnoughForTeams()
        {
            var entityFirst = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now, VehicleType = Vehicle.First };
            var entitySecond = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now, VehicleType = Vehicle.Second };
            var entityThird = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now, VehicleType = Vehicle.Third };

            var entityFourth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now, VehicleType = Vehicle.First };
            var entityFiveth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now, VehicleType = Vehicle.Second };
            var entitySixth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now, VehicleType = Vehicle.Third };

            var entitySeventh = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now, VehicleType = Vehicle.First };
            var entityEigth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now, VehicleType = Vehicle.Second };
            var entityNineth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now, VehicleType = Vehicle.Third };



            _mockLobbyPlayerRepo.Setup(repo => repo.GetLobbyPlayersOrderebBy()).ReturnsAsync(new List<LobbyPlayerEntity> { entityFirst, entitySecond, entityThird, entityFourth, entityFourth, entityFiveth, entitySixth, entitySeventh, entityEigth, entityNineth });
            var (firstTeam, SecondTeam) = await _lobbyService.GenerateTeams();

            Assert.Equal(firstTeam.Count, 0);
        }

        [Fact]
        public async Task TestGetCommandsEnoughForTeam()
        {
            var entityFirst = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now, VehicleType = Vehicle.First };
            var entitySecond = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(10), VehicleType = Vehicle.Second };
            var entityThird = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(11), VehicleType = Vehicle.Third };

            var entityFourth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(12), VehicleType = Vehicle.First };
            var entityFiveth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(13), VehicleType = Vehicle.Second };
            var entitySixth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(14), VehicleType = Vehicle.Third };

            var entitySeventh = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(15), VehicleType = Vehicle.First };
            var entityEigth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(16), VehicleType = Vehicle.Second };
            var entityNineth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(17), VehicleType = Vehicle.Third };

            var SecondentityFirst = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(18), VehicleType = Vehicle.First };
            var SecondentitySecond = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(19), VehicleType = Vehicle.Second };
            var SecondentityThird = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(20), VehicleType = Vehicle.Third };

            var SecondentityFourth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(21), VehicleType = Vehicle.First };
            var SecondentityFiveth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(22), VehicleType = Vehicle.Second };
            var SecondentitySixth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(23), VehicleType = Vehicle.Third };

            var SecondentitySeventh = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(24), VehicleType = Vehicle.First };
            var SecondentityEigth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(25), VehicleType = Vehicle.Second };
            var SecondentityNineth = new LobbyPlayerEntity { PlayerId = Guid.NewGuid(), IncomeDate = DateTime.Now + TimeSpan.FromSeconds(26), VehicleType = Vehicle.Third };

            var lobbyPlayerEntities = new List<LobbyPlayerEntity> { entityFirst, entitySecond, entityThird, entityFourth, entityFourth, entityFiveth, entitySixth, entitySeventh, entityEigth, entityNineth };
            var playerEntities = new List<LobbyPlayerEntity> { SecondentityFirst, SecondentitySecond, SecondentityThird, SecondentityFourth, SecondentityFourth, SecondentityFiveth, SecondentitySixth, SecondentitySeventh, SecondentityEigth, SecondentityNineth };
            playerEntities.AddRange(lobbyPlayerEntities);
            _mockLobbyPlayerRepo.Setup(repo => repo.GetLobbyPlayersOrderebBy()).ReturnsAsync(playerEntities.OrderBy(player=>player.IncomeDate).ToList());
            var (firstTeam, SecondTeam) = await _lobbyService.GenerateTeams();

            Assert.Equal(firstTeam.Count, 9);
            Assert.Equal(firstTeam[0].PlayerId, entityFirst.PlayerId);
        }
    }
}
