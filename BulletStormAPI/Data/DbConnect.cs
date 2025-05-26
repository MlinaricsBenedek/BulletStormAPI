using BulletStormAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BulletStormAPI.DatabaseConnection
{
    public class DbConnect : DbContext
    {
        public DbConnect(DbContextOptions<DbConnect> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<Statistics> Matches { get; set; }

        public DbSet<Global> Globals { get; set; }
    }
}
