using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CourseLevel> CourseLevels { get; set; } = new List<CourseLevel>();

        // Relationship with Students (One-to-Many)
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
