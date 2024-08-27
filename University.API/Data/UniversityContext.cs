using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.API.Models.Entities;

namespace University.API.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext (DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student => Set<Student>();
        public DbSet<Course> Course => Set<Course>();
        public DbSet<Book> Book => Set<Book>();
       // public DbSet<Enrollment> Enrollment => Set<Enrollment>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder); 
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Enrollment>().HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Student>()
               .HasMany(s => s.Courses)
               .WithMany(c => c.Students)
               .UsingEntity<Enrollment>(
               e => e.HasOne(e => e.Course).WithMany(c => c.Enrollment),
               e => e.HasOne(e => e.Student).WithMany(s => s.Enrollments),
               e => e.HasKey(e => new { e.CourseId, e.StudentId }));
        }
    }
}
