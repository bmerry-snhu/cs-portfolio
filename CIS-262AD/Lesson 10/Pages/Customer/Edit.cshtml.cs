using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lesson_10.DAL;

namespace Lesson_10.Pages.Customer
{
    public class EditModel : PageModel
    {
        private ICustomerAdapter _customerAdapater;
        public EditModel(ICustomerAdapter customerAdapter)
        {
            _customerAdapater = customerAdapter;
        }
        [BindProperty]
        public int CustomerId { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Country")]
        public string? Country { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Email")]
        public string? Email { get; set; }
        public bool IsSuccess { get; set; }
        public string? SuccessMessage { get; set; }
        public void OnGet(int id = 0)
        {
            if(id != 0)
            {
                Lesson_10.DAL.Customer customer = _customerAdapater.GetCustomerById(id);
                if(customer != null)
                {
                    CustomerId = customer.CustomerId;
                    FirstName = customer.FirstName;
                    LastName = customer.LastName;
                    Country = customer.Country;
                    Email = customer.Email;
                }
            }
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Lesson_10.DAL.Customer customer = new Lesson_10.DAL.Customer();
                customer.FirstName = FirstName;
                customer.LastName = LastName;
                customer.CustomerId = CustomerId;
                customer.Country = Country;
                customer.Email = Email;

                if (CustomerId > 0)
                {
                    bool isUpdate = _customerAdapater.UpdateCustomer(customer);
                    if(isUpdate)
                    {
                        IsSuccess = true;
                        SuccessMessage = $"You successfully updated: {FirstName} {LastName}";
                    }
                    else
                    {
                        IsSuccess = false;
                    }
                }
                else
                {
                    bool isCreate = _customerAdapater.InsertCustomer(customer);
                    if(isCreate)
                    {
                        IsSuccess = true;
                        SuccessMessage = $"You successfully created: {FirstName} {LastName}";
                    }
                    else
                    {
                        IsSuccess = false;
                    }
                }
                IsSuccess = true;
            }
            else
            {
                IsSuccess = false;
            }
        }
    }
}
