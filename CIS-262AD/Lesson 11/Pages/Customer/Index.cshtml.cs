using Lesson_11.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson_11.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private ICustomerAdapter _customerAdapter;
        public IndexModel(ICustomerAdapter customerAdapter)
        {
            _customerAdapter = customerAdapter;
        }
        public required IEnumerable<Lesson_11.DAL.Customer> Customers { get; set; }
        public void OnGet()
        {
            Customers = _customerAdapter.GetAllCustomers();
        }
    }
}
