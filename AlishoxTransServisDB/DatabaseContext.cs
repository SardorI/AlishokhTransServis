namespace AlishoxTransServisDB
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<AutoBase> AutoBase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                optionsBuilder.UseSqlite($"Data Source={exePath}\\local_database.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
