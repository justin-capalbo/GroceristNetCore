using GroceristLibrary.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroceristLibrary.DB
{
    public class GroceristContext : DbContext
    { 
        public DbSet<UserList> UserList { get; set; }

        public GroceristContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserList>(m =>
            {
                m.HasIndex(e => e.Name);
            });

            builder.Entity<UserListItem>(m =>
            {
                m.HasIndex(e => e.Name);
            });
        }
    }
}
