using Microsoft.EntityFrameworkCore;

namespace FootballService.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("teams");

                entity.Property(e => e.Id).HasColumnType("bigint");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("players");

                entity.Property(e => e.Id).HasColumnType("bigint");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Surname).HasMaxLength(255);

                entity.Property(e => e.Sex).HasMaxLength(6);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.Birthday).HasColumnType("date");
            });
        }
    }
}
