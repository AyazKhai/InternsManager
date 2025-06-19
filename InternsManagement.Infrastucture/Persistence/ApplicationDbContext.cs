using InternsManagement.Domain.Entities;
using InternsManagement.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InternsManagement.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Intern> Interns { get; set; }
        public DbSet<InternshipDirection> Directions { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Configurations.ConfigureIntern(modelBuilder);
            Configurations.ConfigureDirection(modelBuilder);
            Configurations.ConfigureProject(modelBuilder);
        }

       
    }

}
