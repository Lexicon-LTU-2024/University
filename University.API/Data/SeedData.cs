using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using University.API.Models.Entities;

namespace University.API.Data
{
    internal class SeedData
    {
        private static Faker faker = new Faker("sv");
        internal static async Task InitAsync(UniversityContext context)
        {
            //If data exists dont run again!!!
            if (await context.Student.AnyAsync()) return;

            var students = GenerateStudents(100);
            await context.AddRangeAsync(students);

            var courses = GenerateCourses(20);
            await context.AddRangeAsync(courses);

            var enrollments = GenerateEnrollments(students, courses);
            await context.AddRangeAsync(enrollments);

            await context.SaveChangesAsync();

        }

        private static IEnumerable<Enrollment> GenerateEnrollments(IEnumerable<Student> students, IEnumerable<Course> courses)
        {
            var rnd = new Random();

            var enrollments = new List<Enrollment>();

            foreach (var student in students)
            {
                foreach (var course in courses)
                {

                    if (rnd.Next(0, 5) == 0)
                    {
                        var enrollment = new Enrollment
                        {
                            Student = student,
                            Grade = rnd.Next(1, 6),
                            Course = course
                        };

                        enrollments.Add(enrollment);
                    }
                
                }
            }
            return enrollments;
        }

        private static List<Course> GenerateCourses(int numberOfCourses)
        {
            var courses = new List<Course>();

            for (int i = 0; i < numberOfCourses; i++)
            {
                var title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Company.Bs());
                var course = new Course { Title = title };
                courses.Add(course);
            }
            return courses;
        }

        private static IEnumerable<Student> GenerateStudents(int numnerOfStudents)
        {
            var students = new List<Student>(numnerOfStudents);

            for (int i = 0; i < numnerOfStudents; i++)
            {
                var fName = faker.Name.FirstName();
                var lName = faker.Name.LastName();
                var avatar = faker.Internet.Avatar();

                var student = new Student()
                {
                    FirstName = fName,
                    LastName = lName,
                    Avatar = avatar,
                    Address = new Address
                    {
                        City = faker.Address.City(),
                        Street = faker.Address.StreetName(),
                        ZipCode = faker.Address.ZipCode()
                    },
                };

                students.Add(student);

            }
            return students;
        }
    }
}