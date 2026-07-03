using Lesson_11.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson_11.Pages.Invoice
{
    public class IndexModel : PageModel
    {
        private IInvoiceAdapter _invoiceAdapater;
        public IndexModel(IInvoiceAdapter invoiceAdapter)
        {
            _invoiceAdapater = invoiceAdapter;
        }
        public required IEnumerable<Lesson_11.DAL.Invoice> Invoices { get; set; }
        public void OnGet()
        {
            Invoices = _invoiceAdapater.GetAllInvoices();
        }
    }
}
