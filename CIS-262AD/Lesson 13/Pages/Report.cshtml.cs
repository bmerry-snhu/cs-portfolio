using Lesson_13.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson_13.Pages
{
    public class ReportModel : PageModel
    {
        private IReportAdapter _reportAdapter;
        public ReportModel(IReportAdapter reportAdapter)
        {
            _reportAdapter = reportAdapter;
        }
        public required IEnumerable<Report> ReportRows { get; set; }
        public int TotalExams { get; set; }
        public void OnGet()
        {
            ReportRows = _reportAdapter.GetExamsByGrade();
            TotalExams = ReportRows.Sum(row => row.NumberOfExams);
        }
    }
}
