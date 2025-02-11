using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class TeacherCourse
    {
        public int Id { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
