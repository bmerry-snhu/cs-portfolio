using BikeShop.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeShop.Pages.Invoice
{
    public class IndexModel : PageModel
    {
        private IInvoiceAdapter _invoiceAdapater;
        public IndexModel(IInvoiceAdapter invoiceAdapter)
        {
            _invoiceAdapater = invoiceAdapter;
        }
        public IEnumerable<BikeShop.DAL.Invoice>? Invoices { get; set; }
        public void OnGet()
        {
            Invoices = _invoiceAdapater.GetAllInvoices();
        }
    }
}
