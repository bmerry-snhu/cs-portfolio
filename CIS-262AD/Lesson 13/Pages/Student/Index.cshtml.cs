using Lesson_13.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson_13.Pages.Student
{
    public class IndexModel : PageModel
    {
        private IStudentAdapter _studentAdapter;
        public IndexModel(IStudentAdapter studentAdapter)
        {
            _studentAdapter = studentAdapter;
        }
        public required IEnumerable<DAL.Student> Students { get; set; }
        public void OnGet(int id = 0)
        {
            if(id != 0)
            {
                DAL.Student student = _studentAdapter.GetStudentById(id);
                if(student != null)
                {
                    Students = new List<DAL.Student> { student };
                }
            }
            else
            {
                Students = _studentAdapter.GetAllStudents();
            }
        }
    }
}
