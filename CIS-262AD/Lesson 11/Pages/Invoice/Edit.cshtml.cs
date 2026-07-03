using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lesson_11.DAL;

namespace Lesson_11.Pages.Invoice
{
    public class EditModel : PageModel
    {
        private IInvoiceAdapter _invoiceAdapater;
        private ICustomerAdapter _customerAdapater;
        public EditModel(IInvoiceAdapter invoiceAdapter, ICustomerAdapter customerAdapter)
        {
            _invoiceAdapater = invoiceAdapter;
            _customerAdapater = customerAdapter;

        }
        [BindProperty]
        public int InvoiceId { get; set; }
        public List<SelectListItem>? CustomerOptions { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Customer")]
        [Range(1, double.MaxValue,
        ErrorMessage = "Please select a customer.")]
        public int CustomerId { get; set; }
        [BindProperty]
        [Required]
        [Range(1,15000)]
        public decimal Total { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        public bool IsSuccess { get; set; }
        public void OnGet(int id = 0)
        {
            SetupCustomerOptions();
            Lesson_11.DAL.Invoice invoice = _invoiceAdapater.GetInvoiceById(id);
            if(invoice != null)
            {
                InvoiceId = invoice.InvoiceId;
                CustomerId = invoice.CustomerId;
                Total = invoice.Total;
                InvoiceDate = invoice.InvoiceDate;
            }
        }
        public void SetupCustomerOptions()
        {
            CustomerOptions = new List<SelectListItem>();
            IEnumerable<Lesson_11.DAL.Customer> customers = _customerAdapater.GetAllCustomers();
            foreach(Lesson_11.DAL.Customer customer in customers)
            {
                SelectListItem itemToAdd = new SelectListItem();
                itemToAdd.Text = customer.FirstName + " " + customer.LastName;
                itemToAdd.Value = customer.CustomerId.ToString();
                CustomerOptions.Add(itemToAdd);
            }
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Lesson_11.DAL.Invoice invoice = new DAL.Invoice();
                invoice.InvoiceId = InvoiceId;
                invoice.CustomerId = CustomerId;
                invoice.Total = Total;
                invoice.InvoiceDate = InvoiceDate;

                if(InvoiceId > 0)
                {
                    IsSuccess = _invoiceAdapater.UpdateInvoice(invoice);
                }
                else
                {
                    IsSuccess = _invoiceAdapater.InsertInvoice(invoice);
                }
            }
            else
            {
                SetupCustomerOptions();
                IsSuccess = false;
            }
        }
    }
}
