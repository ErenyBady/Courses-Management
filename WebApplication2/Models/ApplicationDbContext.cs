using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        public DbSet<Course> Course { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        //public DbSet<CourseLevelTeacher> CourseLevelTeachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique Index to prevent duplicate entries in relation tables
            modelBuilder.Entity<CourseLevel>()
                .HasIndex(cl => new { cl.CourseID, cl.LevelID })
                .IsUnique();

            modelBuilder.Entity<TeacherCourse>()
                .HasIndex(ct => new { ct.CourseID, ct.TeacherID })
                .IsUnique();

            modelBuilder.Entity<StudentCourse>()
                .HasIndex(sc => new { sc.StudentID, sc.CourseID })
                .IsUnique();
        }
    }
}
