using ChatStudents_Graf.Classes.Common;
using ChatStudents_Graf.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatStudents_Graf.Classes
{
    public class MessagesContext : DbContext
    {
        public DbSet<Messages> Messages { get; set; }
        public MessagesContext() =>
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Config.config);
    }
}
