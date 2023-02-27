using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hp_Web_App.Shared.DbContexts
{
    public class DbWebAppContext : DbContext
    {
        public DbWebAppContext(DbContextOptions options) : base(options)
        {

        }

        // Set Tables
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model here


            base.OnModelCreating(modelBuilder);
        }
    }
}
