using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson_08.Pages
{
    public class CustomerModel : PageModel
    {
        [BindProperty]
        public string? FirstName { get; set; }
        [BindProperty]
        public string? LastName { get; set; }
        [BindProperty]
        public string? BusinessName { get; set; }
        public bool IsSuccess { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            IsSuccess = true;
        }
    }
}
