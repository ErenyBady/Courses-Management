using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TeacherCourse> TeacherCourses { get; set; }
    }
}
