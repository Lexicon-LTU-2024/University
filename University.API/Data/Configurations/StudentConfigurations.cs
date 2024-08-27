using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using University.API.Models.Entities;

namespace University.API.Data.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Avatar)
              .HasMaxLength(255);

            builder.HasOne(s => s.Address)
              .WithOne(a => a.Student)
              .HasForeignKey<Address>(a => a.StudentId);

            builder.Ignore(s => s.FullName);

            builder
              .HasMany(s => s.Courses)
              .WithMany(c => c.Students)
              .UsingEntity<Enrollment>(
              e => e.HasOne(e => e.Course).WithMany(c => c.Enrollment),
              e => e.HasOne(e => e.Student).WithMany(s => s.Enrollments));
            

        }

        public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
        {
            public void Configure(EntityTypeBuilder<Enrollment> builder)
            {
                builder.HasKey(e => new { e.StudentId, e.CourseId });

                builder.Property(e => e.Grade)
                    .IsRequired();

                builder.HasOne(e => e.Student)
                    .WithMany(s => s.Enrollments)
                    .HasForeignKey(e => e.StudentId);

                builder.HasOne(e => e.Course)
                    .WithMany(c => c.Enrollment)
                    .HasForeignKey(e => e.CourseId);
            }
        }
    }
}
