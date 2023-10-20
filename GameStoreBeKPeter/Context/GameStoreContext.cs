using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GameStoreBeKPeter.Users;
using GameStoreBeKPeter.VideoGames;
using GameStoreBeKPeter.VideoGamesUsers;

namespace GameStoreBeKPeter.Context
{
    public class ContextBasic : DbContext
    {   
        public ContextBasic(DbContextOptions<ContextBasic> opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.VideoGames)
                .WithMany(e => e.Users)
                .UsingEntity<VideoGamesUser>();
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
       
    }
}
