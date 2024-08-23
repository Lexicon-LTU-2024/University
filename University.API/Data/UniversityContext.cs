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
            modelBuilder.Entity<Enrollment>().HasKey(e => new { e.StudentId, e.CourseId });
        }
    }
}
