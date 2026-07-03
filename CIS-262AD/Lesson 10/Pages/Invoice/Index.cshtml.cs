using Lesson_10.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson_10.Pages.Invoice
{
    public class IndexModel : PageModel
    {
        private IInvoiceAdapter _invoiceAdapater;
        public IndexModel(IInvoiceAdapter invoiceAdapter)
        {
            _invoiceAdapater = invoiceAdapter;
        }
        public required IEnumerable<Lesson_10.DAL.Invoice> Invoices { get; set; }
        public void OnGet()
        {
            Invoices = _invoiceAdapater.GetAllInvoices();
        }
    }
}
