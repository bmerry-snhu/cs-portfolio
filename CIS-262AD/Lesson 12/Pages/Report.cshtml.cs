using Lesson_12.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson_12.Pages
{
    public class ReportModel : PageModel
    {
        private IReportAdapter _reportAdapter;
        public ReportModel(IReportAdapter reportAdapter)
        {
            _reportAdapter = reportAdapter;
        }
        public IEnumerable<Report> ReportRows { get; set; }
        public void OnGet()
        {
            ReportRows = _reportAdapter.GetSalesByCountry();
        }
    }
}
