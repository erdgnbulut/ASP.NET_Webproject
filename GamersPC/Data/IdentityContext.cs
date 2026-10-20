using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class IdentityContext : IdentityDbContext<User, Role, string>
    {

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<User> _Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<UserGame> UserGames { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ara tablo ilişkisi
            modelBuilder.Entity<UserGame>()
                .HasKey(ug => new { ug.UserId, ug.GamesId }); // Composite key

            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGames)
                .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.Game)
                .WithMany(g => g.UserGames)
                .HasForeignKey(ug => ug.GamesId);
        }
    }
}
