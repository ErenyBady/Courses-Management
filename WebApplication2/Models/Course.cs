using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CourseLevel> CourseLevels { get; set; } = new List<CourseLevel>();

        // Relationship with CourseTeachers (Many-to-Many with Teacher)
        public virtual ICollection<TeacherCourse> TeacherCourses { get; set; } = new List<TeacherCourse>();

        // Relationship with StudentCourses (Many-to-Many with Student)
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
