using Microsoft.EntityFrameworkCore;

namespace ahmedHanen.Models
{
    public class ApplicationContexte : DbContext
    {
        public ApplicationContexte(DbContextOptions<ApplicationContexte> options) : base(options) { }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Organisateur> organisateurs { get; set; }
        public DbSet<Membre> membres { get; set; }
        public DbSet<Event> events { get; set; }
    }
}
