using Microsoft.Data.Entity;

namespace InspirationSite.Models
{
    public class AppDbContext : DbContext
    {
        private static bool _created = false;

        public AppDbContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public DbSet<BlogPosts> BlogPosts { get; set; }
        public DbSet<PackMembers> PackMember { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<Videos> Videos { get; set; }
    }
}
