using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GameStoreBeKPeter.Users;
using GameStoreBeKPeter.VideoGames;
using GameStoreBeKPeter.VideoGamesUsers;

namespace GameStoreBeKPeter.Context
{
    public class ContextBasic : DbContext
    {   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.VideoGames)
                .WithMany(e => e.Users)
                .UsingEntity<VIdeoGamesUser>();
            
        }
        public ContextBasic(DbContextOptions options) : base(options)
        {
            
        }
    }
}
