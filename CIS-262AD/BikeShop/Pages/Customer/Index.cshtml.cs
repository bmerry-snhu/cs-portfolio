using BikeShop.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeShop.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private ICustomerAdapter _customerAdapter;
        public IndexModel(ICustomerAdapter customerAdapter)
        {
            _customerAdapter = customerAdapter;
        }
        public IEnumerable<BikeShop.DAL.Customer>? Customers { get; set; }
        public void OnGet()
        {
            Customers = _customerAdapter.GetAllCustomers();
        }
    }
}
