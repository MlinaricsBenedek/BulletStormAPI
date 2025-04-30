using BulletStormAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BulletStormAPI.DatabaseConnection
{
    public class DbConnect : DbContext
    {
        public DbConnect(DbContextOptions<DbConnect> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Result> Results {get;set;}
    }
}
