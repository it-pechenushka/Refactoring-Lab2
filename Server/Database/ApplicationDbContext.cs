using Microsoft.EntityFrameworkCore;
using Server.Model;

namespace Server.Database
{
    public sealed class ApplicationDbContext: DbContext
    {
        public DbSet<TrackRecord> Tracks { set; get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackRecord>()
                .HasIndex(p => new {p.Author , p.Composition}).IsUnique();
        }
    }
}