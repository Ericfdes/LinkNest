using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<ClickHistory> ClickHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClickHistory>()
                .HasOne(ch => ch.ShortUrl)
                .WithMany(s => s.ClickHistories)
                .HasForeignKey(f => f.ShortUrlId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
