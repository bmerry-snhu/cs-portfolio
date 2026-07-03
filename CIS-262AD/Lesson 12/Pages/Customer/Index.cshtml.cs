using Lesson_12.DAL;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson_12.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private ICustomerAdapter _customerAdapter;
        public IndexModel(ICustomerAdapter customerAdapter)
        {
            _customerAdapter = customerAdapter;
        }
        public required IEnumerable<DAL.Customer> Customers { get; set; }
        public void OnGet()
        {
            Customers = _customerAdapter.GetAllCustomers();
        }
    }
}
