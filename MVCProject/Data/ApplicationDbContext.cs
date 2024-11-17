using InterviewMVCProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewMVCProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Player)
                .WithMany(p => p.Items)
                .HasForeignKey(i => i.PlayerId);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Guild)
                .WithMany(g => g.Players)
                .HasForeignKey(p => p.GuildId);

        }




        // Define your DbSets (tables)
        public DbSet<Item> Items { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Guild> Guilds { get; set; }

    }
}
