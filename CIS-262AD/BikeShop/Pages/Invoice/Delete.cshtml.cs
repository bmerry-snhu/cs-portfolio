using BikeShop.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeShop.Pages.Invoice
{
    public class DeleteModel : PageModel
    {
        private IInvoiceAdapter _invoiceAdapter;
        public int Id { get; set; }
        public DeleteModel(IInvoiceAdapter invoiceAdapter)
        {
            _invoiceAdapter = invoiceAdapter;
        }
        public bool IsSuccess = false;
        public void OnGet(int id = 0)
        {
            Id = id;
            if(id > 0)
            {
                bool isDelete = _invoiceAdapter.DeleteInvoiceById(id);
                if(isDelete)
                {
                    IsSuccess = true;
                }
                else
                {
                    IsSuccess = false;
                }
            }
            else
            {
                IsSuccess = false;
            }
        }
    }
}
