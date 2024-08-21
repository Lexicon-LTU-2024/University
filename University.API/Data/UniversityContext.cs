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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Kalle1", LastName = "Anka", Avatar= "123"},
                new Student { Id = 2, FirstName = "Kalle2", LastName = "Anka", Avatar= "123"},
                new Student { Id = 3, FirstName = "Kalle3", LastName = "Anka", Avatar= "123"}
                );
        }
    }
}
