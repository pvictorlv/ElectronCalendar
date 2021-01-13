using ElectronCalendar.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElectronCalendar.Database.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<UserEventInvite> UserEventInvites { get; set; }
    }
}