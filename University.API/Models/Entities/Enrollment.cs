namespace University.API.Models.Entities
{
    public class Enrollment
    {
        //public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }


        public int Grade { get; set; }




        //Convention 1 only Student prop here
        //Convention 2 nothing here
        //Convention 3 same as 1 here
        //Convention 4 same plus FK prop
        //Navigation prop
        public Student Student { get; set; }
        public Course Course { get; set; }


    }
}
