namespace University.API.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Avatar { get; set; }

        //Navigation property
        public Address Address { get; set; }
    }
}
