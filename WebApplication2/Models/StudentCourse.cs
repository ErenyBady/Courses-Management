namespace WebApplication2.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
