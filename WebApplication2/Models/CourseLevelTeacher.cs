using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class CourseLevelTeacher
    {
        [Key]
        public int CourseLevelTeacherID { get; set; }

        public int CourseLevelID { get; set; }
        public int TeacherID { get; set; }

        [ForeignKey("CourseLevelID")]
        public CourseLevel CourseLevel { get; set; }

        [ForeignKey("TeacherID")]
        public Teacher Teacher { get; set; }
    }
}
