using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace WebApplication2.Models
{
    public class CourseLevel
    {
        public int Id { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public int LevelID { get; set; }
        public virtual Level Level { get; set; }
    }
}
