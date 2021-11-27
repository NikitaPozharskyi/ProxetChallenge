using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProxNetChallenge.Entities;

namespace ProxNetChallenge.Repository
{
    public class Context :DbContext
    {
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<LobbyPlayerEntity> LobbyPlayers { get; set; }

        public Context(DbContextOptions<Context> options)
                : base(options)
            {
                Database.EnsureCreated();
            }
    }
}
