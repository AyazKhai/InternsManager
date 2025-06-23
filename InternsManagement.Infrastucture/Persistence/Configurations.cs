using InternsManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Persistence.Persistence
{
    public static class Configurations
    {
        public static void ConfigureIntern(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Intern>(entity =>
            {
                entity.HasKey(i => i.Id);

                entity.Property(i => i.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(i => i.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(i => i.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasIndex(i => i.Email)
                    .IsUnique();

                entity.Property(i => i.PhoneNumber)
                    .HasMaxLength(20);

                entity.HasIndex(i => i.PhoneNumber)
                    .IsUnique();

                entity.Property(i => i.DateOfBirth)
                    .IsRequired();

                entity.HasOne(i => i.Direction)
                    .WithMany()  
                    .HasForeignKey(i => i.DirectionId)
                    .OnDelete(DeleteBehavior.Restrict); // запрещаем удаление направления, если есть стажёры

                entity.HasOne(i => i.Project)
                    .WithMany(p => p.Interns)
                    .HasForeignKey(i => i.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict); // запрещаем удаление проекта, если есть стажёры
            });
        }

        public static void ConfigureDirection(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InternshipDirection>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(d => d.Name)
                    .IsUnique();

                entity.Property(d => d.Description)
                    .HasMaxLength(500);

                entity.HasMany(d => d.Projects)
                    .WithOne(p => p.Direction)
                    .HasForeignKey(p => p.DirectionId)
                    .OnDelete(DeleteBehavior.Restrict); 
            });
        }

        public static void ConfigureProject(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(p => p.Name)
                    .IsUnique();

                entity.Property(p => p.Description)
                    .HasMaxLength(500);
            });
        }
    }

}
