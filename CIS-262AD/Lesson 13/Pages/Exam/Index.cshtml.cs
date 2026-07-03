using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lesson_13.DAL;

namespace Lesson_13.Pages.Exam
{
    public class IndexModel : PageModel
    {
        private IExamAdapter _examAdapter;
        private IStudentAdapter _studentAdapter;
        public IndexModel(IExamAdapter examAdapter, IStudentAdapter studentAdapter)
        {
            _examAdapter = examAdapter;
            _studentAdapter = studentAdapter;
        }
        public required IEnumerable<DAL.Exam> Exams { get; set; }
        public void OnGet(int id = 0)
        {
            if(id != 0)
            {
                IEnumerable<DAL.Exam> exams = _examAdapter.GetExamByStudentId(id);
                if(exams != null)
                {
                    Exams = exams;
                }
            }
            else
            {
                Exams = _examAdapter.GetAllExams();
            }
        }
        public string GetStudentName(int id)
        {
            var student = _studentAdapter.GetStudentById(id);
            return student?.FirstName + " " + student?.LastName ?? string.Empty;
        }
    }
}
