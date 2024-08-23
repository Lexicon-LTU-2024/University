namespace University.API.Models.Entities
{
#nullable disable
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }

        //Not in DB
        public string FullName => $"{FirstName} {LastName}";



        //Navigation property
        public Address Address { get; set; }

        //Convention 2 (only ICollection here) 3 (conv 1 + 2)
        public ICollection<Enrollment> Enrollments { get; set; }

      
    }

    public class Banan
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
