using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // 📌 Autocomplete search for students
        [HttpGet]
        public JsonResult SearchStudents(string term)
        {
            var students = _context.Student
                .Where(s => s.Name.Contains(term))
                .Select(s => new { s.Id, s.Name })
                .ToList();

            return Json(students);
        }

        // 📌 Get available courses for a selected student
        [HttpGet]
        public JsonResult GetCoursesForStudent(int studentId)
        {
            var student = _context.Student
                .Include(s => s.Level)
                .FirstOrDefault(s => s.Id == studentId);

            if (student == null)
                return Json(new { error = "Student not found" });

            var assignedCoursesIDs = _context.StudentCourses
                .Where(sc => sc.StudentID == studentId)
                .Select(sc => sc.CourseID)
            .ToList();
            var assignedCourses = _context.StudentCourses
                .Where(sc => sc.StudentID == studentId)
                .Select(sc => new { sc.Course.Id, sc.Course.Name })
            .ToList();
            var availableCourses = _context.CourseLevels
                .Where(cl => cl.LevelID == student.LevelId && !assignedCoursesIDs.Contains(cl.CourseID))
                .Select(cl => new
                {
                    cl.Course.Id,
                    cl.Course.Name,
                    Teachers = cl.Course.TeacherCourses.Select(ct => ct.Teacher.Name).ToList()
                })
                .ToList();

            return Json(new { availableCourses, assignedCourses });
        }

        // 📌 Assign selected courses to a student
        [HttpPost]
        public JsonResult AssignCourses(int studentId, List<int> courseIds)
        {
            foreach (var courseId in courseIds)
            {
                _context.StudentCourses.Add(new StudentCourse
                {
                    StudentID = studentId,
                    CourseID = courseId
                });
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }

        // 📌 Remove assigned courses from a student
        [HttpPost]
        public JsonResult RemoveAssignedCourses(int studentId, List<int> courseIds)
        {
            var coursesToRemove = _context.StudentCourses
                .Where(sc => sc.StudentID == studentId && courseIds.Contains(sc.CourseID))
            .ToList();

            _context.StudentCourses.RemoveRange(coursesToRemove);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        // 📌 View all students and their assigned courses (Popup)
        [HttpGet]
        public JsonResult ViewAllStudents()
        {
            var students = _context.Student
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    Courses = s.StudentCourses.Select(sc => new { sc.Course.Id, sc.Course.Name }).ToList()
                })
                .ToList();

            return Json(students);
        }
    }
}
