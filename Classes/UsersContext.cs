using ChatStudents_Graf.Classes.Common;
using ChatStudents_Graf.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatStudents_Graf.Classes
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public UsersContext() =>
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Config.config);
    }
}
