using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using BikeShop.DAL;

namespace BikeShop.Pages.Customer
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
        [DisplayName("Business Name")]
        public string? BusinessName { get; set; }
        public List<SelectListItem>? BusinessTypeOptions { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Business Type")]
        [Range(1, double.MaxValue,
        ErrorMessage = "Please select a business type.")]
        public string? BusinessType { get; set; }
        public bool IsSuccess { get; set; }
        public string? SuccessMessage { get; set; }
        public void OnGet(int id = 0)
        {
            if(id != 0)
            {
                BikeShop.DAL.Customer customer = _customerAdapater.GetCustomerById(id);
                if(customer != null)
                {
                    CustomerId = customer.CustomerId;
                    FirstName = customer.FirstName;
                    LastName = customer.LastName;
                }
            }
            SetupBusinessOptions();
        }
        public void SetupBusinessOptions()
        {
            BusinessTypeOptions = new List<SelectListItem>();
            BusinessTypeOptions.Add(new SelectListItem("", "0"));
            BusinessTypeOptions.Add(new SelectListItem("Services", "1"));
            BusinessTypeOptions.Add(new SelectListItem("General Business", "2"));
            BusinessTypeOptions.Add(new SelectListItem("Hospitality", "3"));
            BusinessTypeOptions.Add(new SelectListItem("Information Technology", "4"));
            BusinessTypeOptions.Add(new SelectListItem("Government", "5"));
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                BikeShop.DAL.Customer customer = new BikeShop.DAL.Customer();
                customer.FirstName = FirstName;
                customer.LastName = LastName;
                customer.CustomerId = CustomerId;

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
                SetupBusinessOptions();
                IsSuccess = false;
            }
        }
    }
}
