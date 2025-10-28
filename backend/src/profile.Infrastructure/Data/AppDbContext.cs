using Microsoft.EntityFrameworkCore;
using profile.Domain.Entities;
using valet.lib.Auth.Data;

namespace profile.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions options) : AuthDbContext(options)
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
