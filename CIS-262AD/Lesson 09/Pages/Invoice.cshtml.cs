using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson_09
{
    public class InvoiceModel : PageModel
    {
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
        public decimal Amount { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        public bool IsSuccess { get; set; }
        public void OnGet()
        {
            SetupCustomerOptions();
            InvoiceDate = DateTime.Now;
        }
        public void SetupCustomerOptions()
        {
            CustomerOptions = new List<SelectListItem>();
            CustomerOptions.Add(new SelectListItem("", "0"));
            CustomerOptions.Add(new SelectListItem("Mickey Mouse", "1"));
            CustomerOptions.Add(new SelectListItem("Minnie Mouse", "2"));
            CustomerOptions.Add(new SelectListItem("Donald Duck", "3"));
            CustomerOptions.Add(new SelectListItem("Daisy Duck", "4"));
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                IsSuccess = true;
            }
            else
            {
                SetupCustomerOptions();
                IsSuccess = false;
            }
        }
    }
}
